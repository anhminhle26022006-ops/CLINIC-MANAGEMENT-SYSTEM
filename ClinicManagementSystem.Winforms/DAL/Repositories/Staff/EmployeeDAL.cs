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
        public List<EmployeeDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Employees"))
                return new List<EmployeeDTO>();
            return Map(DatabaseHelper.ExecuteQuery(BaseSelect() + " ORDER BY e.FullName"));
        }

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (!SchemaHelper.TableExists("Employees"))
                return new List<EmployeeDTO>();
            return Map(DatabaseHelper.ExecuteQuery(
                BaseSelect() + " WHERE r.RoleName = @RoleName ORDER BY e.FullName",
                new[] { new SqlParameter("@RoleName", roleName) }));
        }

        public EmployeeDTO GetById(int employeeId)
        {
            if (!SchemaHelper.TableExists("Employees") || employeeId <= 0)
                return null;
            List<EmployeeDTO> list = Map(DatabaseHelper.ExecuteQuery(
                BaseSelect() + " WHERE e.EmployeeID = @EmployeeID",
                new[] { new SqlParameter("@EmployeeID", employeeId) }));
            return list.Count > 0 ? list[0] : null;
        }

        public EmployeeDTO FindByName(string fullName)
        {
            if (!SchemaHelper.TableExists("Employees") || string.IsNullOrWhiteSpace(fullName))
                return null;
            List<EmployeeDTO> list = Map(DatabaseHelper.ExecuteQuery(
                BaseSelect() + " WHERE e.FullName = @FullName",
                new[] { new SqlParameter("@FullName", fullName.Trim()) }));
            return list.Count > 0 ? list[0] : null;
        }

        public bool Exists(int employeeId)
        {
            if (!SchemaHelper.TableExists("Employees") || employeeId <= 0)
                return false;
            object result = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Employees WHERE EmployeeID = @EmployeeID",
                new[] { new SqlParameter("@EmployeeID", employeeId) });
            return Convert.ToInt32(result) > 0;
        }

        public bool Add(EmployeeDTO dto)
        {
            if (!SchemaHelper.TableExists("Employees")) return false;

            string query = @"
                INSERT INTO Employees
                    (EmployeeUUID, EmployeeCode, FullName, Gender, Phone, Email,
                     HireDate, RoleID, DepartmentID, Status)
                VALUES
                    (NEWID(), @Code, @FullName, @Gender, @Phone, @Email,
                     GETDATE(), @RoleID, @DeptID, 'Active')";

            // DepartmentID là int? - dùng HasValue để check
            object deptValue = (dto.DepartmentID.HasValue && dto.DepartmentID.Value > 0)
                               ? (object)dto.DepartmentID.Value
                               : DBNull.Value;

            SqlParameter[] parameters =
            {
                new SqlParameter("@Code",     "EMP" + DateTime.Now.ToString("yyMMddHHmmss")),
                new SqlParameter("@FullName", dto.FullName),
                new SqlParameter("@Gender",   dto.Gender != null ? dto.Gender : "Nam"),
                new SqlParameter("@Phone",    dto.Phone  != null ? dto.Phone  : ""),
                new SqlParameter("@Email",    dto.Email  != null ? (object)dto.Email : DBNull.Value),
                new SqlParameter("@RoleID",   dto.RoleID),
                new SqlParameter("@DeptID",   deptValue)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(EmployeeDTO dto)
        {
            if (!SchemaHelper.TableExists("Employees")) return false;

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

            object deptValue = (dto.DepartmentID.HasValue && dto.DepartmentID.Value > 0)
                               ? (object)dto.DepartmentID.Value
                               : DBNull.Value;

            SqlParameter[] parameters =
            {
                new SqlParameter("@FullName",   dto.FullName),
                new SqlParameter("@Gender",     dto.Gender != null ? dto.Gender : "Nam"),
                new SqlParameter("@Phone",      dto.Phone  != null ? dto.Phone  : ""),
                new SqlParameter("@Email",      dto.Email  != null ? (object)dto.Email : DBNull.Value),
                new SqlParameter("@RoleID",     dto.RoleID),
                new SqlParameter("@DeptID",     deptValue),
                new SqlParameter("@Status",     dto.Status != null ? dto.Status : "Active"),
                new SqlParameter("@EmployeeID", dto.EmployeeID)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int employeeId)
        {
            if (!SchemaHelper.TableExists("Employees")) return false;
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE Employees SET Status='Inactive' WHERE EmployeeID=@EmployeeID",
                new[] { new SqlParameter("@EmployeeID", employeeId) }) > 0;
        }

        private static string BaseSelect()
        {
            return @"
            SELECT e.EmployeeID,
                   e.EmployeeUUID,
                   e.EmployeeCode,
                   e.FullName,
                   e.DateOfBirth,
                   e.Gender,
                   e.CitizenId,
                   e.Address,
                   e.Phone,
                   e.Email,
                   e.HireDate,
                   e.Salary,
                   e.RoleID,
                   ISNULL(r.RoleName, '') AS RoleName,
                   e.DepartmentID,
                   ISNULL(d.DepartmentName, '') AS DepartmentName,
                   e.Status,
                   e.UserID
            FROM Employees e
            LEFT JOIN Roles r ON e.RoleID = r.RoleID
            LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID";
        }

        private static List<EmployeeDTO> Map(DataTable table)
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            foreach (DataRow row in table.Rows)
            {
                EmployeeDTO emp = new EmployeeDTO();
                emp.EmployeeID = Convert.ToInt32(row["EmployeeID"]);
                emp.EmployeeUUID = row["EmployeeUUID"] != DBNull.Value
                                   ? Guid.Parse(row["EmployeeUUID"].ToString()) : Guid.Empty;
                emp.EmployeeCode = row["EmployeeCode"].ToString();
                emp.FullName = row["FullName"].ToString();
                emp.DateOfBirth = row["DateOfBirth"] != DBNull.Value
                                   ? Convert.ToDateTime(row["DateOfBirth"]) : (DateTime?)null;
                emp.Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : "";
                emp.CitizenId = row["CitizenId"] != DBNull.Value ? row["CitizenId"].ToString() : "";
                emp.Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "";
                emp.Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "";
                emp.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "";
                emp.HireDate = row["HireDate"] != DBNull.Value
                                   ? Convert.ToDateTime(row["HireDate"]) : (DateTime?)null;
                emp.Salary = row["Salary"] != DBNull.Value
                                   ? Convert.ToDecimal(row["Salary"]) : (decimal?)null;
                emp.RoleID = row["RoleID"] != DBNull.Value ? Convert.ToInt32(row["RoleID"]) : 0;
                emp.RoleName = row["RoleName"].ToString();
                // DepartmentID là int? trong DTO
                emp.DepartmentID = row["DepartmentID"] != DBNull.Value
                                   ? Convert.ToInt32(row["DepartmentID"]) : (int?)null;
                emp.DepartmentName = row["DepartmentName"].ToString();
                emp.Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "";
                // UserID là int? trong DTO
                emp.UserID = row["UserID"] != DBNull.Value
                                   ? Convert.ToInt32(row["UserID"]) : (int?)null;
                list.Add(emp);
            }
            return list;
        }
    }
}