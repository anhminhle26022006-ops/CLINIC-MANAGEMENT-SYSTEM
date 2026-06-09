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
        public Task<List<ApiEmployeeDTO>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiEmployeeDTO> GetByCodeAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<int?> GetIdByCodeAsync(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiEmployeeDTO> InsertAsync(ApiEmployeeDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiEmployeeDTO> UpdateAsync(ApiEmployeeDTO dto)
        {
            throw new System.NotImplementedException();
        }

        public Task UpsertAsync(ApiEmployeeDTO dto)
        {
            throw new System.NotImplementedException();
        }
        public List<EmployeeDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Employees"))
            {
                return new List<EmployeeDTO>();
            }

            string query = BaseSelect() + " ORDER BY e.FullName";
            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (!SchemaHelper.TableExists("Employees"))
            {
                return new List<EmployeeDTO>();
            }

            string query = BaseSelect() + " WHERE r.RoleName = @RoleName ORDER BY e.FullName";
            return Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@RoleName", roleName)
            }));
        }

        public EmployeeDTO GetById(int employeeId)
        {
            if (!SchemaHelper.TableExists("Employees") || employeeId <= 0)
            {
                return null;
            }

            string query = BaseSelect() + " WHERE e.EmployeeID = @EmployeeID";
            List<EmployeeDTO> list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            }));
            return list.Count > 0 ? list[0] : null;
        }

        public EmployeeDTO FindByName(string fullName)
        {
            if (!SchemaHelper.TableExists("Employees") || string.IsNullOrWhiteSpace(fullName))
            {
                return null;
            }

            string query = BaseSelect() + " WHERE e.FullName = @FullName";
            List<EmployeeDTO> list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@FullName", fullName.Trim())
            }));
            return list.Count > 0 ? list[0] : null;
        }

        public bool Exists(int employeeId)
        {
            if (!SchemaHelper.TableExists("Employees") || employeeId <= 0)
            {
                return false;
            }

            object result = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Employees WHERE EmployeeID = @EmployeeID",
                new[] { new SqlParameter("@EmployeeID", employeeId) });
            return Convert.ToInt32(result) > 0;
        }
        public bool Insert(EmployeeDTO emp)
        {
            string query = @"
        INSERT INTO Employees 
            (EmployeeCode, FullName, DateOfBirth, Gender, CitizenId, 
             Address, Phone, Email, HireDate, Salary, RoleID, DepartmentID, Status)
        VALUES 
            (@EmployeeCode, @FullName, @DateOfBirth, @Gender, @CitizenId,
             @Address, @Phone, @Email, @HireDate, @Salary, @RoleID, @DepartmentID, @Status)";

            SqlParameter[] parameters =
            {
        new("@EmployeeCode",  emp.EmployeeCode),
        new("@FullName",      emp.FullName),
        new("@DateOfBirth",   (object)emp.DateOfBirth ?? DBNull.Value),
        new("@Gender",        (object)emp.Gender      ?? DBNull.Value),
        new("@CitizenId",     (object)emp.CitizenId   ?? DBNull.Value),
        new("@Address",       (object)emp.Address     ?? DBNull.Value),
        new("@Phone",         (object)emp.Phone       ?? DBNull.Value),
        new("@Email",         (object)emp.Email       ?? DBNull.Value),
        new("@HireDate",      (object)emp.HireDate    ?? DBNull.Value),
        new("@Salary",        (object)emp.Salary      ?? DBNull.Value),
        new("@RoleID",        emp.RoleID),
        new("@DepartmentID",  emp.DepartmentID),
        new("@Status",        emp.Status ?? "Active")
    };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Update(EmployeeDTO emp)
        {
            string query = @"
        UPDATE Employees SET
            FullName     = @FullName,
            DateOfBirth  = @DateOfBirth,
            Gender       = @Gender,
            CitizenId    = @CitizenId,
            Address      = @Address,
            Phone        = @Phone,
            Email        = @Email,
            HireDate     = @HireDate,
            Salary       = @Salary,
            RoleID       = @RoleID,
            DepartmentID = @DepartmentID,
            Status       = @Status
        WHERE EmployeeID = @EmployeeID";

            SqlParameter[] parameters =
            {
        new("@EmployeeID",    emp.EmployeeID),
        new("@FullName",      emp.FullName),
        new("@DateOfBirth",   (object)emp.DateOfBirth ?? DBNull.Value),
        new("@Gender",        (object)emp.Gender      ?? DBNull.Value),
        new("@CitizenId",     (object)emp.CitizenId   ?? DBNull.Value),
        new("@Address",       (object)emp.Address     ?? DBNull.Value),
        new("@Phone",         (object)emp.Phone       ?? DBNull.Value),
        new("@Email",         (object)emp.Email       ?? DBNull.Value),
        new("@HireDate",      (object)emp.HireDate    ?? DBNull.Value),
        new("@Salary",        (object)emp.Salary      ?? DBNull.Value),
        new("@RoleID",        emp.RoleID),
        new("@DepartmentID",  emp.DepartmentID),
        new("@Status",        emp.Status ?? "Active")
    };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Delete(int employeeId)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
        new SqlParameter("@EmployeeID", employeeId)
    }) > 0;
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
                list.Add(new EmployeeDTO
                {
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    EmployeeUUID = row["EmployeeUUID"] != DBNull.Value ? Guid.Parse(row["EmployeeUUID"].ToString()) : Guid.Empty,
                    EmployeeCode = row["EmployeeCode"].ToString(),
                    FullName = row["FullName"].ToString(),
                    DateOfBirth = row["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(row["DateOfBirth"]) : (DateTime?)null,
                    Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : "",
                    CitizenId = row["CitizenId"] != DBNull.Value ? row["CitizenId"].ToString() : "",
                    Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : "",
                    HireDate = row["HireDate"] != DBNull.Value ? Convert.ToDateTime(row["HireDate"]) : (DateTime?)null,
                    Salary = row["Salary"] != DBNull.Value ? Convert.ToDecimal(row["Salary"]) : (decimal?)null,
                    RoleID = row["RoleID"] != DBNull.Value ? Convert.ToInt32(row["RoleID"]) : 0,
                    RoleName = row["RoleName"].ToString(),
                    DepartmentID = row["DepartmentID"] != DBNull.Value ? Convert.ToInt32(row["DepartmentID"]) : 0,
                    DepartmentName = row["DepartmentName"].ToString(),
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "",
                    UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : (int?)null
                });
            }
            return list;
        }
    }
}
