using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class EmployeeDAL : IEmployeeDAL
    {
        // ── GET ALL ───────────────────────────────────────────────
        public List<EmployeeDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Employees"))
                return new List<EmployeeDTO>();

            string query = @"
                SELECT e.EmployeeID, e.EmployeeUUID, e.EmployeeCode,
                       e.FullName, e.DateOfBirth, e.Gender, e.CitizenId,
                       e.Address, e.Phone, e.Email, e.HireDate, e.Salary,
                       e.RoleID, e.DepartmentID, e.Status, e.UserID,
                       r.RoleName, d.DepartmentName
                FROM Employees e
                LEFT JOIN Roles r       ON e.RoleID       = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                ORDER BY e.EmployeeCode";

            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        // ── GET BY ID ─────────────────────────────────────────────
        public EmployeeDTO GetById(int employeeId)
        {
            if (!SchemaHelper.TableExists("Employees") || employeeId <= 0)
                return null;

            string query = @"
                SELECT e.EmployeeID, e.EmployeeUUID, e.EmployeeCode,
                       e.FullName, e.DateOfBirth, e.Gender, e.CitizenId,
                       e.Address, e.Phone, e.Email, e.HireDate, e.Salary,
                       e.RoleID, e.DepartmentID, e.Status, e.UserID,
                       r.RoleName, d.DepartmentName
                FROM Employees e
                LEFT JOIN Roles r       ON e.RoleID       = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                WHERE e.EmployeeID = @EmployeeID";

            var list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            }));
            return list.Count > 0 ? list[0] : null;
        }

        // ── EXISTS ────────────────────────────────────────────────
        public bool Exists(int employeeId)
        {
            return GetById(employeeId) != null;
        }

        // ── GET BY ROLE ───────────────────────────────────────────
        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (!SchemaHelper.TableExists("Employees") || string.IsNullOrWhiteSpace(roleName))
                return new List<EmployeeDTO>();

            string query = @"
                SELECT e.EmployeeID, e.EmployeeUUID, e.EmployeeCode,
                       e.FullName, e.DateOfBirth, e.Gender, e.CitizenId,
                       e.Address, e.Phone, e.Email, e.HireDate, e.Salary,
                       e.RoleID, e.DepartmentID, e.Status, e.UserID,
                       r.RoleName, d.DepartmentName
                FROM Employees e
                LEFT JOIN Roles r       ON e.RoleID       = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                WHERE r.RoleName = @RoleName
                ORDER BY e.EmployeeCode";

            return Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@RoleName", roleName)
            }));
        }

        // ── FIND BY NAME ──────────────────────────────────────────
        public EmployeeDTO FindByName(string fullName)
        {
            if (!SchemaHelper.TableExists("Employees") || string.IsNullOrWhiteSpace(fullName))
                return null;

            string query = @"
                SELECT e.EmployeeID, e.EmployeeUUID, e.EmployeeCode,
                       e.FullName, e.DateOfBirth, e.Gender, e.CitizenId,
                       e.Address, e.Phone, e.Email, e.HireDate, e.Salary,
                       e.RoleID, e.DepartmentID, e.Status, e.UserID,
                       r.RoleName, d.DepartmentName
                FROM Employees e
                LEFT JOIN Roles r       ON e.RoleID       = r.RoleID
                LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
                WHERE e.FullName LIKE @FullName";

            var list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@FullName", "%" + fullName.Trim() + "%")
            }));
            return list.Count > 0 ? list[0] : null;
        }

        // ── ADD ───────────────────────────────────────────────────
        public bool Add(EmployeeDTO employee)
        {
            string query = @"
                INSERT INTO Employees
                    (EmployeeUUID, EmployeeCode, FullName, DateOfBirth, Gender,
                     CitizenId, Address, Phone, Email, HireDate, Salary,
                     RoleID, DepartmentID, Status, UserID)
                VALUES
                    (NEWID(), @Code, @FullName, @DOB, @Gender,
                     @CitizenId, @Address, @Phone, @Email, @HireDate, @Salary,
                     @RoleID, @DeptID, @Status, @UserID)";

            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@Code",      GenerateCode()),
                new SqlParameter("@FullName",  employee.FullName),
                new SqlParameter("@DOB",       (object)employee.DateOfBirth   ?? DBNull.Value),
                new SqlParameter("@Gender",    employee.Gender  ?? "Nam"),
                new SqlParameter("@CitizenId", (object)employee.CitizenId     ?? DBNull.Value),
                new SqlParameter("@Address",   (object)employee.Address       ?? DBNull.Value),
                new SqlParameter("@Phone",     employee.Phone   ?? ""),
                new SqlParameter("@Email",     (object)employee.Email         ?? DBNull.Value),
                new SqlParameter("@HireDate",  (object)employee.HireDate      ?? DBNull.Value),
                new SqlParameter("@Salary",    (object)employee.Salary        ?? DBNull.Value),
                new SqlParameter("@RoleID",    employee.RoleID),
                new SqlParameter("@DeptID",    employee.DepartmentID > 0
                                               ? (object)employee.DepartmentID
                                               : DBNull.Value),
                new SqlParameter("@Status",    employee.Status ?? "Active"),
                new SqlParameter("@UserID",    (object)employee.UserID        ?? DBNull.Value)
            }) > 0;
        }

        // ── UPDATE ────────────────────────────────────────────────
        public bool Update(EmployeeDTO employee)
        {
            string query = @"
                UPDATE Employees SET
                    FullName     = @FullName,
                    DateOfBirth  = @DOB,
                    Gender       = @Gender,
                    CitizenId    = @CitizenId,
                    Address      = @Address,
                    Phone        = @Phone,
                    Email        = @Email,
                    Salary       = @Salary,
                    RoleID       = @RoleID,
                    DepartmentID = @DeptID,
                    Status       = @Status
                WHERE EmployeeID = @EmployeeID";

            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@FullName",   employee.FullName),
                new SqlParameter("@DOB",        (object)employee.DateOfBirth  ?? DBNull.Value),
                new SqlParameter("@Gender",     employee.Gender  ?? "Nam"),
                new SqlParameter("@CitizenId",  (object)employee.CitizenId    ?? DBNull.Value),
                new SqlParameter("@Address",    (object)employee.Address      ?? DBNull.Value),
                new SqlParameter("@Phone",      employee.Phone   ?? ""),
                new SqlParameter("@Email",      (object)employee.Email        ?? DBNull.Value),
                new SqlParameter("@Salary",     (object)employee.Salary       ?? DBNull.Value),
                new SqlParameter("@RoleID",     employee.RoleID),
                new SqlParameter("@DeptID",     employee.DepartmentID > 0
                                                ? (object)employee.DepartmentID
                                                : DBNull.Value),
                new SqlParameter("@Status",     employee.Status ?? "Active"),
                new SqlParameter("@EmployeeID", employee.EmployeeID)
            }) > 0;
        }

        // ── DELETE (soft delete) ──────────────────────────────────
        public bool Delete(int employeeId)
        {
            string query = "UPDATE Employees SET Status='Inactive' WHERE EmployeeID=@EmployeeID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            }) > 0;
        }

        // ── HELPERS ───────────────────────────────────────────────
        private static string GenerateCode()
        {
            return "EMP" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private static List<EmployeeDTO> Map(DataTable table)
        {
            var list = new List<EmployeeDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new EmployeeDTO
                {
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    EmployeeUUID = row["EmployeeUUID"] == DBNull.Value
                                     ? Guid.Empty
                                     : (Guid)row["EmployeeUUID"],
                    EmployeeCode = row["EmployeeCode"].ToString(),
                    FullName = row["FullName"].ToString(),
                    DateOfBirth = row["DateOfBirth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DateOfBirth"]),
                    Gender = row["Gender"].ToString(),
                    CitizenId = row["CitizenId"].ToString(),
                    Address = row["Address"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    HireDate = row["HireDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["HireDate"]),
                    Salary = row["Salary"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(row["Salary"]),
                    RoleID = row["RoleID"] == DBNull.Value ? 0 : Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString(),
                    DepartmentID = row["DepartmentID"] == DBNull.Value ? 0 : Convert.ToInt32(row["DepartmentID"]),
                    DepartmentName = row["DepartmentName"].ToString(),
                    Status = row["Status"].ToString(),
                    UserID = row["UserID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["UserID"])
                });
            }
            return list;
        }
    }
}