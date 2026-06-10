using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeShiftDAL : IEmployeeShiftDAL
    {
        private readonly CMSDbContext _context;

        public EmployeeShiftDAL(CMSDbContext context)
        {
            _context = context;
        }

        public bool SupportsEmployeeShiftSchema()
        {
            return true; // EF Core DbSet tồn tại
        }

        public List<EmployeeShiftDTO> GetAll()
        {
            return QueryShifts().ToList();
        }

        public List<EmployeeShiftDTO> GetByEmployee(int employeeId)
        {
            return QueryShifts()
                .Where(es => es.EmployeeID == employeeId)
                .ToList();
        }

        public List<EmployeeShiftDTO> GetByDate(DateTime workDate)
        {
            var start = workDate.Date;                  // 00:00:00
            var end = start.AddDays(1);                 // 00:00:00 ngày hôm sau
            return QueryShifts()
                .Where(es => es.WorkDate >= start && es.WorkDate < end)
                .ToList();
        }

        public List<EmployeeShiftDTO> GetByRole(string roleName)
        {
            return QueryShifts()
                .Where(es => es.RoleName == roleName)
                .ToList();
        }

        public bool Add(EmployeeShiftDTO shift)
        {
            var entity = new EmployeeShift
            {
                EmployeeId = shift.EmployeeID,
                ShiftId = shift.ShiftID,
                WorkDate = DateOnly.FromDateTime(shift.WorkDate.Date)
            };
            _context.EmployeeShifts.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool HasConflict(int employeeId, DateTime workDate, int shiftId)
        {
            var date = DateOnly.FromDateTime(workDate.Date);
            return _context.EmployeeShifts
                .Any(es => es.EmployeeId == employeeId &&
                           es.ShiftId == shiftId &&
                           es.WorkDate == date);
        }

        public bool Update(EmployeeShiftDTO shift)
        {
            var existing = _context.EmployeeShifts.Find(shift.EmployeeShiftID);
            if (existing == null) return false;

            existing.EmployeeId = shift.EmployeeID;
            existing.ShiftId = shift.ShiftID;
            existing.WorkDate = DateOnly.FromDateTime(shift.WorkDate.Date);
            _context.Entry(existing).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool SetStatus(int employeeShiftId, string status)
        {
            // Model hiện tại không có cột Status, cần thêm vào model nếu muốn dùng
            throw new NotImplementedException("Status column does not exist in EmployeeShift entity.");
        }

        public int EnsureMonthlySchedule(string roleName, int employeeId, DateTime startDate, int dayCount)
        {
            const string sql = @"
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

            var parameters = new[]
            {
                new SqlParameter("@DayCount", dayCount),
                new SqlParameter("@StartDate", startDate.Date),
                new SqlParameter("@EmployeeID", employeeId),
                new SqlParameter("@RoleName", roleName ?? string.Empty)
            };
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        private IQueryable<EmployeeShiftDTO> QueryShifts()
        {
            return from es in _context.EmployeeShifts
                   join e in _context.Employees on es.EmployeeId equals e.EmployeeId into empJoin
                   from e in empJoin.DefaultIfEmpty()
                   join r in _context.Roles on e.RoleId equals r.RoleId into roleJoin
                   from r in roleJoin.DefaultIfEmpty()
                   join s in _context.Shifts on es.ShiftId equals s.ShiftId into shiftJoin
                   from s in shiftJoin.DefaultIfEmpty()
                   join d in _context.Departments on e.DepartmentId equals d.DepartmentId into deptJoin
                   from d in deptJoin.DefaultIfEmpty()
                   select new EmployeeShiftDTO
                   {
                       EmployeeShiftID = es.Id,
                       EmployeeID = e != null ? e.EmployeeId : 0,
                       EmployeeName = e != null ? e.FullName ?? "" : "",
                       RoleName = r != null ? r.RoleName ?? "" : "",
                       ShiftID = s != null ? s.ShiftId : 0,
                       ShiftName = s != null ? s.Name ?? "" : "",
                       WorkDate = es.WorkDate.HasValue ? es.WorkDate.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                       StartTime = s != null && s.StartTime.HasValue ? s.StartTime.Value.ToTimeSpan() : TimeSpan.Zero,
                       EndTime = s != null && s.EndTime.HasValue ? s.EndTime.Value.ToTimeSpan() : TimeSpan.Zero,
                       RoomID = null,
                       RoomCode = "",
                       DepartmentID = e != null ? e.DepartmentId : (int?)null,
                       DepartmentName = d != null ? d.DepartmentName ?? "" : "",
                       Status = "Approved"
                   };
        }
    }
}