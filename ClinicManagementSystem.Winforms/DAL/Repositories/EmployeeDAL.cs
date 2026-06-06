using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;

namespace DAL.Repositories
{
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<EmployeeDTO> GetAll()
        {
            string query = @"
                SELECT e.EmployeeID, e.EmployeeCode, e.FullName, e.Gender,
                       e.Phone, e.Email, e.Status,
                       r.RoleName, d.DepartmentName,
                       e.RoleID, e.DepartmentID
                FROM Employees e
                LEFT JOIN Roles r ON e.RoleID = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                ORDER BY e.EmployeeCode";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            var list = new List<EmployeeDTO>();
            foreach (DataRow row in dt.Rows)
                list.Add(MapRow(row));
            return list;
        }

        public EmployeeDTO GetById(int employeeId)
        {
            string query = @"
                SELECT e.EmployeeID, e.EmployeeCode, e.FullName, e.Gender,
                       e.Phone, e.Email, e.Status,
                       r.RoleName, d.DepartmentName,
                       e.RoleID, e.DepartmentID
                FROM Employees e
                LEFT JOIN Roles r ON e.RoleID = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                WHERE e.EmployeeID = @EmployeeID";

            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
                return MapRow(dt.Rows[0]);
            return null;
        }

        public bool Add(EmployeeDTO employee)
        {
            string query = @"
                INSERT INTO Employees 
                    (EmployeeUUID, EmployeeCode, FullName, Gender, Phone, Email,
                     HireDate, RoleID, DepartmentID, Status)
                VALUES 
                    (NEWID(), @Code, @FullName, @Gender, @Phone, @Email,
                     GETDATE(), @RoleID, @DeptID, 'Active')";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code",     "EMP" + DateTime.Now.ToString("yyMMddHHmmss")),
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@Gender",   employee.Gender ?? "Nam"),
                new SqlParameter("@Phone",    employee.Phone ?? ""),
                new SqlParameter("@Email",    (object)employee.Email ?? DBNull.Value),
                new SqlParameter("@RoleID",   employee.RoleID),
                new SqlParameter("@DeptID",   employee.DepartmentID.HasValue
                                              ? (object)employee.DepartmentID.Value
                                              : DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(EmployeeDTO employee)
        {
            string query = @"
                UPDATE Employees SET
                    FullName     = @FullName,
                    Gender       = @Gender,
                    Phone        = @Phone,
                    Email        = @Email,
                    RoleID       = @RoleID,
                    DepartmentID = @DeptID,
                    Status       = @Status
                WHERE EmployeeID = @EmployeeID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@FullName",   employee.FullName),
                new SqlParameter("@Gender",     employee.Gender ?? "Nam"),
                new SqlParameter("@Phone",      employee.Phone ?? ""),
                new SqlParameter("@Email",      (object)employee.Email ?? DBNull.Value),
                new SqlParameter("@RoleID",     employee.RoleID),
                new SqlParameter("@DeptID",     employee.DepartmentID.HasValue
                                                ? (object)employee.DepartmentID.Value
                                                : DBNull.Value),
                new SqlParameter("@Status",     employee.Status ?? "Active"),
                new SqlParameter("@EmployeeID", employee.EmployeeID)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int employeeId)
        {
            string query = "UPDATE Employees SET Status='Inactive' WHERE EmployeeID=@EmployeeID";
            SqlParameter[] parameters = { new SqlParameter("@EmployeeID", employeeId) };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        private EmployeeDTO MapRow(DataRow row)
        {
            return new EmployeeDTO
            {
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                EmployeeCode = row["EmployeeCode"].ToString(),
                FullName = row["FullName"].ToString(),
                Gender = row["Gender"].ToString(),
                Phone = row["Phone"].ToString(),
                Email = row["Email"].ToString(),
                RoleName = row["RoleName"].ToString(),
                DepartmentName = row["DepartmentName"].ToString(),
                RoleID = row["RoleID"] == DBNull.Value ? 0 : Convert.ToInt32(row["RoleID"]),
                DepartmentID = row["DepartmentID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["DepartmentID"]),
                Status = row["Status"].ToString()
            };
        }
    }
}