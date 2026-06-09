using System;

namespace DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string FullName
        {
            get => Name;
            set => Name = value;
        }
        public string Role { get; set; }
        public string RoleName
        {
            get => Role;
            set => Role = value;
        }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public int EmployeeID { get; set; }
        public Guid EmployeeUUID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}

