namespace DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

        public Guid EmployeeUUID { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RoleID { get; set; }

        public int DepartmentID { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
