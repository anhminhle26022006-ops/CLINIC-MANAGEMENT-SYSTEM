namespace Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string CitizenId { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string DepartmentId { get; set; }

        public string RoleId { get; set; }

        public string Status { get; set; }

        public virtual int GetAge()
        {
            var age = DateTime.Now.Year - DateOfBirth.Year;

            if (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear)
                age--;

            return age;
        }
    }
}