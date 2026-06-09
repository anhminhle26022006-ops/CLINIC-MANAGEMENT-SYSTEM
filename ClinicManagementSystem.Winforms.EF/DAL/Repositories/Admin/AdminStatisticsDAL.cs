using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class AdminStatisticsDAL : IAdminStatisticsDAL
    {
        private const int LowStockThreshold = 20;

        public AdminStatisticsDTO GetStatistics(DateTime referenceDate)
        {
            DateTime today = referenceDate.Date;
            DateTime tomorrow = today.AddDays(1);
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);
            DateTime nextMonthStart = monthStart.AddMonths(1);
            DateTime previousMonthStart = monthStart.AddMonths(-1);

            int newPatientsThisMonth = CountByDateRange("Patients", "CreatedAt", monthStart, nextMonthStart);
            int newPatientsPreviousMonth = CountByDateRange("Patients", "CreatedAt", previousMonthStart, monthStart);
            int appointmentsThisMonth = CountByDateRange("Appointments", "AppointmentDate", monthStart, nextMonthStart);
            int appointmentsPreviousMonth = CountByDateRange("Appointments", "AppointmentDate", previousMonthStart, monthStart);
            decimal revenueThisMonth = GetRevenue(monthStart, nextMonthStart);
            decimal revenuePreviousMonth = GetRevenue(previousMonthStart, monthStart);

            return new AdminStatisticsDTO
            {
                TotalPatients = CountTable("Patients"),
                NewPatientsThisMonth = newPatientsThisMonth,
                PatientGrowthPercent = CalculateGrowthPercent(newPatientsThisMonth, newPatientsPreviousMonth),
                MonthlyAppointmentCount = appointmentsThisMonth,
                AppointmentGrowthPercent = CalculateGrowthPercent(appointmentsThisMonth, appointmentsPreviousMonth),
                MonthlyRevenue = revenueThisMonth,
                RevenueGrowthPercent = CalculateGrowthPercent(revenueThisMonth, revenuePreviousMonth),
                TodayAppointmentCount = CountByDateRange("Appointments", "AppointmentDate", today, tomorrow),
                ActiveEmployeeCount = CountActiveEmployees(),
                LowStockMedicineCount = CountLowStockMedicines(),
                QueueSummary = GetQueueSummary(),
                PatientTrend = GetPatientTrend(monthStart),
                RevenueTrend = GetRevenueTrend(monthStart),
                DepartmentStatistics = GetDepartmentStatistics(monthStart, nextMonthStart),
                TodayAppointments = GetTodayAppointments(today, tomorrow),
                LowStockMedicines = GetLowStockMedicines()
            };
        }

        private static int CountTable(string tableName)
        {
            if (!SchemaHelper.TableExists(tableName))
            {
                return 0;
            }

            return ExecuteInt("SELECT COUNT(*) FROM " + tableName);
        }

        private static int CountByDateRange(string tableName, string dateColumn, DateTime start, DateTime end)
        {
            if (!SchemaHelper.TableExists(tableName) || !SchemaHelper.ColumnExists(tableName, dateColumn))
            {
                return 0;
            }

            string query = $@"
                SELECT COUNT(*)
                FROM {tableName}
                WHERE {dateColumn} >= @StartDate
                  AND {dateColumn} < @EndDate";

            return ExecuteInt(query, new[]
            {
                new SqlParameter("@StartDate", start),
                new SqlParameter("@EndDate", end)
            });
        }

        private static int CountActiveEmployees()
        {
            if (!SchemaHelper.TableExists("Employees"))
            {
                return 0;
            }

            string query = @"
                SELECT COUNT(*)
                FROM Employees
                WHERE ISNULL(Status, N'Active') NOT IN (N'Inactive', N'Ngưng hoạt động', N'Nghỉ việc')";

            return ExecuteInt(query);
        }

        private static int CountLowStockMedicines()
        {
            if (!SchemaHelper.TableExists("Medicines"))
            {
                return 0;
            }

            return ExecuteInt(
                "SELECT COUNT(*) FROM Medicines WHERE ISNULL(Stock, 0) <= @Threshold",
                new[] { new SqlParameter("@Threshold", LowStockThreshold) });
        }

        private static AdminQueueSummaryDTO GetQueueSummary()
        {
            AdminQueueSummaryDTO summary = new AdminQueueSummaryDTO();
            if (!SchemaHelper.TableExists("PatientQueues"))
            {
                return summary;
            }

            string query = @"
                SELECT
                    SUM(CASE WHEN Status IN (N'Waiting', N'Pending', N'Chờ khám', N'Đang chờ', N'Cho kham') THEN 1 ELSE 0 END) AS Waiting,
                    SUM(CASE WHEN Status IN (N'InProgress', N'Processing', N'Đang khám', N'In Progress') THEN 1 ELSE 0 END) AS InProgress,
                    SUM(CASE WHEN Status IN (N'Completed', N'Done', N'Hoàn thành', N'Hoan thanh') THEN 1 ELSE 0 END) AS Completed,
                    SUM(CASE WHEN Status IN (N'Cancelled', N'Canceled', N'Hủy', N'Huy', N'Đã hủy') THEN 1 ELSE 0 END) AS Cancelled
                FROM PatientQueues";

            DataTable table = ExecuteTable(query);
            if (table.Rows.Count == 0)
            {
                return summary;
            }

            DataRow row = table.Rows[0];
            summary.Waiting = ReadInt(row, "Waiting");
            summary.InProgress = ReadInt(row, "InProgress");
            summary.Completed = ReadInt(row, "Completed");
            summary.Cancelled = ReadInt(row, "Cancelled");
            return summary;
        }

        private static List<AdminChartPointDTO> GetPatientTrend(DateTime currentMonthStart)
        {
            List<AdminChartPointDTO> points = CreateEmptyTrend(currentMonthStart);
            if (!SchemaHelper.TableExists("Patients") || !SchemaHelper.ColumnExists("Patients", "CreatedAt"))
            {
                return points;
            }

            foreach (AdminChartPointDTO point in points)
            {
                DateTime end = point.PeriodStart.AddMonths(1);
                point.Value = CountByDateRange("Patients", "CreatedAt", point.PeriodStart, end);
            }

            return points;
        }

        private static List<AdminChartPointDTO> GetRevenueTrend(DateTime currentMonthStart)
        {
            List<AdminChartPointDTO> points = CreateEmptyTrend(currentMonthStart);
            foreach (AdminChartPointDTO point in points)
            {
                point.Value = GetRevenue(point.PeriodStart, point.PeriodStart.AddMonths(1));
            }

            return points;
        }

        private static List<AdminChartPointDTO> CreateEmptyTrend(DateTime currentMonthStart)
        {
            List<AdminChartPointDTO> points = new List<AdminChartPointDTO>();
            for (int i = 5; i >= 0; i--)
            {
                DateTime periodStart = currentMonthStart.AddMonths(-i);
                points.Add(new AdminChartPointDTO
                {
                    PeriodStart = periodStart,
                    Label = periodStart.ToString("MM/yyyy"),
                    Value = 0
                });
            }

            return points;
        }

        private static decimal GetRevenue(DateTime start, DateTime end)
        {
            decimal paymentRevenue = 0;
            if (SchemaHelper.TableExists("Payments") && SchemaHelper.ColumnExists("Payments", "PaidAt"))
            {
                paymentRevenue = ExecuteDecimal(@"
                    SELECT ISNULL(SUM(Amount), 0)
                    FROM Payments
                    WHERE PaidAt >= @StartDate
                      AND PaidAt < @EndDate
                      AND ISNULL(Status, N'Paid') NOT IN (N'Cancelled', N'Canceled', N'Hủy', N'Huy', N'Đã hủy')",
                    new[]
                    {
                        new SqlParameter("@StartDate", start),
                        new SqlParameter("@EndDate", end)
                    });
            }

            if (paymentRevenue > 0 || !SchemaHelper.TableExists("Invoices"))
            {
                return paymentRevenue;
            }

            return ExecuteDecimal(@"
                SELECT ISNULL(SUM(Total), 0)
                FROM Invoices
                WHERE CreatedAt >= @StartDate
                  AND CreatedAt < @EndDate
                  AND ISNULL(Status, N'Paid') NOT IN (N'Cancelled', N'Canceled', N'Hủy', N'Huy', N'Đã hủy')",
                new[]
                {
                    new SqlParameter("@StartDate", start),
                    new SqlParameter("@EndDate", end)
                });
        }

        private static List<AdminDepartmentStatisticDTO> GetDepartmentStatistics(DateTime start, DateTime end)
        {
            List<AdminDepartmentStatisticDTO> list = new List<AdminDepartmentStatisticDTO>();
            if (!SchemaHelper.TableExists("Departments"))
            {
                return list;
            }

            if (!SchemaHelper.TableExists("Employees") || !SchemaHelper.TableExists("Appointments"))
            {
                string simpleQuery = @"
                    SELECT TOP 6 DepartmentName
                    FROM Departments
                    ORDER BY DepartmentName";

                foreach (DataRow row in ExecuteTable(simpleQuery).Rows)
                {
                    list.Add(new AdminDepartmentStatisticDTO
                    {
                        DepartmentName = ReadString(row, "DepartmentName"),
                        EmployeeCount = 0,
                        MonthlyAppointmentCount = 0
                    });
                }

                return list;
            }

            string query = @"
                SELECT TOP 6
                       d.DepartmentName,
                       COUNT(DISTINCT e.EmployeeID) AS EmployeeCount,
                       COUNT(DISTINCT a.AppointmentID) AS MonthlyAppointmentCount
                FROM Departments d
                LEFT JOIN Employees e ON e.DepartmentID = d.DepartmentID
                LEFT JOIN Appointments a ON a.DepartmentID = d.DepartmentID
                    AND a.AppointmentDate >= @StartDate
                    AND a.AppointmentDate < @EndDate
                GROUP BY d.DepartmentName
                ORDER BY MonthlyAppointmentCount DESC, EmployeeCount DESC, d.DepartmentName";

            DataTable table = ExecuteTable(query, new[]
            {
                new SqlParameter("@StartDate", start),
                new SqlParameter("@EndDate", end)
            });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new AdminDepartmentStatisticDTO
                {
                    DepartmentName = ReadString(row, "DepartmentName"),
                    EmployeeCount = ReadInt(row, "EmployeeCount"),
                    MonthlyAppointmentCount = ReadInt(row, "MonthlyAppointmentCount")
                });
            }

            return list;
        }

        private static List<AdminAppointmentSummaryDTO> GetTodayAppointments(DateTime start, DateTime end)
        {
            List<AdminAppointmentSummaryDTO> list = new List<AdminAppointmentSummaryDTO>();
            if (!SchemaHelper.TableExists("Appointments") ||
                !SchemaHelper.TableExists("Patients") ||
                !SchemaHelper.TableExists("Employees") ||
                !SchemaHelper.TableExists("Departments"))
            {
                return list;
            }

            string query = @"
                SELECT TOP 10
                       a.AppointmentDate,
                       CONVERT(VARCHAR(5), a.AppointmentDate, 108) AS TimeText,
                       ISNULL(p.FullName, N'Chưa rõ') AS PatientName,
                       ISNULL(e.FullName, N'Chưa phân công') AS DoctorName,
                       ISNULL(d.DepartmentName, N'Chưa rõ') AS DepartmentName,
                       ISNULL(a.Status, N'Chưa cập nhật') AS Status
                FROM Appointments a
                LEFT JOIN Patients p ON p.PatientID = a.PatientID
                LEFT JOIN Employees e ON e.EmployeeID = a.DoctorID
                LEFT JOIN Departments d ON d.DepartmentID = a.DepartmentID
                WHERE a.AppointmentDate >= @StartDate
                  AND a.AppointmentDate < @EndDate
                ORDER BY a.AppointmentDate";

            DataTable table = ExecuteTable(query, new[]
            {
                new SqlParameter("@StartDate", start),
                new SqlParameter("@EndDate", end)
            });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new AdminAppointmentSummaryDTO
                {
                    AppointmentDate = ReadDateTime(row, "AppointmentDate"),
                    TimeText = ReadString(row, "TimeText"),
                    PatientName = ReadString(row, "PatientName"),
                    DoctorName = ReadString(row, "DoctorName"),
                    DepartmentName = ReadString(row, "DepartmentName"),
                    Status = ReadString(row, "Status")
                });
            }

            return list;
        }

        private static List<AdminLowStockMedicineDTO> GetLowStockMedicines()
        {
            List<AdminLowStockMedicineDTO> list = new List<AdminLowStockMedicineDTO>();
            if (!SchemaHelper.TableExists("Medicines"))
            {
                return list;
            }

            string query = @"
                SELECT TOP 6 Name, Unit, Stock, ExpiryDate
                FROM Medicines
                WHERE ISNULL(Stock, 0) <= @Threshold
                ORDER BY ISNULL(Stock, 0), Name";

            DataTable table = ExecuteTable(query, new[] { new SqlParameter("@Threshold", LowStockThreshold) });
            foreach (DataRow row in table.Rows)
            {
                list.Add(new AdminLowStockMedicineDTO
                {
                    MedicineName = ReadString(row, "Name"),
                    Unit = ReadString(row, "Unit"),
                    Stock = ReadInt(row, "Stock"),
                    ExpiryDate = ReadNullableDateTime(row, "ExpiryDate")
                });
            }

            return list;
        }

        private static decimal CalculateGrowthPercent(decimal current, decimal previous)
        {
            if (previous <= 0)
            {
                return current > 0 ? 100 : 0;
            }

            return Math.Round((current - previous) / previous * 100, 1);
        }

        private static int ExecuteInt(string query, SqlParameter[] parameters = null)
        {
            object result = ExecuteScalar(query, parameters);
            return result == null || result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        private static decimal ExecuteDecimal(string query, SqlParameter[] parameters = null)
        {
            object result = ExecuteScalar(query, parameters);
            return result == null || result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }

        private static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                return DatabaseHelper.ExecuteScalar(query, parameters);
            }
            catch
            {
                return null;
            }
        }

        private static DataTable ExecuteTable(string query, SqlParameter[] parameters = null)
        {
            try
            {
                return DatabaseHelper.ExecuteQuery(query, parameters);
            }
            catch
            {
                return new DataTable();
            }
        }

        private static string ReadString(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value
                ? row[columnName].ToString()
                : string.Empty;
        }

        private static int ReadInt(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value
                ? Convert.ToInt32(row[columnName])
                : 0;
        }

        private static DateTime ReadDateTime(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value
                ? Convert.ToDateTime(row[columnName])
                : DateTime.MinValue;
        }

        private static DateTime? ReadNullableDateTime(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value
                ? Convert.ToDateTime(row[columnName])
                : (DateTime?)null;
        }
    }
}
