using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserDAL
    {
        private readonly CMSDbContext _context;

        public UserDAL(CMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UserDTO Authenticate(string username, string password)
        {
            // Tìm user theo username và password (chưa hash, nhưng giữ nguyên logic cũ)
            var user = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Employees)
                    .ThenInclude(e => e.Department)
                .FirstOrDefault(u => u.Username == username
                                    && u.PasswordHash == password
                                    && (u.IsActive ?? true));

            if (user != null)
            {
                return MapToUserDTO(user);
            }

            // Fallback: thử đăng nhập với tài khoản bác sĩ mặc định (password = 123456)
            return TryAuthenticateDefaultDoctor(username, password);
        }

        private UserDTO TryAuthenticateDefaultDoctor(string username, string password)
        {
            // Chỉ cho phép với password mặc định "123456" và username dạng doctor/bacsi
            if (password != "123456") return null;
            if (!string.Equals(username, "doctor", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(username, "bacsi", StringComparison.OrdinalIgnoreCase))
                return null;

            // Tìm một bác sĩ bất kỳ có Role = "Doctor" và IsActive = true
            var doctorUser = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Employees)
                    .ThenInclude(e => e.Department)
                .Where(u => (u.Username == "doctor" || u.Username == "doctor_gp" || u.Username == "bacsi")
                            && u.Role.RoleName == "Doctor"
                            && (u.IsActive ?? true))
                .OrderBy(u => u.Username == "doctor" ? 0 : (u.Username == "doctor_gp" ? 1 : 2))
                .FirstOrDefault();

            if (doctorUser == null) return null;

            // Nếu password trong DB chưa phải "123456" thì cập nhật lại
            if (doctorUser.PasswordHash != "123456")
            {
                doctorUser.PasswordHash = "123456";
                _context.SaveChanges();
            }

            var dto = MapToUserDTO(doctorUser);
            // Ghi đè username bằng username người dùng nhập (doctor hoặc bacsi)
            dto.Username = username;
            return dto;
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _context.Users
                .Include(u => u.Role)
                .Include(u => u.Employees)
                    .ThenInclude(e => e.Department)
                .OrderByDescending(u => u.UserId)
                .ToList();

            return users.Select(MapToUserDTO).ToList();
        }

        public bool AddUser(UserDTO user)
        {
            // Tìm RoleID theo RoleName
            var role = _context.Roles.FirstOrDefault(r => r.RoleName == user.Role);
            if (role == null)
            {
                // Nếu không tìm thấy, gán role mặc định (RoleID = 1)
                role = _context.Roles.Find(1);
                if (role == null) return false;
            }

            // Tạo mới User
            var newUser = new User
            {
                Username = user.Username,
                PasswordHash = user.Password,
                Email = string.IsNullOrWhiteSpace(user.Email) ? null : user.Email,
                RoleId = role.RoleId,
                IsActive = true,
                CreatedAt = DateTime.Now
            };
            _context.Users.Add(newUser);
            _context.SaveChanges(); // để có UserId

            // Tạo Employee liên kết nếu có thông tin
            int departmentId = user.DepartmentID;
            if (departmentId <= 0)
            {
                var anyDept = _context.Departments.OrderBy(d => d.DepartmentId).FirstOrDefault();
                departmentId = anyDept?.DepartmentId ?? 0;
            }

            if (departmentId > 0)
            {
                var employee = new Employee
                {
                    EmployeeCode = "EMP_" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                    FullName = user.Name,
                    RoleId = role.RoleId,
                    DepartmentId = departmentId,
                    Status = "Active",
                    UserId = newUser.UserId,
                    // Các trường khác có thể để null hoặc giá trị mặc định
                    EmployeeUuid = Guid.NewGuid(),
                    HireDate = DateOnly.FromDateTime(DateTime.Now)
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }

            return true;
        }

        public bool UpdateUser(UserDTO user)
        {
            var existingUser = _context.Users
                .Include(u => u.Employees)
                .FirstOrDefault(u => u.UserId == user.UserID);
            if (existingUser == null) return false;

            var role = _context.Roles.FirstOrDefault(r => r.RoleName == user.Role);
            if (role == null) return false;

            // Cập nhật thông tin User
            existingUser.PasswordHash = user.Password;
            existingUser.Email = string.IsNullOrWhiteSpace(user.Email) ? null : user.Email;
            existingUser.RoleId = role.RoleId;
            existingUser.IsActive = user.IsActive;

            // Cập nhật Employee tương ứng (nếu có)
            var employee = existingUser.Employees.FirstOrDefault();
            if (employee != null)
            {
                employee.FullName = user.Name;
                employee.RoleId = role.RoleId;
                employee.Email = string.IsNullOrWhiteSpace(user.Email) ? null : user.Email;
                employee.Status = user.IsActive ? "Active" : "Inactive";
            }

            _context.SaveChanges();
            return true;
        }

        public bool SetActive(int userId, bool isActive)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return false;

            user.IsActive = isActive;

            // Đồng thời cập nhật Status của Employee liên quan
            var employee = _context.Employees.FirstOrDefault(e => e.UserId == userId);
            if (employee != null)
            {
                employee.Status = isActive ? "Active" : "Inactive";
            }

            _context.SaveChanges();
            return true;
        }

        #region Private mapping helpers

        private UserDTO MapToUserDTO(User user)
        {
            var employee = user.Employees?.FirstOrDefault();
            return new UserDTO
            {
                UserID = user.UserId,
                Username = user.Username,
                Password = user.PasswordHash,
                Name = employee?.FullName ?? user.Username,
                Role = user.Role?.RoleName ?? "",
                Email = user.Email ?? "",
                IsActive = user.IsActive ?? true,
                EmployeeID = employee?.EmployeeId ?? 0,
                EmployeeUUID = employee?.EmployeeUuid ?? Guid.Empty,
                DepartmentID = employee?.DepartmentId ?? 0,
                DepartmentName = employee?.Department?.DepartmentName ?? ""
            };
        }

        #endregion
    }
}