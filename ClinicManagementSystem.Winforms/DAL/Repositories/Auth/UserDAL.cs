using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class UserDAL
    {
        public UserDTO Authenticate(string username, string password)
        {
            string query = @"
                SELECT u.UserID, u.Username, u.PasswordHash AS [Password], u.Email, r.RoleName AS [Role],
                       COALESCE(e.FullName, u.Username) AS [Name],
                       ISNULL(e.EmployeeID, 0) AS EmployeeID,
                       ISNULL(e.EmployeeUUID, '00000000-0000-0000-0000-000000000000') AS EmployeeUUID,
                       ISNULL(e.DepartmentID, 0) AS DepartmentID,
                       ISNULL(d.DepartmentName, '') AS DepartmentName
                FROM Users u
                INNER JOIN Roles r ON u.RoleID = r.RoleID
                LEFT JOIN Employees e ON u.UserID = e.UserID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                WHERE u.Username = @Username AND u.PasswordHash = @Password
                  AND ISNULL(u.IsActive, 1) = 1";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new UserDTO
                {
                    UserID = Convert.ToInt32(row["UserID"]),
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Name = row["Name"].ToString(),
                    Role = row["Role"].ToString(),
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                    EmployeeUUID = row["EmployeeUUID"] != DBNull.Value ? Guid.Parse(row["EmployeeUUID"].ToString()) : Guid.Empty,
                    DepartmentID = row["DepartmentID"] != DBNull.Value ? Convert.ToInt32(row["DepartmentID"]) : 0,
                    DepartmentName = row["DepartmentName"] != DBNull.Value ? row["DepartmentName"].ToString() : ""
                };
            }
            return null;
        }

        public bool AddUser(UserDTO user)
        {
            object roleIdObj = DatabaseHelper.ExecuteScalar(
                "SELECT RoleID FROM Roles WHERE RoleName = @RoleName",
                new[] { new SqlParameter("@RoleName", user.Role) });
            int roleId = roleIdObj != null ? Convert.ToInt32(roleIdObj) : 1;

            int rows = DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Users (Username, PasswordHash, Email, RoleID, IsActive, CreatedAt) VALUES (@Username, @Password, @Email, @RoleID, 1, GETDATE())",
                new SqlParameter[]
                {
                    new SqlParameter("@Username", user.Username),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Email",    (object)user.Email ?? DBNull.Value),
                    new SqlParameter("@RoleID",   roleId)
                });

            if (rows > 0)
            {
                try
                {
                    int newUserId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                        "SELECT UserID FROM Users WHERE Username = @Username",
                        new[] { new SqlParameter("@Username", user.Username) }));

                    DatabaseHelper.ExecuteNonQuery(@"
                        INSERT INTO Employees (EmployeeCode, FullName, RoleID, DepartmentID, Status, UserID)
                        VALUES (@EmpCode, @FullName, @RoleID,
                                (SELECT TOP 1 DepartmentID FROM Departments),
                                'Active', @UserID)",
                        new SqlParameter[]
                        {
                            new SqlParameter("@EmpCode",  "EMP_" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper()),
                            new SqlParameter("@FullName", user.Name),
                            new SqlParameter("@RoleID",   roleId),
                            new SqlParameter("@UserID",   newUserId)
                        });
                }
                catch { }
                return true;
            }
            return false;
        }

        public void UpdateUser(int userId, string email, string newPassword = null)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Users SET Email=@e WHERE UserID=@id",
                    new SqlParameter[]
                    {
                        new SqlParameter("@e",  string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                        new SqlParameter("@id", userId)
                    });
            else
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Users SET Email=@e, PasswordHash=@p WHERE UserID=@id",
                    new SqlParameter[]
                    {
                        new SqlParameter("@e",  string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                        new SqlParameter("@p",  newPassword),
                        new SqlParameter("@id", userId)
                    });
        }

        public void SetUserActive(int userId, bool isActive)
        {
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET IsActive=@s WHERE UserID=@id",
                new SqlParameter[]
                {
                    new SqlParameter("@s",  isActive ? 1 : 0),
                    new SqlParameter("@id", userId)
                });
        }
    }
}