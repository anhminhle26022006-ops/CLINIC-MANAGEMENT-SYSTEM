using System;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class UserDAL
    {
        public UserDTO Authenticate(string username, string password)
        {
            using ClinicDbContext context = new ClinicDbContext();

            return (
                from user in context.Users.AsNoTracking()
                join role in context.Roles.AsNoTracking()
                    on user.RoleID equals role.RoleID
                join employee in context.Employees.AsNoTracking()
                    on user.UserID equals employee.UserID into employees
                from employee in employees.DefaultIfEmpty()
                join department in context.Departments.AsNoTracking()
                    on employee.DepartmentID equals department.DepartmentID into departments
                from department in departments.DefaultIfEmpty()
                where user.Username == username
                    && user.PasswordHash == password
                    && user.IsActive
                select new UserDTO
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    Password = user.PasswordHash,
                    Name = employee != null ? employee.FullName : user.Username,
                    Role = role.RoleName,
                    Email = user.Email ?? "",
                    EmployeeID = employee != null ? employee.EmployeeID : 0,
                    EmployeeUUID = employee != null ? employee.EmployeeUUID : Guid.Empty,
                    DepartmentID = employee != null ? employee.DepartmentID : 0,
                    DepartmentName = department != null ? department.DepartmentName : ""
                }).FirstOrDefault();
        }

        public bool AddUser(UserDTO user)
        {
            using ClinicDbContext context = new ClinicDbContext();

            int roleId = context.Roles
                .Where(r => r.RoleName == user.Role)
                .Select(r => r.RoleID)
                .FirstOrDefault();

            if (roleId == 0)
            {
                roleId = context.Roles.Select(r => r.RoleID).FirstOrDefault();
            }

            User newUser = new User
            {
                Username = user.Username,
                PasswordHash = user.Password,
                Email = user.Email,
                RoleID = roleId == 0 ? null : roleId,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            int departmentId = context.Departments
                .Select(d => d.DepartmentID)
                .FirstOrDefault();

            if (roleId > 0 && departmentId > 0)
            {
                context.Employees.Add(new Employee
                {
                    EmployeeUUID = Guid.NewGuid(),
                    EmployeeCode = "EMP_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpperInvariant(),
                    FullName = string.IsNullOrWhiteSpace(user.Name) ? user.Username : user.Name,
                    RoleID = roleId,
                    DepartmentID = departmentId,
                    Status = "Active",
                    UserID = newUser.UserID
                });
                context.SaveChanges();
            }

            return true;
        }
    }
}

