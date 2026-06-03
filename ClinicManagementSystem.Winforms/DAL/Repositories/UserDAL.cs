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
            string query;
            // Check if Roles table exists to determine database version
            string checkTableQuery = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U')";
            int tableExists = 0;
            try
            {
                tableExists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkTableQuery));
            }
            catch { }

            if (tableExists > 0)
            {
                // New CMS database schema
                query = @"
                    SELECT u.UserID, u.Username, u.PasswordHash AS [Password], u.Email, r.RoleName AS [Role], COALESCE(e.FullName, u.Username) AS [Name]
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleID = r.RoleID
                    LEFT JOIN Employees e ON u.UserID = e.UserID
                    WHERE u.Username = @Username AND u.PasswordHash = @Password";
            }
            else
            {
                // Old HealthCareDB schema
                query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            }

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
                    Email = row.Table.Columns.Contains("Email") && row["Email"] != DBNull.Value ? row["Email"].ToString() : ""
                };
            }
            return null;
        }

        public bool AddUser(UserDTO user)
        {
            string checkTableQuery = "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U')";
            int tableExists = 0;
            try
            {
                tableExists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkTableQuery));
            }
            catch { }

            if (tableExists > 0)
            {
                // New CMS database schema
                string queryRole = "SELECT RoleID FROM Roles WHERE RoleName = @RoleName";
                SqlParameter[] roleParams = new SqlParameter[] { new SqlParameter("@RoleName", user.Role) };
                object roleIdObj = DatabaseHelper.ExecuteScalar(queryRole, roleParams);
                int roleId = 0;
                if (roleIdObj != null)
                {
                    roleId = Convert.ToInt32(roleIdObj);
                }
                else
                {
                    // Default role
                    roleId = 1;
                }

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
            else
            {
                // Old HealthCareDB schema
                string query = "INSERT INTO Users (Username, Password, Name, Role, Email) VALUES (@Username, @Password, @Name, @Role, @Email)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", user.Username),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@Name", user.Name),
                    new SqlParameter("@Role", user.Role),
                    new SqlParameter("@Email", (object)user.Email ?? DBNull.Value)
                };

                return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
            }
        }
    }
}

