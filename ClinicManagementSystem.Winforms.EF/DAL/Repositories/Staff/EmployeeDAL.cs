using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly CMSDbContext _context;
        public EmployeeDAL(CMSDbContext context) => _context = context;
        public Task<List<ApiEmployeeDTO>> GetAllAsync()
        {
            return Task.FromResult(GetAll().Select(ToApi).ToList());
        }

        public Task<ApiEmployeeDTO> GetByCodeAsync(string code)
        {
            EmployeeDTO employee = GetAll()
                .FirstOrDefault(item => string.Equals(item.EmployeeCode, code, StringComparison.OrdinalIgnoreCase));
            return Task.FromResult(employee == null ? null : ToApi(employee));
        }

        public Task<int?> GetIdByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || !SchemaHelper.TableExists("Employees"))
            {
                return Task.FromResult<int?>(null);
            }

            object result = DatabaseHelper.ExecuteScalar(
                "SELECT EmployeeID FROM Employees WHERE EmployeeCode = @EmployeeCode",
                new[] { new SqlParameter("@EmployeeCode", code.Trim()) });
            return Task.FromResult(result == null ? (int?)null : Convert.ToInt32(result));
        }

        public Task<ApiEmployeeDTO> InsertAsync(ApiEmployeeDTO dto)
        {
            EmployeeDTO employee = FromApi(dto);
            if (employee.DepartmentID <= 0)
            {
                employee.DepartmentID = ResolveDepartmentId(dto?.DepartmentID, dto?.DepartmentName);
            }

            bool inserted = Add(employee);
            return inserted ? GetByCodeAsync(employee.EmployeeCode) : Task.FromResult<ApiEmployeeDTO>(null);
        }

        public Task<ApiEmployeeDTO> UpdateAsync(ApiEmployeeDTO dto)
        {
            int? employeeId = GetIdByCodeAsync(dto?.SyncCode).Result;
            if (!employeeId.HasValue)
            {
                return Task.FromResult<ApiEmployeeDTO>(null);
            }

            EmployeeDTO existing = GetById(employeeId.Value);
            if (existing == null)
            {
                return Task.FromResult<ApiEmployeeDTO>(null);
            }

            EmployeeDTO employee = FromApi(dto);
            employee.EmployeeID = existing.EmployeeID;
            employee.EmployeeCode = existing.EmployeeCode;
            employee.EmployeeUUID = existing.EmployeeUUID;
            employee.UserID = existing.UserID;
            employee.DepartmentID = employee.DepartmentID > 0
                ? employee.DepartmentID
                : ResolveDepartmentId(dto?.DepartmentID, dto?.DepartmentName);
            if (employee.DepartmentID <= 0)
            {
                employee.DepartmentID = existing.DepartmentID;
            }

            bool updated = UpdateBasic(employee);
            return updated ? GetByCodeAsync(existing.EmployeeCode) : Task.FromResult<ApiEmployeeDTO>(null);
        }

        public Task UpsertAsync(ApiEmployeeDTO dto)
        {
            return UpsertInternalAsync(dto);
        }

        private async Task UpsertInternalAsync(ApiEmployeeDTO dto)
        {
            int? existingId = await GetIdByCodeAsync(dto?.SyncCode);
            if (existingId.HasValue)
            {
                await UpdateAsync(dto);
                return;
            }

            await InsertAsync(dto);
        }

        private static ApiEmployeeDTO ToApi(EmployeeDTO employee)
        {
            return new ApiEmployeeDTO
            {
                EmployeeId = employee.EmployeeUUID == Guid.Empty ? (Guid?)null : employee.EmployeeUUID,
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullName,
                RoleName = employee.RoleName,
                DepartmentID = employee.DepartmentID > 0 ? employee.DepartmentID : (int?)null,
                DepartmentName = employee.DepartmentName,
                Phone = employee.Phone,
                Status = employee.Status
            };
        }

        private static EmployeeDTO FromApi(ApiEmployeeDTO dto)
        {
            return new EmployeeDTO
            {
                EmployeeUUID = dto?.SyncUuid ?? Guid.Empty,
                EmployeeCode = dto?.SyncCode,
                FullName = dto?.FullName,
                RoleName = dto?.RoleName,
                DepartmentID = dto?.DepartmentID ?? 0,
                DepartmentName = dto?.DepartmentName,
                Phone = dto?.Phone,
                Status = string.IsNullOrWhiteSpace(dto?.Status) ? "Active" : dto.Status
            };
        }

        private static int ResolveDepartmentId(int? departmentId, string departmentName)
        {
            if (departmentId.HasValue && departmentId.Value > 0)
            {
                object exists = DatabaseHelper.ExecuteScalar(
                    "SELECT DepartmentID FROM Departments WHERE DepartmentID = @DepartmentID",
                    new[] { new SqlParameter("@DepartmentID", departmentId.Value) });
                if (exists != null)
                {
                    return departmentId.Value;
                }
            }

            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                object byName = DatabaseHelper.ExecuteScalar(
                    "SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName",
                    new[] { new SqlParameter("@DepartmentName", departmentName.Trim()) });
                if (byName != null)
                {
                    return Convert.ToInt32(byName);
                }
            }

            object fallback = DatabaseHelper.ExecuteScalar("SELECT TOP 1 DepartmentID FROM Departments ORDER BY DepartmentID");
            return fallback == null ? 0 : Convert.ToInt32(fallback);
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

        public bool Delete(int id)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            SqlParameter[] parameters = {
                new SqlParameter("@EmployeeID", id)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Add(EmployeeDTO employee)
        {
            if (!SchemaHelper.TableExists("Employees"))
            {
                return false;
            }

            int roleId = employee.RoleID;
            if (roleId <= 0 && !string.IsNullOrWhiteSpace(employee.RoleName))
            {
                object roleIdObj = DatabaseHelper.ExecuteScalar(
                    "SELECT RoleID FROM Roles WHERE RoleName = @RoleName",
                    new[] { new SqlParameter("@RoleName", employee.RoleName.Trim()) });
                roleId = roleIdObj == null ? 0 : Convert.ToInt32(roleIdObj);
            }

            if (roleId <= 0 || employee.DepartmentID <= 0)
            {
                return false;
            }

            string code = string.IsNullOrWhiteSpace(employee.EmployeeCode)
                ? "EMP" + DateTime.Now.ToString("yyyyMMddHHmmss")
                : employee.EmployeeCode.Trim();

            string query = @"
                INSERT INTO Employees
                (
                    EmployeeCode,
                    FullName,
                    DateOfBirth,
                    Gender,
                    CitizenId,
                    Address,
                    Phone,
                    Email,
                    HireDate,
                    Salary,
                    RoleID,
                    DepartmentID,
                    Status,
                    UserID
                )
                VALUES
                (
                    @EmployeeCode,
                    @FullName,
                    @DateOfBirth,
                    @Gender,
                    @CitizenId,
                    @Address,
                    @Phone,
                    @Email,
                    @HireDate,
                    @Salary,
                    @RoleID,
                    @DepartmentID,
                    @Status,
                    @UserID
                )";

            int rows = DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@EmployeeCode", code),
                new SqlParameter("@FullName", employee.FullName.Trim()),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth.HasValue ? (object)employee.DateOfBirth.Value.Date : DBNull.Value),
                new SqlParameter("@Gender", string.IsNullOrWhiteSpace(employee.Gender) ? DBNull.Value : (object)employee.Gender.Trim()),
                new SqlParameter("@CitizenId", string.IsNullOrWhiteSpace(employee.CitizenId) ? DBNull.Value : (object)employee.CitizenId.Trim()),
                new SqlParameter("@Address", string.IsNullOrWhiteSpace(employee.Address) ? DBNull.Value : (object)employee.Address.Trim()),
                new SqlParameter("@Phone", string.IsNullOrWhiteSpace(employee.Phone) ? DBNull.Value : (object)employee.Phone.Trim()),
                new SqlParameter("@Email", string.IsNullOrWhiteSpace(employee.Email) ? DBNull.Value : (object)employee.Email.Trim()),
                new SqlParameter("@HireDate", employee.HireDate.HasValue ? (object)employee.HireDate.Value.Date : DateTime.Today),
                new SqlParameter("@Salary", employee.Salary.HasValue ? (object)employee.Salary.Value : DBNull.Value),
                new SqlParameter("@RoleID", roleId),
                new SqlParameter("@DepartmentID", employee.DepartmentID),
                new SqlParameter("@Status", string.IsNullOrWhiteSpace(employee.Status) ? "Active" : employee.Status.Trim()),
                new SqlParameter("@UserID", employee.UserID.HasValue ? (object)employee.UserID.Value : DBNull.Value)
            });

            return rows > 0;
        }

        public bool UpdateBasic(EmployeeDTO employee)
        {
            int roleId = employee.RoleID;
            if (!string.IsNullOrWhiteSpace(employee.RoleName))
            {
                object roleIdObj = DatabaseHelper.ExecuteScalar(
                    "SELECT RoleID FROM Roles WHERE RoleName = @RoleName",
                    new[] { new SqlParameter("@RoleName", employee.RoleName.Trim()) });
                if (roleIdObj != null)
                {
                    roleId = Convert.ToInt32(roleIdObj);
                }
            }

            string query = @"
                UPDATE Employees
                SET FullName = @FullName,
                    RoleID = @RoleID,
                    DepartmentID = @DepartmentID,
                    Phone = @Phone,
                    Email = @Email,
                    Address = @Address,
                    Status = @Status
                WHERE EmployeeID = @EmployeeID";

            int rows = DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@FullName", employee.FullName),
                new SqlParameter("@RoleID", roleId),
                new SqlParameter("@DepartmentID", employee.DepartmentID),
                new SqlParameter("@Phone", string.IsNullOrWhiteSpace(employee.Phone) ? DBNull.Value : (object)employee.Phone),
                new SqlParameter("@Email", string.IsNullOrWhiteSpace(employee.Email) ? DBNull.Value : (object)employee.Email),
                new SqlParameter("@Address", string.IsNullOrWhiteSpace(employee.Address) ? DBNull.Value : (object)employee.Address),
                new SqlParameter("@Status", string.IsNullOrWhiteSpace(employee.Status) ? "Active" : employee.Status),
                new SqlParameter("@EmployeeID", employee.EmployeeID)
            });

            if (employee.UserID.HasValue)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Users SET Email = @Email, RoleID = @RoleID WHERE UserID = @UserID",
                    new[]
                    {
                        new SqlParameter("@Email", string.IsNullOrWhiteSpace(employee.Email) ? DBNull.Value : (object)employee.Email),
                        new SqlParameter("@RoleID", roleId),
                        new SqlParameter("@UserID", employee.UserID.Value)
                    });
            }

            return rows > 0;
        }

        public bool SetStatus(int id, string status)
        {
            int rows = DatabaseHelper.ExecuteNonQuery(
                "UPDATE Employees SET Status = @Status WHERE EmployeeID = @EmployeeID",
                new[]
                {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@EmployeeID", id)
                });
            return rows > 0;
        }
    }
}
