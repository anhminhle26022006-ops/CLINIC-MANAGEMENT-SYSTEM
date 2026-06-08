using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;

namespace BUS.Services
{
    public class DashboardBUS
    {
        private readonly PatientBUS _patientBus = new PatientBUS();
        private readonly EmployeeBUS _empBus = new EmployeeBUS();
        private readonly AppointmentBUS _apptBus = new AppointmentBUS();

        // ── KPI ──────────────────────────────────────────────────────
        public int GetTotalPatients() => _patientBus.CountPatients();

        public int GetTodayAppointments()
        {
            if (!SchemaHelper.TableExists("Appointments")) return 0;
            try
            {
                object r = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Appointments WHERE CAST(AppointmentDate AS date) = CAST(GETDATE() AS date)");
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }

        public int GetWaitingPatients()
        {
            if (!SchemaHelper.TableExists("PatientQueues")) return 0;
            try
            {
                object r = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM PatientQueues WHERE Status = 'Waiting'");
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }

        public int GetTotalActiveEmployees()
        {
            var emps = _empBus.GetAll();
            int count = 0;
            foreach (var e in emps) if (e.Status == "Active") count++;
            return count;
        }

        public int GetLowStockMedicines()
        {
            if (!SchemaHelper.TableExists("Medicines")) return 0;
            try
            {
                object r = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Medicines WHERE Stock < 100");
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }

        // ── Today Appointments Table ──────────────────────────────────
        public DataTable GetTodayAppointmentTable()
        {
            if (!SchemaHelper.TableExists("Appointments"))
                return new DataTable();
            try
            {
                return DatabaseHelper.ExecuteQuery(@"
                    SELECT TOP 10
                        CONVERT(varchar(5), a.AppointmentDate, 108) AS GioKham,
                        ISNULL(p.Name, 'N/A')             AS BenhNhan,
                        ISNULL(e.FullName, 'N/A')          AS BacSi,
                        ISNULL(d.DepartmentName, 'N/A')    AS ChuyenKhoa,
                        a.Status
                    FROM Appointments a
                    LEFT JOIN Patients p    ON a.PatientID    = p.PatientID
                    LEFT JOIN Employees e   ON a.DoctorID     = e.EmployeeID
                    LEFT JOIN Departments d ON a.DepartmentID = d.DepartmentID
                    WHERE CAST(a.AppointmentDate AS date) = CAST(GETDATE() AS date)
                    ORDER BY a.AppointmentDate");
            }
            catch { return new DataTable(); }
        }

        // ── Low Stock Medicines ───────────────────────────────────────
        public DataTable GetLowStockMedicineList()
        {
            if (!SchemaHelper.TableExists("Medicines"))
                return new DataTable();
            try
            {
                return DatabaseHelper.ExecuteQuery(
                    "SELECT TOP 5 Name, Unit, Stock FROM Medicines WHERE Stock < 100 ORDER BY Stock ASC");
            }
            catch { return new DataTable(); }
        }

        // ── Employees by Department ───────────────────────────────────
        public DataTable GetEmployeesByDepartment()
        {
            try
            {
                return DatabaseHelper.ExecuteQuery(@"
                    SELECT TOP 4
                        d.DepartmentName,
                        COUNT(e.EmployeeID) AS EmpCount
                    FROM Departments d
                    LEFT JOIN Employees e ON e.DepartmentID = d.DepartmentID
                        AND e.Status = 'Active'
                    GROUP BY d.DepartmentID, d.DepartmentName
                    ORDER BY EmpCount DESC");
            }
            catch { return new DataTable(); }
        }

        // ── Queue Stats ───────────────────────────────────────────────
        public Dictionary<string, int> GetQueueStats()
        {
            var result = new Dictionary<string, int>
            {
                { "Waiting", 0 }, { "InProgress", 0 }, { "Done", 0 }, { "Cancelled", 0 }
            };
            if (!SchemaHelper.TableExists("PatientQueues")) return result;
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT Status, COUNT(*) AS Cnt FROM PatientQueues GROUP BY Status");
                foreach (DataRow row in dt.Rows)
                {
                    string key = row["Status"].ToString();
                    if (result.ContainsKey(key))
                        result[key] = Convert.ToInt32(row["Cnt"]);
                }
            }
            catch { }
            return result;
        }
    }
}
