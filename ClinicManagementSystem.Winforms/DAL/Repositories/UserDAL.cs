using System;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class UserDAL
    {
        public UserDTO Authenticate(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
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

