using System;
using System.Collections.Generic;
using System.Data;
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
                && SchemaHelper.TableExists("Employees");
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

            string query = "INSERT INTO EmployeeShifts(EmployeeID, ShiftID, WorkDate) VALUES(@EmployeeID, @ShiftID, @WorkDate)";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@EmployeeID", shift.EmployeeID),
                new SqlParameter("@ShiftID", shift.ShiftID),
                new SqlParameter("@WorkDate", shift.WorkDate.Date)
            }) > 0;
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

        private List<EmployeeShiftDTO> GetFiltered(string whereClause, SqlParameter[] parameters, string orderBy)
        {
            if (!SupportsEmployeeShiftSchema())
            {
                return new List<EmployeeShiftDTO>();
            }

            string idColumn = "es.ID"; // bảng dùng cột ID
            string query = @"
                SELECT " + idColumn + @" AS EmployeeShiftID,
                       es.EmployeeID,
                       ISNULL(e.FullName, '') AS EmployeeName,
                       ISNULL(r.RoleName, '') AS RoleName,
                       es.ShiftID,
                       ISNULL(s.Name, '') AS ShiftName,
                       es.WorkDate,
                       ISNULL(s.StartTime, CAST('00:00:00' AS time)) AS StartTime,
                       ISNULL(s.EndTime, CAST('00:00:00' AS time)) AS EndTime,
                       e.DepartmentID,
                       ISNULL(d.DepartmentName, '') AS DepartmentName,
                       CAST('Approved' AS nvarchar(50)) AS Status,
                       ISNULL(es.Room, '') AS RoomName
                FROM EmployeeShifts es
                LEFT JOIN Employees e ON es.EmployeeID = e.EmployeeID
                LEFT JOIN Roles r ON e.RoleID = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                LEFT JOIN Shifts s ON es.ShiftID = s.ShiftID";

            if (!string.IsNullOrWhiteSpace(whereClause))
            {
                query += " WHERE " + whereClause;
            }

            query += string.IsNullOrWhiteSpace(orderBy)
                ? " ORDER BY es.WorkDate DESC, s.StartTime ASC, e.FullName ASC"
                : " ORDER BY " + orderBy;

            return Map(DatabaseHelper.ExecuteQuery(query, parameters));
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

                    WorkDate = row["WorkDate"] != DBNull.Value
        ? Convert.ToDateTime(row["WorkDate"])
        : DateTime.MinValue,

                    StartTime = row["StartTime"] != DBNull.Value
        ? (TimeSpan)row["StartTime"]
        : TimeSpan.Zero,

                    EndTime = row["EndTime"] != DBNull.Value
        ? (TimeSpan)row["EndTime"]
        : TimeSpan.Zero,

                    DepartmentID = row["DepartmentID"] != DBNull.Value
        ? Convert.ToInt32(row["DepartmentID"])
        : (int?)null,

                    DepartmentName = row["DepartmentName"].ToString(),

                    RoomName = row["RoomName"].ToString(),

                    Status = row["Status"].ToString()
                });
            }
            return list;
        }

        public EmployeeShiftDTO GetById(int employeeShiftId)
        {
            if (!SupportsEmployeeShiftSchema() || employeeShiftId <= 0) return null;
            string query = @"
                SELECT es.EmployeeShiftID, es.EmployeeID,
                       ISNULL(e.FullName,'') AS EmployeeName,
                       ISNULL(r.RoleName,'') AS RoleName,
                       ISNULL(d.DepartmentName,'') AS DepartmentName,
                       es.ShiftID,
                       ISNULL(ws.Name,'') AS ShiftName,
                       ISNULL(ws.StartTime,'00:00:00') AS StartTime,
                       ISNULL(ws.EndTime,'00:00:00') AS EndTime,
                       es.WorkDate,
                       ISNULL(es.Status,'') AS Status
                FROM EmployeeShifts es
                LEFT JOIN Employees e ON es.EmployeeID = e.EmployeeID
                LEFT JOIN Roles r ON e.RoleID = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                LEFT JOIN WorkShifts ws ON es.ShiftID = ws.ShiftID
                WHERE es.ID = @ID";
            var dt = DatabaseHelper.ExecuteQuery(query,
                new[] { new Microsoft.Data.SqlClient.SqlParameter("@ID", employeeShiftId) });
            if (dt.Rows.Count == 0) return null;
            var row = dt.Rows[0];
            return new EmployeeShiftDTO
            {
                EmployeeShiftID = System.Convert.ToInt32(row["EmployeeShiftID"]),
                EmployeeID = System.Convert.ToInt32(row["EmployeeID"]),
                EmployeeName = row["EmployeeName"].ToString(),
                RoleName = row["RoleName"].ToString(),
                DepartmentName = row["DepartmentName"].ToString(),
                ShiftID = System.Convert.ToInt32(row["ShiftID"]),
                ShiftName = row["ShiftName"].ToString(),
                StartTime = System.TimeSpan.Parse(row["StartTime"].ToString()),
                EndTime = System.TimeSpan.Parse(row["EndTime"].ToString()),
                WorkDate = System.Convert.ToDateTime(row["WorkDate"]),
                Status = row["Status"].ToString()
            };
        }

        public bool Update(EmployeeShiftDTO shift)
        {
            if (!SupportsEmployeeShiftSchema()) return false;
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE EmployeeShifts SET EmployeeID=@E, ShiftID=@S, WorkDate=@D WHERE ID=@ID",
                new[]
                {
                    new Microsoft.Data.SqlClient.SqlParameter("@E",  shift.EmployeeID),
                    new Microsoft.Data.SqlClient.SqlParameter("@S",  shift.ShiftID),
                    new Microsoft.Data.SqlClient.SqlParameter("@D",  shift.WorkDate.Date),
                    new Microsoft.Data.SqlClient.SqlParameter("@St", shift.Status ?? "Approved"),
                    new Microsoft.Data.SqlClient.SqlParameter("@ID", shift.EmployeeShiftID)
                }) > 0;
        }

        public bool Delete(int employeeShiftId)
        {
            if (!SupportsEmployeeShiftSchema()) return false;
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM EmployeeShifts WHERE ID=@ID",
                new[] { new Microsoft.Data.SqlClient.SqlParameter("@ID", employeeShiftId) }) > 0;
        }


    }
}