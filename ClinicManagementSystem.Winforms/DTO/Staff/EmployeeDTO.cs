using System;

namespace DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public Guid EmployeeUUID { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CitizenId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
        public int? UserID { get; set; }

        public string StatusText => Status == "Active" ? "Đang làm việc" : "Nghỉ việc";
    }
}