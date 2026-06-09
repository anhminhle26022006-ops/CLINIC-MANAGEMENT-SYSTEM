using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Employee_RecepDAL
    {
        public List<EmployeeDTO> GetAllDoctors()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Employees
                    .AsNoTracking()
                    .Where(e => e.RoleID == 3 && e.Status == "Active")
                    .Select(e => new EmployeeDTO
                    {
                        EmployeeID = e.EmployeeID,
                        EmployeeCode = e.EmployeeCode,
                        FullName = e.FullName,
                        DepartmentID = e.DepartmentID,
                        RoleID = e.RoleID
                    })
                    .ToList();
            }
        }

        public List<DoctorScheduleDTO> GetDoctorSchedule(int doctorId, DateTime date)
        {
            using (var context = new ClinicDbContext())
            {
                var targetDate = date.Date;
                return context.DoctorSchedules
                    .AsNoTracking()
                    .Where(s => s.DoctorID == doctorId && s.WorkDate == targetDate)
                    .Select(s => new DoctorScheduleDTO
                    {
                        ScheduleID = s.ScheduleID,
                        DoctorID = s.DoctorID ?? 0,
                        WorkDate = s.WorkDate ?? DateTime.MinValue,
                        StartTime = s.StartTime ?? TimeSpan.Zero,
                        EndTime = s.EndTime ?? TimeSpan.Zero,
                        RoomID = s.RoomID ?? 0
                    })
                    .ToList();
            }
        }

        public List<EmployeeDTO> GetDoctorsByDepartment(int departmentId)
        {
            using (var context = new ClinicDbContext())
            {
                var doctorRoleId = context.Roles
                    .AsNoTracking()
                    .Where(r => r.RoleName == "Doctor")
                    .Select(r => r.RoleID)
                    .FirstOrDefault();

                if (doctorRoleId == 0) return new List<EmployeeDTO>();

                return context.Employees
                    .AsNoTracking()
                    .Where(e => e.DepartmentID == departmentId && e.RoleID == doctorRoleId)
                    .Select(e => new EmployeeDTO
                    {
                        EmployeeID = e.EmployeeID,
                        FullName = e.FullName
                    })
                    .ToList();
            }
        }

        public EmployeeDTO GetById(int employeeId)
        {
            using (var context = new ClinicDbContext())
            {
                var e = context.Employees
                    .AsNoTracking()
                    .FirstOrDefault(x => x.EmployeeID == employeeId);

                if (e == null) return null;

                return new EmployeeDTO
                {
                    EmployeeID = e.EmployeeID,
                    FullName = e.FullName
                };
            }
        }
    }
}
