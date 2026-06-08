using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class EmployeeShiftDAL : IEmployeeShiftDAL
    {
        public bool SupportsEmployeeShiftSchema()
        {
            return true;
        }

        public List<EmployeeShiftDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .OrderByDescending(s => s.WorkDate)
                .ThenBy(s => s.StartTime)
                .ThenBy(s => s.EmployeeName)
                .ToList();
        }

        public List<EmployeeShiftDTO> GetByEmployee(int employeeId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .Where(s => s.EmployeeID == employeeId)
                .OrderByDescending(s => s.WorkDate)
                .ThenBy(s => s.StartTime)
                .ToList();
        }

        public List<EmployeeShiftDTO> GetByDate(DateTime workDate)
        {
            DateTime date = workDate.Date;
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .Where(s => s.WorkDate.Date == date)
                .OrderBy(s => s.StartTime)
                .ThenBy(s => s.EmployeeName)
                .ToList();
        }

        public List<EmployeeShiftDTO> GetByRole(string roleName)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .Where(s => s.RoleName == roleName)
                .OrderByDescending(s => s.WorkDate)
                .ThenBy(s => s.StartTime)
                .ThenBy(s => s.EmployeeName)
                .ToList();
        }

        public bool Add(EmployeeShiftDTO shift)
        {
            using ClinicDbContext context = new ClinicDbContext();
            context.EmployeeShifts.Add(new EmployeeShift
            {
                EmployeeID = shift.EmployeeID,
                ShiftID = shift.ShiftID,
                WorkDate = shift.WorkDate.Date
            });
            return context.SaveChanges() > 0;
        }

        public bool HasConflict(int employeeId, DateTime workDate, int shiftId)
        {
            DateTime date = workDate.Date;
            using ClinicDbContext context = new ClinicDbContext();
            return context.EmployeeShifts.Any(s =>
                s.EmployeeID == employeeId
                && s.ShiftID == shiftId
                && s.WorkDate.HasValue
                && s.WorkDate.Value.Date == date);
        }

        private static IQueryable<EmployeeShiftDTO> BuildQuery(ClinicDbContext context)
        {
            return
                from employeeShift in context.EmployeeShifts.AsNoTracking()
                join employee in context.Employees.AsNoTracking()
                    on employeeShift.EmployeeID equals employee.EmployeeID into employees
                from employee in employees.DefaultIfEmpty()
                join role in context.Roles.AsNoTracking()
                    on employee.RoleID equals role.RoleID into roles
                from role in roles.DefaultIfEmpty()
                join department in context.Departments.AsNoTracking()
                    on employee.DepartmentID equals department.DepartmentID into departments
                from department in departments.DefaultIfEmpty()
                join shift in context.Shifts.AsNoTracking()
                    on employeeShift.ShiftID equals shift.ShiftID into shifts
                from shift in shifts.DefaultIfEmpty()
                select new EmployeeShiftDTO
                {
                    EmployeeShiftID = employeeShift.ID,
                    EmployeeID = employeeShift.EmployeeID ?? 0,
                    EmployeeName = employee != null ? employee.FullName : "",
                    RoleName = role != null ? role.RoleName : "",
                    ShiftID = employeeShift.ShiftID ?? 0,
                    ShiftName = shift != null ? shift.Name : "",
                    WorkDate = employeeShift.WorkDate ?? DateTime.MinValue,
                    StartTime = shift != null && shift.StartTime.HasValue ? shift.StartTime.Value : TimeSpan.Zero,
                    EndTime = shift != null && shift.EndTime.HasValue ? shift.EndTime.Value : TimeSpan.Zero,
                    RoomID = null,
                    RoomCode = "",
                    DepartmentID = employee != null ? employee.DepartmentID : null,
                    DepartmentName = department != null ? department.DepartmentName : "",
                    Status = "Approved"
                };
        }
    }
}
