namespace CMS.Core.Session
{
    public static class UserSession
    {
        public static int UserID { get; private set; }

        public static int EmployeeID { get; private set; }

        public static Guid EmployeeUUID { get; private set; }

        public static int DepartmentID { get; private set; }

        public static string Username { get; private set; }

        public static string FullName { get; private set; }

        public static string RoleName { get; private set; }

        public static string DepartmentName { get; private set; }

        public static void Login(
            int userId,
            int employeeId,
            Guid employeeUuid,
            int departmentId,
            string username,
            string fullName,
            string roleName,
            string departmentName)
        {
            UserID = userId;
            EmployeeID = employeeId;
            EmployeeUUID = employeeUuid;
            DepartmentID = departmentId;

            Username = username;
            FullName = fullName;

            RoleName = roleName;
            DepartmentName = departmentName;
        }

        public static void Logout()
        {
            UserID = 0;
            EmployeeID = 0;
            DepartmentID = 0;

            Username = string.Empty;
            FullName = string.Empty;
            RoleName = string.Empty;
            DepartmentName = string.Empty;
        }
    }
}