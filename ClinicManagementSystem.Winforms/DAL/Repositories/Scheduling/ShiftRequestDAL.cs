using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class ShiftRequestDAL
    {
        public bool TableExists() => SchemaHelper.TableExists("ShiftRequests");

        public List<ShiftRequestDTO> GetAll()
        {
            if (!TableExists()) return new List<ShiftRequestDTO>();
            try
            {
                return Map(DatabaseHelper.ExecuteQuery(@"
                    SELECT sr.RequestID, sr.RequestCode,
                           sr.RequesterID, req.FullName AS RequesterName,
                           ISNULL(rreq.RoleName,'') AS RequesterRole,
                           sr.ReplacerID,  ISNULL(rep.FullName,'') AS ReplacerName,
                           ISNULL(rrep.RoleName,'') AS ReplacerRole,
                           sr.FromShiftID, ISNULL(sr.FromShiftCode,'') AS FromShiftCode,
                           sr.FromShiftDate, sr.FromShiftStart, sr.FromShiftEnd,
                           ISNULL(sr.FromDeptName,'') AS FromDeptName,
                           sr.ToShiftID,   ISNULL(sr.ToShiftCode,'') AS ToShiftCode,
                           sr.ToShiftDate, sr.ToShiftStart, sr.ToShiftEnd,
                           ISNULL(sr.ToDeptName,'') AS ToDeptName,
                           ISNULL(sr.Reason,'') AS Reason,
                           ISNULL(sr.AdminNote,'') AS AdminNote,
                           ISNULL(sr.ApprovedBy,'') AS ApprovedBy,
                           sr.ApprovedAt,
                           sr.Status, sr.CreatedAt
                    FROM ShiftRequests sr
                    LEFT JOIN Employees req  ON sr.RequesterID = req.EmployeeID
                    LEFT JOIN Roles rreq     ON req.RoleID = rreq.RoleID
                    LEFT JOIN Employees rep  ON sr.ReplacerID  = rep.EmployeeID
                    LEFT JOIN Roles rrep     ON rep.RoleID = rrep.RoleID
                    ORDER BY sr.CreatedAt DESC"));
            }
            catch { return new List<ShiftRequestDTO>(); }
        }

        public List<ShiftRequestDTO> GetByStatus(string status)
        {
            if (!TableExists()) return new List<ShiftRequestDTO>();
            try
            {
                return Map(DatabaseHelper.ExecuteQuery(@"
                    SELECT sr.RequestID, sr.RequestCode,
                           sr.RequesterID, req.FullName AS RequesterName,
                           ISNULL(rreq.RoleName,'') AS RequesterRole,
                           sr.ReplacerID, ISNULL(rep.FullName,'') AS ReplacerName,
                           ISNULL(rrep.RoleName,'') AS ReplacerRole,
                           sr.FromShiftID, ISNULL(sr.FromShiftCode,'') AS FromShiftCode,
                           sr.FromShiftDate, sr.FromShiftStart, sr.FromShiftEnd,
                           ISNULL(sr.FromDeptName,'') AS FromDeptName,
                           sr.ToShiftID, ISNULL(sr.ToShiftCode,'') AS ToShiftCode,
                           sr.ToShiftDate, sr.ToShiftStart, sr.ToShiftEnd,
                           ISNULL(sr.ToDeptName,'') AS ToDeptName,
                           ISNULL(sr.Reason,'') AS Reason,
                           ISNULL(sr.AdminNote,'') AS AdminNote,
                           ISNULL(sr.ApprovedBy,'') AS ApprovedBy,
                           sr.ApprovedAt, sr.Status, sr.CreatedAt
                    FROM ShiftRequests sr
                    LEFT JOIN Employees req ON sr.RequesterID = req.EmployeeID
                    LEFT JOIN Roles rreq    ON req.RoleID = rreq.RoleID
                    LEFT JOIN Employees rep ON sr.ReplacerID  = rep.EmployeeID
                    LEFT JOIN Roles rrep    ON rep.RoleID = rrep.RoleID
                    WHERE sr.Status = @Status
                    ORDER BY sr.CreatedAt DESC",
                    new[] { new SqlParameter("@Status", status) }));
            }
            catch { return new List<ShiftRequestDTO>(); }
        }

        public int CountByStatus(string status)
        {
            if (!TableExists()) return 0;
            try
            {
                object r = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM ShiftRequests WHERE Status=@S",
                    new[] { new SqlParameter("@S", status) });
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }

        public bool UpdateStatus(int requestId, string status, string approvedBy)
        {
            if (!TableExists()) return false;
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE ShiftRequests SET Status=@S, ApprovedBy=@A, ApprovedAt=GETDATE() WHERE RequestID=@ID",
                new[]
                {
                    new SqlParameter("@S",   status),
                    new SqlParameter("@A",   approvedBy ?? "Admin"),
                    new SqlParameter("@ID",  requestId)
                }) > 0;
        }

        private static List<ShiftRequestDTO> Map(DataTable dt)
        {
            var list = new List<ShiftRequestDTO>();
            foreach (DataRow row in dt.Rows)
            {
                var dto = new ShiftRequestDTO
                {
                    RequestID = Convert.ToInt32(row["RequestID"]),
                    RequestCode = row["RequestCode"].ToString(),
                    RequesterID = Convert.ToInt32(row["RequesterID"]),
                    RequesterName = row["RequesterName"].ToString(),
                    RequesterRole = row["RequesterRole"].ToString(),
                    ReplacerID = row["ReplacerID"] != DBNull.Value ? Convert.ToInt32(row["ReplacerID"]) : (int?)null,
                    ReplacerName = row["ReplacerName"].ToString(),
                    ReplacerRole = row["ReplacerRole"].ToString(),
                    FromShiftID = Convert.ToInt32(row["FromShiftID"]),
                    FromShiftCode = row["FromShiftCode"].ToString(),
                    FromShiftDate = Convert.ToDateTime(row["FromShiftDate"]),
                    FromShiftStart = row["FromShiftStart"] != DBNull.Value ? (TimeSpan)row["FromShiftStart"] : TimeSpan.Zero,
                    FromShiftEnd = row["FromShiftEnd"] != DBNull.Value ? (TimeSpan)row["FromShiftEnd"] : TimeSpan.Zero,
                    FromDeptName = row["FromDeptName"].ToString(),
                    ToShiftID = row["ToShiftID"] != DBNull.Value ? Convert.ToInt32(row["ToShiftID"]) : (int?)null,
                    ToShiftCode = row["ToShiftCode"].ToString(),
                    ToShiftDate = row["ToShiftDate"] != DBNull.Value ? Convert.ToDateTime(row["ToShiftDate"]) : DateTime.MinValue,
                    ToShiftStart = row["ToShiftStart"] != DBNull.Value ? (TimeSpan)row["ToShiftStart"] : TimeSpan.Zero,
                    ToShiftEnd = row["ToShiftEnd"] != DBNull.Value ? (TimeSpan)row["ToShiftEnd"] : TimeSpan.Zero,
                    ToDeptName = row["ToDeptName"].ToString(),
                    Reason = row["Reason"].ToString(),
                    AdminNote = row["AdminNote"].ToString(),
                    ApprovedBy = row["ApprovedBy"].ToString(),
                    ApprovedAt = row["ApprovedAt"] != DBNull.Value ? Convert.ToDateTime(row["ApprovedAt"]) : (DateTime?)null,
                    Status = row["Status"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                };
                list.Add(dto);
            }
            return list;
        }
    }
}