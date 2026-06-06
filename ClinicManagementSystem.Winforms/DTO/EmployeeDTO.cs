namespace DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public int RoleID { get; set; }
        public int? DepartmentID { get; set; }
        public string Status { get; set; }
        public string StatusText => Status == "Active" ? "Đang làm việc" : "Nghỉ việc";
    }
}