using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class EmployeeShiftDAL : IEmployeeShiftDAL
    {
        public bool SupportsEmployeeShiftSchema()
        {
            return SchemaHelper.TableExists("EmployeeShifts")
                && SchemaHelper.TableExists("Employees")
                && SchemaHelper.TableExists("Shifts");
        }

        public List<EmployeeShiftDTO> GetAll()
        {
            return GetFiltered(null, null, null);
        }

        public List<EmployeeShiftDTO> GetByEmployee(int employeeId)
        {
            return GetFiltered("es.EmployeeID = @EmployeeID", new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            }, null);
        }

        public List<EmployeeShiftDTO> GetByDate(DateTime workDate)
        {
            return GetFiltered("CAST(es.WorkDate AS date) = @WorkDate", new[]
            {
                new SqlParameter("@WorkDate", workDate.Date)
            }, null);
        }

        public List<EmployeeShiftDTO> GetByRole(string roleName)
        {
            return GetFiltered("r.RoleName = @RoleName", new[]
            {
                new SqlParameter("@RoleName", roleName)
            }, null);
        }

        public bool Add(EmployeeShiftDTO shift)
        {
            if (!SupportsEmployeeShiftSchema())
            {
                return false;
            }

            List<string> columns = new List<string> { "EmployeeID", "ShiftID", "WorkDate" };
            List<string> values = new List<string> { "@EmployeeID", "@ShiftID", "@WorkDate" };
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@EmployeeID", shift.EmployeeID),
                new SqlParameter("@ShiftID", shift.ShiftID),
                new SqlParameter("@WorkDate", shift.WorkDate.Date)
            };

            AddOptionalColumn(columns, values, parameters, "DepartmentID", "@DepartmentID", (object)shift.DepartmentID ?? DBNull.Value);
            AddOptionalColumn(columns, values, parameters, "RoomID", "@RoomID", (object)shift.RoomID ?? DBNull.Value);
            AddOptionalColumn(columns, values, parameters, "Status", "@Status", string.IsNullOrWhiteSpace(shift.Status) ? "Approved" : shift.Status);
            AddOptionalColumn(columns, values, parameters, "Notes", "@Notes", DBNull.Value);

            string query = $"INSERT INTO EmployeeShifts({string.Join(", ", columns)}) VALUES({string.Join(", ", values)})";
            return DatabaseHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
        }

        public bool HasConflict(int employeeId, DateTime workDate, int shiftId)
        {
            if (!SupportsEmployeeShiftSchema())
            {
                return false;
            }

            string query = @"
                SELECT COUNT(*)
                FROM EmployeeShifts
                WHERE EmployeeID = @EmployeeID
                  AND ShiftID = @ShiftID
                  AND CAST(WorkDate AS date) = @WorkDate";
            object result = DatabaseHelper.ExecuteScalar(query, new[]
            {
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@ShiftID", shiftId),
                new SqlParameter("@WorkDate", workDate.Date)
            });
            return Convert.ToInt32(result) > 0;
        }

        public bool Update(EmployeeShiftDTO shift)
        {
            if (!SupportsEmployeeShiftSchema() || shift.EmployeeShiftID <= 0)
            {
                return false;
            }

            string idColumn = SchemaHelper.ColumnExists("EmployeeShifts", "EmployeeShiftID") ? "EmployeeShiftID" : "ID";
            List<string> assignments = new List<string>
            {
                "EmployeeID = @EmployeeID",
                "ShiftID = @ShiftID",
                "WorkDate = @WorkDate"
            };
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@EmployeeID", shift.EmployeeID),
                new SqlParameter("@ShiftID", shift.ShiftID),
                new SqlParameter("@WorkDate", shift.WorkDate.Date),
                new SqlParameter("@EmployeeShiftID", shift.EmployeeShiftID)
            };

            AddOptionalAssignment(assignments, parameters, "DepartmentID", "@DepartmentID", (object)shift.DepartmentID ?? DBNull.Value);
            AddOptionalAssignment(assignments, parameters, "RoomID", "@RoomID", (object)shift.RoomID ?? DBNull.Value);
            AddOptionalAssignment(assignments, parameters, "Status", "@Status", string.IsNullOrWhiteSpace(shift.Status) ? "Approved" : shift.Status);

            string query = $"UPDATE EmployeeShifts SET {string.Join(", ", assignments)} WHERE {idColumn} = @EmployeeShiftID";
            return DatabaseHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
        }

        public bool SetStatus(int employeeShiftId, string status)
        {
            if (!SupportsEmployeeShiftSchema() || employeeShiftId <= 0 || !SchemaHelper.ColumnExists("EmployeeShifts", "Status"))
            {
                return false;
            }

            string idColumn = SchemaHelper.ColumnExists("EmployeeShifts", "EmployeeShiftID") ? "EmployeeShiftID" : "ID";
            string query = $"UPDATE EmployeeShifts SET Status = @Status WHERE {idColumn} = @EmployeeShiftID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@EmployeeShiftID", employeeShiftId)
            }) > 0;
        }

        public int EnsureMonthlySchedule(string roleName, int employeeId, DateTime startDate, int dayCount)
        {
            if (!SupportsEmployeeShiftSchema())
            {
                return 0;
            }

            string query = @"
                ;WITH CalendarDays AS
                (
                    SELECT TOP (@DayCount)
                        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS DayOffset
                    FROM sys.all_objects
                ),
                EligibleEmployees AS
                (
                    SELECT e.EmployeeID,
                           e.DepartmentID,
                           r.RoleName
                    FROM Employees e
                    INNER JOIN Roles r ON e.RoleID = r.RoleID
                    WHERE ISNULL(e.Status, N'Active') <> N'Inactive'
                      AND (@EmployeeID <= 0 OR e.EmployeeID = @EmployeeID)
                      AND (@RoleName = '' OR r.RoleName = @RoleName)
                ),
                PlannedShifts AS
                (
                    SELECT ee.EmployeeID,
                           ee.DepartmentID,
                           ee.RoleName,
                           DATEADD(DAY, cd.DayOffset, @StartDate) AS WorkDate,
                           (cd.DayOffset + ee.EmployeeID) % 3 AS ShiftBucket
                    FROM EligibleEmployees ee
                    CROSS JOIN CalendarDays cd
                )
                INSERT INTO EmployeeShifts(EmployeeID, ShiftID, WorkDate, DepartmentID, RoomID, Status, Notes)
                SELECT ps.EmployeeID,
                       chosenShift.ShiftID,
                       ps.WorkDate,
                       ps.DepartmentID,
                       room.RoomID,
                       N'Approved',
                       N'Auto seed 30 ngay cho role ' + ps.RoleName
                FROM PlannedShifts ps
                CROSS APPLY
                (
                    SELECT TOP 1 s.ShiftID
                    FROM Shifts s
                    ORDER BY
                        CASE
                            WHEN ps.ShiftBucket = 0 AND (s.Name LIKE N'%sáng%' OR s.StartTime < '12:00') THEN 0
                            WHEN ps.ShiftBucket = 1 AND (s.Name LIKE N'%chiều%' OR (s.StartTime >= '12:00' AND s.StartTime < '17:00')) THEN 0
                            WHEN ps.ShiftBucket = 2 AND (s.Name LIKE N'%tối%' OR s.StartTime >= '17:00') THEN 0
                            ELSE 1
                        END,
                        s.StartTime
                ) chosenShift
                OUTER APPLY
                (
                    SELECT TOP 1 rm.RoomID
                    FROM Rooms rm
                    WHERE rm.DepartmentID = ps.DepartmentID
                      AND ISNULL(rm.Status, 'Available') = 'Available'
                    ORDER BY rm.RoomCode
                ) room
                WHERE NOT EXISTS
                (
                    SELECT 1
                    FROM EmployeeShifts existing
                    WHERE existing.EmployeeID = ps.EmployeeID
                      AND existing.ShiftID = chosenShift.ShiftID
                      AND CAST(existing.WorkDate AS DATE) = ps.WorkDate
                );";

            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@DayCount", dayCount),
                new SqlParameter("@StartDate", startDate.Date),
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@RoleName", roleName ?? string.Empty)
            });
        }

        private List<EmployeeShiftDTO> GetFiltered(string whereClause, SqlParameter[] parameters, string orderBy)
        {
            if (!SupportsEmployeeShiftSchema())
            {
                return new List<EmployeeShiftDTO>();
            }

            string idColumn = SchemaHelper.ColumnExists("EmployeeShifts", "EmployeeShiftID") ? "es.EmployeeShiftID" : "es.ID";
            bool hasDepartment = SchemaHelper.ColumnExists("EmployeeShifts", "DepartmentID");
            bool hasRoom = SchemaHelper.ColumnExists("EmployeeShifts", "RoomID");
            bool hasStatus = SchemaHelper.ColumnExists("EmployeeShifts", "Status");

            string departmentExpression = hasDepartment ? "COALESCE(es.DepartmentID, e.DepartmentID)" : "e.DepartmentID";
            string roomIdExpression = hasRoom ? "es.RoomID" : "CAST(NULL AS int)";
            string roomJoin = hasRoom ? "LEFT JOIN Rooms room ON es.RoomID = room.RoomID" : "LEFT JOIN Rooms room ON 1 = 0";
            string statusExpression = hasStatus ? "ISNULL(es.Status, 'Approved')" : "CAST('Approved' AS nvarchar(50))";

            string query = $@"
                SELECT {idColumn} AS EmployeeShiftID,
                       es.EmployeeID,
                       ISNULL(e.FullName, '') AS EmployeeName,
                       ISNULL(r.RoleName, '') AS RoleName,
                       es.ShiftID,
                       ISNULL(s.Name, '') AS ShiftName,
                       es.WorkDate,
                       ISNULL(s.StartTime, CAST('00:00:00' AS time)) AS StartTime,
                       ISNULL(s.EndTime, CAST('00:00:00' AS time)) AS EndTime,
                       {roomIdExpression} AS RoomID,
                       ISNULL(room.RoomCode, '') AS RoomCode,
                       {departmentExpression} AS DepartmentID,
                       ISNULL(d.DepartmentName, '') AS DepartmentName,
                       {statusExpression} AS Status
                FROM EmployeeShifts es
                LEFT JOIN Employees e ON es.EmployeeID = e.EmployeeID
                LEFT JOIN Roles r ON e.RoleID = r.RoleID
                LEFT JOIN Departments d ON {departmentExpression} = d.DepartmentID
                LEFT JOIN Shifts s ON es.ShiftID = s.ShiftID
                {roomJoin}";

            if (!string.IsNullOrWhiteSpace(whereClause))
            {
                query += " WHERE " + whereClause;
            }

            query += string.IsNullOrWhiteSpace(orderBy)
                ? " ORDER BY es.WorkDate DESC, s.StartTime ASC, e.FullName ASC"
                : " ORDER BY " + orderBy;

            return Map(DatabaseHelper.ExecuteQuery(query, parameters));
        }

        private static void AddOptionalColumn(
            List<string> columns,
            List<string> values,
            List<SqlParameter> parameters,
            string columnName,
            string parameterName,
            object value)
        {
            if (!SchemaHelper.ColumnExists("EmployeeShifts", columnName))
            {
                return;
            }

            columns.Add(columnName);
            values.Add(parameterName);
            parameters.Add(new SqlParameter(parameterName, value ?? DBNull.Value));
        }

        private static void AddOptionalAssignment(
            List<string> assignments,
            List<SqlParameter> parameters,
            string columnName,
            string parameterName,
            object value)
        {
            if (!SchemaHelper.ColumnExists("EmployeeShifts", columnName))
            {
                return;
            }

            assignments.Add($"{columnName} = {parameterName}");
            parameters.Add(new SqlParameter(parameterName, value ?? DBNull.Value));
        }

        private static List<EmployeeShiftDTO> Map(DataTable table)
        {
            List<EmployeeShiftDTO> list = new List<EmployeeShiftDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new EmployeeShiftDTO
                {
                    EmployeeShiftID = Convert.ToInt32(row["EmployeeShiftID"]),
                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                    EmployeeName = row["EmployeeName"].ToString(),
                    RoleName = row["RoleName"].ToString(),
                    ShiftID = row["ShiftID"] != DBNull.Value ? Convert.ToInt32(row["ShiftID"]) : 0,
                    ShiftName = row["ShiftName"].ToString(),
                    WorkDate = row["WorkDate"] != DBNull.Value ? Convert.ToDateTime(row["WorkDate"]) : DateTime.MinValue,
                    StartTime = row["StartTime"] != DBNull.Value ? (TimeSpan)row["StartTime"] : TimeSpan.Zero,
                    EndTime = row["EndTime"] != DBNull.Value ? (TimeSpan)row["EndTime"] : TimeSpan.Zero,
                    RoomID = row["RoomID"] != DBNull.Value ? Convert.ToInt32(row["RoomID"]) : (int?)null,
                    RoomCode = row["RoomCode"].ToString(),
                    DepartmentID = row["DepartmentID"] != DBNull.Value ? Convert.ToInt32(row["DepartmentID"]) : (int?)null,
                    DepartmentName = row["DepartmentName"].ToString(),
                    Status = row["Status"].ToString()
                });
            }
            return list;
        }
    }
}
