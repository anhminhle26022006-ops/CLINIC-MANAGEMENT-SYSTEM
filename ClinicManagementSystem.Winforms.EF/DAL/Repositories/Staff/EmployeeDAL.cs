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
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<EmployeeDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .OrderBy(e => e.FullName)
                .ToList();
        }

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .Where(e => e.RoleName == roleName)
                .OrderBy(e => e.FullName)
                .ToList();
        }

        public EmployeeDTO GetById(int employeeId)
        {
            if (employeeId <= 0)
            {
                return null;
            }

            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .FirstOrDefault(e => e.EmployeeID == employeeId);
        }

        public EmployeeDTO FindByName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return null;
            }

            string name = fullName.Trim();
            using ClinicDbContext context = new ClinicDbContext();
            return BuildQuery(context)
                .FirstOrDefault(e => e.FullName == name);
        }

        public bool Exists(int employeeId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return employeeId > 0 && context.Employees.Any(e => e.EmployeeID == employeeId);
        }

        private static IQueryable<EmployeeDTO> BuildQuery(ClinicDbContext context)
        {
            return
                from employee in context.Employees.AsNoTracking()
                join role in context.Roles.AsNoTracking()
                    on employee.RoleID equals role.RoleID into roles
                from role in roles.DefaultIfEmpty()
                join department in context.Departments.AsNoTracking()
                    on employee.DepartmentID equals department.DepartmentID into departments
                from department in departments.DefaultIfEmpty()
                select new EmployeeDTO
                {
                    EmployeeID = employee.EmployeeID,
                    EmployeeUUID = employee.EmployeeUUID,
                    EmployeeCode = employee.EmployeeCode,
                    FullName = employee.FullName,
                    DateOfBirth = employee.DateOfBirth,
                    Gender = employee.Gender ?? "",
                    CitizenId = employee.CitizenId ?? "",
                    Address = employee.Address ?? "",
                    Phone = employee.Phone ?? "",
                    Email = employee.Email ?? "",
                    HireDate = employee.HireDate,
                    Salary = employee.Salary,
                    RoleID = employee.RoleID,
                    RoleName = role != null ? role.RoleName : "",
                    DepartmentID = employee.DepartmentID,
                    DepartmentName = department != null ? department.DepartmentName : "",
                    Status = employee.Status ?? "",
                    UserID = employee.UserID
                };
        }
    }
}
