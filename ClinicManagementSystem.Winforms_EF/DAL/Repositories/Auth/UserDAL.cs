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

            SqlParameter[] parameters = new SqlParameter[]
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
                    Email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    EmployeeID = row.Table.Columns.Contains("EmployeeID") && row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                    EmployeeUUID = row.Table.Columns.Contains("EmployeeUUID") && row["EmployeeUUID"] != DBNull.Value ? Guid.Parse(row["EmployeeUUID"].ToString()) : Guid.Empty,
                    DepartmentID = row.Table.Columns.Contains("DepartmentID") && row["DepartmentID"] != DBNull.Value ? Convert.ToInt32(row["DepartmentID"]) : 0,
                    DepartmentName = row.Table.Columns.Contains("DepartmentName") && row["DepartmentName"] != DBNull.Value ? row["DepartmentName"].ToString() : ""
                };
            }
            return null;
        }

        public bool AddUser(UserDTO user)
        {
            string queryRole = "SELECT RoleID FROM Roles WHERE RoleName = @RoleName";
            SqlParameter[] roleParams = new SqlParameter[] { new SqlParameter("@RoleName", user.Role) };
            object roleIdObj = DatabaseHelper.ExecuteScalar(queryRole, roleParams);
            int roleId = roleIdObj != null ? Convert.ToInt32(roleIdObj) : 1;

            string query = "INSERT INTO Users (Username, PasswordHash, Email, RoleID, IsActive) VALUES (@Username, @Password, @Email, @RoleID, 1)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Email", (object)user.Email ?? DBNull.Value),
                new SqlParameter("@RoleID", roleId)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
            if (rows > 0)
            {
                try
                {
                    string selectUserId = "SELECT UserID FROM Users WHERE Username = @Username";
                    int newUserId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(selectUserId, new SqlParameter[] { new SqlParameter("@Username", user.Username) }));

                    string insertEmp = @"
                            INSERT INTO Employees (EmployeeCode, FullName, RoleID, DepartmentID, Status, UserID) 
                            VALUES (@EmpCode, @FullName, @RoleID, 
                                    (SELECT TOP 1 DepartmentID FROM Departments), 
                                    'Active', @UserID)";
                    SqlParameter[] empParams = new SqlParameter[]
                    {
                        new SqlParameter("@EmpCode", "EMP_" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper()),
                        new SqlParameter("@FullName", user.Name),
                        new SqlParameter("@RoleID", roleId),
                        new SqlParameter("@UserID", newUserId)
                    };
                    DatabaseHelper.ExecuteNonQuery(insertEmp, empParams);
                }
                catch { }
                return true;
            }
            return false;
        }
    }
}

