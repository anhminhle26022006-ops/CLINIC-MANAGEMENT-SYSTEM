using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;
using DAL.Interfaces;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class UserDAL : IUserDAL
    {
        public UserDTO Authenticate(
            string username,
            string password)
        {
            string query = @"
            SELECT
                u.UserID,
                u.Username,
                u.PasswordHash,
                u.Email,
                u.RoleID,
                u.IsActive,
                r.RoleName,
                e.FullName
            FROM Users u
            INNER JOIN Roles r
                ON u.RoleID = r.RoleID
            LEFT JOIN Employees e
                ON e.UserID = u.UserID
            WHERE
                u.Username = @Username
                AND u.PasswordHash = @Password
                AND u.IsActive = 1";

            SqlParameter[] parameters =
            {
                new("@Username", username),
                new("@Password", password)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new UserDTO
            {
                UserID = Convert.ToInt32(row["UserID"]),
                Username = row["Username"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                Email = row["Email"].ToString(),
                RoleID = Convert.ToInt32(row["RoleID"]),
                RoleName = row["RoleName"].ToString(),
                FullName = row["FullName"]?.ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"])
            };
        }

        public bool AddUser(UserDTO user)
        {
            string query = @"
            INSERT INTO Users
            (
                Username,
                PasswordHash,
                Email,
                RoleID,
                IsActive
            )
            VALUES
            (
                @Username,
                @PasswordHash,
                @Email,
                @RoleID,
                1
            )";

            SqlParameter[] parameters =
            {
                new("@Username", user.Username),
                new("@PasswordHash", user.PasswordHash),
                new("@Email", user.Email),
                new("@RoleID", user.RoleID)
            };

            return DatabaseHelper
                .ExecuteNonQuery(query, parameters) > 0;
        }
    }
}