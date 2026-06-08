using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class ApiSyncRepository
    {
        private readonly string supabaseUrl;
        private readonly string supabaseKey;
        private readonly string sheetDbPatientUrl;
        private readonly string sheetDbEmployeeUrl;
        private readonly JsonSerializerOptions jsonOptions;

        public ApiSyncRepository()
        {
            supabaseUrl = ReadSetting("ApiSyncSupabaseUrl", "https://swnbagptdoozwvcxfmqp.supabase.co").TrimEnd('/');
            supabaseKey = ReadSetting("ApiSyncSupabaseKey", "sb_publishable_0WsU65Jd6rTgCTHqA5-yng_5fn0Q9x0");
            sheetDbPatientUrl = WithSheetName(
                ReadSetting("ApiSyncSheetDbPatientUrl", "https://sheetdb.io/api/v1/bdiy5t2crif1p"),
                ReadSetting("ApiSyncSheetDbPatientSheet", "Patient"));
            sheetDbEmployeeUrl = WithSheetName(
                ReadSetting("ApiSyncSheetDbEmployeeUrl", "https://sheetdb.io/api/v1/jci04wz60pp1n"),
                ReadSetting("ApiSyncSheetDbEmployeeSheet", "Doctor"));

            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
                WriteIndented = true
            };
            jsonOptions.Converters.Add(new NullableGuidConverter());
            jsonOptions.Converters.Add(new FlexibleInt32Converter());
            jsonOptions.Converters.Add(new NullableInt32Converter());
        }

        public Task<List<ApiPatientDTO>> GetSupabasePatientsAsync()
        {
            return GetListAsync<ApiPatientDTO>($"{supabaseUrl}/rest/v1/patients?select=*", true, "GET SUPABASE PATIENTS");
        }

        public Task<List<ApiEmployeeDTO>> GetSupabaseEmployeesAsync()
        {
            return GetListAsync<ApiEmployeeDTO>($"{supabaseUrl}/rest/v1/employees?select=*", true, "GET SUPABASE EMPLOYEES");
        }

        public Task<List<ApiPatientDTO>> GetSheetPatientsAsync()
        {
            return GetListAsync<ApiPatientDTO>(sheetDbPatientUrl, false, "GET SHEETDB PATIENTS");
        }

        public Task<List<ApiEmployeeDTO>> GetSheetEmployeesAsync()
        {
            return GetListAsync<ApiEmployeeDTO>(sheetDbEmployeeUrl, false, "GET SHEETDB EMPLOYEES");
        }

        public Task<ApiPatientDTO> InsertSupabasePatientAsync(Dictionary<string, object> payload)
        {
            return PostJsonReturnOneAsync<ApiPatientDTO>($"{supabaseUrl}/rest/v1/patients", payload, true, "POST SHEET PATIENT -> SUPABASE");
        }

        public Task<ApiEmployeeDTO> InsertSupabaseEmployeeAsync(Dictionary<string, object> payload)
        {
            return PostJsonReturnOneAsync<ApiEmployeeDTO>($"{supabaseUrl}/rest/v1/employees", payload, true, "POST SHEET EMPLOYEE -> SUPABASE");
        }

        public async Task EnsureSupabaseDepartmentAsync(int? departmentId, string departmentName)
        {
            if (!departmentId.HasValue) return;

            string lookupUrl = $"{supabaseUrl}/rest/v1/departments?departmentid=eq.{departmentId.Value}&select=departmentid";
            using (var client = CreateClient(true))
            {
                var response = await client.GetAsync(lookupUrl);
                string responseText = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw BuildHttpException("GET SUPABASE DEPARTMENT", "GET", lookupUrl, null, response, responseText);
                }

                if (!string.IsNullOrWhiteSpace(responseText) && responseText.Trim() != "[]")
                {
                    return;
                }
            }

            var payload = new Dictionary<string, object>
            {
                ["departmentid"] = departmentId.Value,
                ["departmentname"] = string.IsNullOrWhiteSpace(departmentName) ? $"Khoa {departmentId.Value}" : departmentName.Trim()
            };
            await PostJsonAsync($"{supabaseUrl}/rest/v1/departments", payload, true, "POST SHEET DEPARTMENT -> SUPABASE");
        }

        public Task<bool> PatchPatientSheetUuidAsync(string patientCode, Guid patientUuid)
        {
            return PatchSheetByColumnAsync(sheetDbPatientUrl, "patientcode", patientCode, new Dictionary<string, object>
            {
                ["patientid"] = patientUuid.ToString()
            }, "PATCH PATIENT UUID BACK TO SHEET");
        }

        public Task<bool> PatchEmployeeSheetUuidAsync(string employeeCode, Guid employeeUuid)
        {
            var fields = new Dictionary<string, object>
            {
                ["employeeid"] = employeeUuid.ToString()
            };

            if (string.IsNullOrWhiteSpace(employeeCode))
            {
                return Task.FromResult(false);
            }

            return PatchSheetByColumnAsync(sheetDbEmployeeUrl, "employeecode", employeeCode, fields, "PATCH EMPLOYEE UUID BACK TO SHEET BY CODE");
        }

        public Task<bool> PatchSupabasePatientUuidByCodeAsync(string patientCode, Guid patientUuid)
        {
            return PatchSupabaseByColumnAsync($"{supabaseUrl}/rest/v1/patients", "patientcode", patientCode, new Dictionary<string, object>
            {
                ["patientid"] = patientUuid.ToString()
            }, "PATCH PATIENT UUID TO SUPABASE");
        }

        public Task<bool> PatchSupabaseEmployeeUuidByCodeAsync(string employeeCode, Guid employeeUuid)
        {
            return PatchSupabaseByColumnAsync($"{supabaseUrl}/rest/v1/employees", "employeecode", employeeCode, new Dictionary<string, object>
            {
                ["employeeid"] = employeeUuid.ToString()
            }, "PATCH EMPLOYEE UUID TO SUPABASE");
        }

        public Task<bool> InsertSheetPatientsAsync(List<Dictionary<string, object>> rows)
        {
            return PostJsonAsync(sheetDbPatientUrl, new Dictionary<string, object> { ["data"] = rows }, false, "POST SUPABASE PATIENTS -> SHEETDB");
        }

        public Task<bool> InsertSheetEmployeesAsync(List<Dictionary<string, object>> rows)
        {
            return PostJsonAsync(sheetDbEmployeeUrl, new Dictionary<string, object> { ["data"] = rows }, false, "POST SUPABASE EMPLOYEES -> SHEETDB");
        }

        public static bool IsNewSchema(SqlConnection conn)
        {
            string checkColumnQuery = "SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Patients]') AND name = 'Name'";
            using (var cmd = new SqlCommand(checkColumnQuery, conn))
            {
                try
                {
                    int nameColumnExists = Convert.ToInt32(cmd.ExecuteScalar());
                    return nameColumnExists == 0;
                }
                catch
                {
                    return true;
                }
            }
        }

        public async Task<ApiLocalUuidResultDTO> UpsertLocalPatientAsync(ApiPatientDTO patient)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                bool isNew = IsNewSchema(conn);
                await EnsureLocalPatientUuidSchemaAsync(conn);

                Guid uuid = patient.SyncUuid ?? Guid.NewGuid();
                bool generated = !patient.SyncUuid.HasValue;

                if (patient.SyncUuid.HasValue)
                {
                    int? existingId = await GetIdByUuidAsync(conn, "Patients", "PatientID", "PatientUUID", patient.SyncUuid.Value);
                    if (existingId.HasValue)
                    {
                        await UpdateLocalPatientAsync(conn, existingId.Value, patient, uuid, isNew);
                        return new ApiLocalUuidResultDTO { Uuid = uuid, Inserted = false, Generated = false };
                    }
                }

                LocalIdentity existingByCode = await GetPatientByCodeAsync(conn, patient.PatientCode);
                if (existingByCode != null)
                {
                    Guid finalUuid = patient.SyncUuid ?? existingByCode.Uuid ?? uuid;
                    await UpdateLocalPatientAsync(conn, existingByCode.Id, patient, finalUuid, isNew);
                    return new ApiLocalUuidResultDTO { Uuid = finalUuid, Inserted = false, Generated = !existingByCode.Uuid.HasValue && generated };
                }

                await InsertLocalPatientAsync(conn, patient, uuid, isNew);
                return new ApiLocalUuidResultDTO { Uuid = uuid, Inserted = true, Generated = generated };
            }
        }

        public async Task<ApiLocalUuidResultDTO> UpsertLocalEmployeeAsync(ApiEmployeeDTO employee)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                await EnsureLocalEmployeeUuidSchemaAsync(conn);

                Guid uuid = employee.SyncUuid ?? Guid.NewGuid();
                bool generated = !employee.SyncUuid.HasValue;

                if (employee.SyncUuid.HasValue)
                {
                    int? existingId = await GetIdByUuidAsync(conn, "Employees", "EmployeeID", "EmployeeUUID", employee.SyncUuid.Value);
                    if (existingId.HasValue)
                    {
                        await UpdateLocalEmployeeAsync(conn, existingId.Value, employee, uuid, true);
                        return new ApiLocalUuidResultDTO { Uuid = uuid, Inserted = false, Generated = false };
                    }
                }

                LocalIdentity existingByCode = null;
                if (!string.IsNullOrWhiteSpace(employee.SyncCode))
                {
                    existingByCode = await GetEmployeeByCodeAsync(conn, employee.SyncCode);
                }

                if (existingByCode != null)
                {
                    Guid finalUuid = employee.SyncUuid ?? existingByCode.Uuid ?? uuid;
                    await UpdateLocalEmployeeAsync(conn, existingByCode.Id, employee, finalUuid, true);
                    return new ApiLocalUuidResultDTO { Uuid = finalUuid, Inserted = false, Generated = !existingByCode.Uuid.HasValue && generated };
                }

                await InsertLocalEmployeeAsync(conn, employee, uuid, true);
                return new ApiLocalUuidResultDTO { Uuid = uuid, Inserted = true, Generated = generated };
            }
        }

        private static async Task EnsureLocalPatientUuidSchemaAsync(SqlConnection conn)
        {
            string alterSql = @"
IF COL_LENGTH('dbo.Patients', 'PatientUUID') IS NULL
BEGIN
    ALTER TABLE dbo.Patients ADD PatientUUID UNIQUEIDENTIFIER NULL;
END;";
            await ExecuteNonQueryAsync(conn, alterSql);

            string updateSql = "EXEC('UPDATE dbo.Patients SET PatientUUID = NEWID() WHERE PatientUUID IS NULL');";
            await ExecuteNonQueryAsync(conn, updateSql);

            string indexSql = @"
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'UQ_Patients_UUID'
      AND object_id = OBJECT_ID('dbo.Patients')
)
BEGIN
    EXEC('CREATE UNIQUE INDEX UQ_Patients_UUID ON dbo.Patients(PatientUUID) WHERE PatientUUID IS NOT NULL');
END;";
            await ExecuteNonQueryAsync(conn, indexSql);
        }

        private static async Task EnsureLocalEmployeeUuidSchemaAsync(SqlConnection conn)
        {
            string alterSql = @"
IF COL_LENGTH('dbo.Employees', 'EmployeeUUID') IS NULL
BEGIN
    ALTER TABLE dbo.Employees ADD EmployeeUUID UNIQUEIDENTIFIER NULL;
END;";
            await ExecuteNonQueryAsync(conn, alterSql);

            string updateSql = "EXEC('UPDATE dbo.Employees SET EmployeeUUID = NEWID() WHERE EmployeeUUID IS NULL');";
            await ExecuteNonQueryAsync(conn, updateSql);

            string indexSql = @"
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'UQ_Employees_UUID'
      AND object_id = OBJECT_ID('dbo.Employees')
)
BEGIN
    EXEC('CREATE UNIQUE INDEX UQ_Employees_UUID ON dbo.Employees(EmployeeUUID) WHERE EmployeeUUID IS NOT NULL');
END;";
            await ExecuteNonQueryAsync(conn, indexSql);

            await EnsureNullableEmployeeUniqueIndexAsync(conn, "CitizenId", "UX_Employees_CitizenId_NotNull");
            await EnsureNullableEmployeeUniqueIndexAsync(conn, "Email", "UX_Employees_Email_NotNull");
        }

        private static async Task<int?> GetIdByUuidAsync(SqlConnection conn, string tableName, string idColumn, string uuidColumn, Guid uuid)
        {
            string sql = $"SELECT {idColumn} FROM dbo.{tableName} WHERE {uuidColumn} = @Uuid";
            object value = await ExecuteScalarAsync(conn, sql, new SqlParameter("@Uuid", uuid));
            return value == null || value == DBNull.Value ? (int?)null : Convert.ToInt32(value);
        }

        private static async Task<LocalIdentity> GetPatientByCodeAsync(SqlConnection conn, string patientCode)
        {
            if (string.IsNullOrWhiteSpace(patientCode)) return null;

            string sql = "SELECT TOP 1 PatientID, PatientUUID FROM dbo.Patients WHERE PatientCode = @Code";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Code", patientCode.Trim());
                using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow))
                {
                    if (!await reader.ReadAsync()) return null;
                    return new LocalIdentity
                    {
                        Id = reader.GetInt32(0),
                        Uuid = reader.IsDBNull(1) ? (Guid?)null : reader.GetGuid(1)
                    };
                }
            }
        }

        private static async Task<LocalIdentity> GetEmployeeByCodeAsync(SqlConnection conn, string employeeCode)
        {
            if (string.IsNullOrWhiteSpace(employeeCode)) return null;

            string sql = "SELECT TOP 1 EmployeeID, EmployeeUUID FROM dbo.Employees WHERE EmployeeCode = @Code";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Code", employeeCode.Trim());
                using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow))
                {
                    if (!await reader.ReadAsync()) return null;
                    return new LocalIdentity
                    {
                        Id = reader.GetInt32(0),
                        Uuid = reader.IsDBNull(1) ? (Guid?)null : reader.GetGuid(1)
                    };
                }
            }
        }

        private static async Task<LocalIdentity> GetEmployeeByNameAsync(SqlConnection conn, string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return null;

            string sql = "SELECT TOP 1 EmployeeID, EmployeeUUID FROM dbo.Employees WHERE FullName = @Name";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", fullName.Trim());
                using (var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleRow))
                {
                    if (!await reader.ReadAsync()) return null;
                    return new LocalIdentity
                    {
                        Id = reader.GetInt32(0),
                        Uuid = reader.IsDBNull(1) ? (Guid?)null : reader.GetGuid(1)
                    };
                }
            }
        }

        private static async Task UpdateLocalPatientAsync(SqlConnection conn, int patientId, ApiPatientDTO patient, Guid uuid, bool isNewSchema)
        {
            if (isNewSchema)
            {
                string sql = @"
UPDATE dbo.Patients
SET PatientUUID = @PatientUUID,
    PatientCode = @PatientCode,
    FullName = @FullName,
    Gender = @Gender,
    DOB = @DOB,
    Phone = @Phone,
    Address = @Address,
    BloodType = @BloodType,
    Allergy = @Allergy
WHERE PatientID = @PatientID";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@PatientUUID", uuid),
                    new SqlParameter("@PatientCode", DbValue(patient.PatientCode)),
                    new SqlParameter("@FullName", DbValue(patient.FullName)),
                    new SqlParameter("@Gender", DbValue(patient.Gender)),
                    new SqlParameter("@DOB", DbDateValue(patient.DOB, required: false)),
                    new SqlParameter("@Phone", DbValue(patient.Phone)),
                    new SqlParameter("@Address", DbValue(patient.Address)),
                    new SqlParameter("@BloodType", DbValue(patient.BloodType)),
                    new SqlParameter("@Allergy", DbValue(patient.Allergy)),
                    new SqlParameter("@PatientID", patientId));
            }
            else
            {
                string sql = @"
UPDATE dbo.Patients
SET PatientUUID = @PatientUUID,
    PatientCode = @PatientCode,
    Name = @Name,
    BirthDate = @BirthDate,
    Gender = @Gender,
    Phone = @Phone,
    Address = @Address
WHERE PatientID = @PatientID";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@PatientUUID", uuid),
                    new SqlParameter("@PatientCode", DbRequiredValue(patient.PatientCode, "BN" + new Random().Next(10000, 99999))),
                    new SqlParameter("@Name", DbRequiredValue(patient.FullName, "Không rõ")),
                    new SqlParameter("@BirthDate", DbDateValue(patient.DOB, required: true)),
                    new SqlParameter("@Gender", DbRequiredValue(patient.Gender, "Khác")),
                    new SqlParameter("@Phone", DbValue(patient.Phone)),
                    new SqlParameter("@Address", DbValue(patient.Address)),
                    new SqlParameter("@PatientID", patientId));
            }
        }

        private static async Task InsertLocalPatientAsync(SqlConnection conn, ApiPatientDTO patient, Guid uuid, bool isNewSchema)
        {
            if (isNewSchema)
            {
                string sql = @"
INSERT INTO dbo.Patients
(
    PatientUUID,
    PatientCode,
    FullName,
    Gender,
    DOB,
    Phone,
    Address,
    BloodType,
    Allergy
)
VALUES
(
    @PatientUUID,
    @PatientCode,
    @FullName,
    @Gender,
    @DOB,
    @Phone,
    @Address,
    @BloodType,
    @Allergy
);";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@PatientUUID", uuid),
                    new SqlParameter("@PatientCode", DbValue(patient.PatientCode)),
                    new SqlParameter("@FullName", DbValue(patient.FullName)),
                    new SqlParameter("@Gender", DbValue(patient.Gender)),
                    new SqlParameter("@DOB", DbDateValue(patient.DOB, required: false)),
                    new SqlParameter("@Phone", DbValue(patient.Phone)),
                    new SqlParameter("@Address", DbValue(patient.Address)),
                    new SqlParameter("@BloodType", DbValue(patient.BloodType)),
                    new SqlParameter("@Allergy", DbValue(patient.Allergy)));
            }
            else
            {
                string sql = @"
INSERT INTO dbo.Patients
(
    PatientUUID,
    PatientCode,
    Name,
    BirthDate,
    Gender,
    Phone,
    Address
)
VALUES
(
    @PatientUUID,
    @PatientCode,
    @Name,
    @BirthDate,
    @Gender,
    @Phone,
    @Address
);";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@PatientUUID", uuid),
                    new SqlParameter("@PatientCode", DbRequiredValue(patient.PatientCode, "BN" + new Random().Next(10000, 99999))),
                    new SqlParameter("@Name", DbRequiredValue(patient.FullName, "Không rõ")),
                    new SqlParameter("@BirthDate", DbDateValue(patient.DOB, required: true)),
                    new SqlParameter("@Gender", DbRequiredValue(patient.Gender, "Khác")),
                    new SqlParameter("@Phone", DbValue(patient.Phone)),
                    new SqlParameter("@Address", DbValue(patient.Address)));
            }
        }

        private static async Task UpdateLocalEmployeeAsync(SqlConnection conn, int employeeId, ApiEmployeeDTO employee, Guid uuid, bool isNewSchema)
        {
            if (isNewSchema)
            {
                int roleId = await GetOrCreateRoleIdAsync(conn, employee.RoleName);
                int departmentId = await GetDepartmentIdAsync(conn, employee.DepartmentID);

                string sql = @"
UPDATE dbo.Employees
SET EmployeeUUID = @EmployeeUUID,
    EmployeeCode = @EmployeeCode,
    FullName = @FullName,
    RoleID = @RoleID,
    DepartmentID = @DepartmentID,
    Phone = @Phone,
    Status = @Status
WHERE EmployeeID = @EmployeeID";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@EmployeeUUID", uuid),
                    new SqlParameter("@EmployeeCode", DbRequiredValue(employee.SyncCode, BuildEmployeeFallbackCode(uuid))),
                    new SqlParameter("@FullName", DbValue(employee.FullName)),
                    new SqlParameter("@RoleID", roleId),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@Phone", DbValue(employee.Phone)),
                    new SqlParameter("@Status", DbValue(string.IsNullOrWhiteSpace(employee.Status) ? "Active" : employee.Status)),
                    new SqlParameter("@EmployeeID", employeeId));
            }
            else
            {
                string sql = @"
UPDATE dbo.Doctors
SET DoctorUUID = @DoctorUUID,
    DoctorCode = @DoctorCode,
    Name = @Name,
    Department = @Department
WHERE DoctorID = @DoctorID";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@DoctorUUID", uuid),
                    new SqlParameter("@DoctorCode", DbRequiredValue(employee.SyncCode, "BS" + new Random().Next(1000, 9999))),
                    new SqlParameter("@Name", DbRequiredValue(employee.FullName, "Bác sĩ")),
                    new SqlParameter("@Department", DbRequiredValue(string.IsNullOrWhiteSpace(employee.RoleName) ? "Khoa Nội" : employee.RoleName, "Khoa Nội")),
                    new SqlParameter("@DoctorID", employeeId));
            }
        }

        private static async Task InsertLocalEmployeeAsync(SqlConnection conn, ApiEmployeeDTO employee, Guid uuid, bool isNewSchema)
        {
            if (isNewSchema)
            {
                int roleId = await GetOrCreateRoleIdAsync(conn, employee.RoleName);
                int departmentId = await GetDepartmentIdAsync(conn, employee.DepartmentID);

                string sql = @"
INSERT INTO dbo.Employees
(
    EmployeeUUID,
    EmployeeCode,
    FullName,
    RoleID,
    DepartmentID,
    Phone,
    Status
)
VALUES
(
    @EmployeeUUID,
    @EmployeeCode,
    @FullName,
    @RoleID,
    @DepartmentID,
    @Phone,
    @Status
);";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@EmployeeUUID", uuid),
                    new SqlParameter("@EmployeeCode", DbValue(employee.SyncCode)),
                    new SqlParameter("@FullName", DbValue(employee.FullName)),
                    new SqlParameter("@RoleID", roleId),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@Phone", DbValue(employee.Phone)),
                    new SqlParameter("@Status", DbValue(string.IsNullOrWhiteSpace(employee.Status) ? "Active" : employee.Status)));
            }
            else
            {
                string fallbackCode = "BS" + new Random().Next(1000, 9999);
                string sql = @"
INSERT INTO dbo.Doctors
(
    DoctorUUID,
    DoctorCode,
    Name,
    Department
)
VALUES
(
    @DoctorUUID,
    @DoctorCode,
    @Name,
    @Department
);";
                await ExecuteNonQueryAsync(conn, sql,
                    new SqlParameter("@DoctorUUID", uuid),
                    new SqlParameter("@DoctorCode", DbRequiredValue(employee.SyncCode, fallbackCode)),
                    new SqlParameter("@Name", DbRequiredValue(employee.FullName, "Bác sĩ")),
                    new SqlParameter("@Department", DbRequiredValue(string.IsNullOrWhiteSpace(employee.RoleName) ? "Khoa Nội" : employee.RoleName, "Khoa Nội")));
            }
        }

        private static async Task<int> GetOrCreateRoleIdAsync(SqlConnection conn, string roleName)
        {
            string normalized = NormalizeRoleName(roleName);
            object roleId = await ExecuteScalarAsync(conn, "SELECT RoleID FROM dbo.Roles WHERE RoleName = @RoleName", new SqlParameter("@RoleName", normalized));
            if (roleId != null && roleId != DBNull.Value) return Convert.ToInt32(roleId);

            string insertSql = @"
INSERT INTO dbo.Roles(RoleName, Description)
OUTPUT inserted.RoleID
VALUES(@RoleName, @Description);";
            object inserted = await ExecuteScalarAsync(conn, insertSql,
                new SqlParameter("@RoleName", normalized),
                new SqlParameter("@Description", normalized));
            return Convert.ToInt32(inserted);
        }

        private static async Task<int> GetDepartmentIdAsync(SqlConnection conn, int? departmentId)
        {
            if (departmentId.HasValue && departmentId.Value > 0)
            {
                object exists = await ExecuteScalarAsync(conn, "SELECT DepartmentID FROM dbo.Departments WHERE DepartmentID = @DepartmentID", new SqlParameter("@DepartmentID", departmentId.Value));
                if (exists != null && exists != DBNull.Value) return Convert.ToInt32(exists);
            }

            const string fallbackName = "Chua phan khoa";
            object fallback = await ExecuteScalarAsync(conn, "SELECT DepartmentID FROM dbo.Departments WHERE DepartmentName = @DepartmentName", new SqlParameter("@DepartmentName", fallbackName));
            if (fallback != null && fallback != DBNull.Value) return Convert.ToInt32(fallback);

            string insertSql = @"
INSERT INTO dbo.Departments(DepartmentName)
OUTPUT inserted.DepartmentID
VALUES(@DepartmentName);";
            object inserted = await ExecuteScalarAsync(conn, insertSql, new SqlParameter("@DepartmentName", fallbackName));
            return Convert.ToInt32(inserted);
        }

        private static async Task EnsureNullableEmployeeUniqueIndexAsync(SqlConnection conn, string columnName, string indexName)
        {
            string sql = @"
DECLARE @constraintName sysname;

SELECT TOP 1 @constraintName = kc.name
FROM sys.key_constraints kc
JOIN sys.index_columns ic
    ON kc.parent_object_id = ic.object_id
   AND kc.unique_index_id = ic.index_id
JOIN sys.columns c
    ON c.object_id = ic.object_id
   AND c.column_id = ic.column_id
WHERE kc.parent_object_id = OBJECT_ID(N'dbo.Employees')
  AND kc.type = 'UQ'
  AND c.name = @ColumnName;

IF @constraintName IS NOT NULL
BEGIN
    DECLARE @dropSql nvarchar(max) =
        N'ALTER TABLE dbo.Employees DROP CONSTRAINT ' + QUOTENAME(@constraintName);
    EXEC sp_executesql @dropSql;
END;

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.Employees')
      AND name = @IndexName
)
BEGIN
    DECLARE @createSql nvarchar(max) =
        N'CREATE UNIQUE INDEX ' + QUOTENAME(@IndexName) +
        N' ON dbo.Employees(' + QUOTENAME(@ColumnName) + N') WHERE ' +
        QUOTENAME(@ColumnName) + N' IS NOT NULL';
    EXEC sp_executesql @createSql;
END;";
            await ExecuteNonQueryAsync(conn, sql,
                new SqlParameter("@ColumnName", columnName),
                new SqlParameter("@IndexName", indexName));
        }

        private static string BuildEmployeeFallbackCode(Guid uuid)
        {
            return "EMP" + uuid.ToString("N").Substring(0, 8).ToUpperInvariant();
        }

        private static string NormalizeRoleName(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return "Doctor";

            string value = roleName.Trim().ToLowerInvariant();
            if (value.Contains("doctor") || value.Contains("bac si") || value.StartsWith("bs")) return "Doctor";
            if (value.Contains("tech") || value.Contains("ktv")) return "Technician";
            if (value.Contains("nurse")) return "Nurse";
            if (value.Contains("pharmacist")) return "Pharmacist";
            if (value.Contains("admin")) return "Admin";
            if (value.Contains("reception")) return "Receptionist";
            return roleName.Trim();
        }

        private static async Task<object> ExecuteScalarAsync(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return await cmd.ExecuteScalarAsync();
            }
        }

        private static async Task ExecuteNonQueryAsync(SqlConnection conn, string sql, params SqlParameter[] parameters)
        {
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private static object DbValue(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim();
        }

        private static object DbRequiredValue(string value, string fallback)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)fallback : value.Trim();
        }

        private static object DbDateValue(string value, bool required = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return required ? (object)new DateTime(1900, 1, 1) : DBNull.Value;
            }
            if (DateTime.TryParse(value, out DateTime date))
            {
                return date.Date;
            }
            // Try parsing with common Vietnamese formats like dd/MM/yyyy
            string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" };
            if (DateTime.TryParseExact(value, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateExact))
            {
                return dateExact.Date;
            }
            return required ? (object)new DateTime(1900, 1, 1) : DBNull.Value;
        }

        private async Task<List<T>> GetListAsync<T>(string url, bool supabaseHeaders, string stepName)
        {
            using (var client = CreateClient(supabaseHeaders))
            {
                var response = await client.GetAsync(url);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw BuildHttpException(stepName, "GET", url, null, response, responseText);
                }

                try
                {
                    return JsonSerializer.Deserialize<List<T>>(responseText, jsonOptions) ?? new List<T>();
                }
                catch (Exception ex)
                {
                    throw new JsonException($"[{stepName}] Không parse được JSON thành List<{typeof(T).Name}>.\n\nJSON nhận được:\n{LimitText(responseText, 3000)}\n\nLỗi gốc:\n{ex.Message}", ex);
                }
            }
        }

        private async Task<bool> PostJsonAsync(string url, object payload, bool supabaseHeaders, string stepName)
        {
            string json = JsonSerializer.Serialize(payload, jsonOptions);
            using (var client = CreateClient(supabaseHeaders))
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw BuildHttpException(stepName, "POST", url, json, response, responseText);
                }

                return true;
            }
        }

        private async Task<T> PostJsonReturnOneAsync<T>(string url, object payload, bool supabaseHeaders, string stepName)
        {
            string json = JsonSerializer.Serialize(payload, jsonOptions);
            using (var client = CreateClient(supabaseHeaders))
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw BuildHttpException(stepName, "POST", url, json, response, responseText);
                }

                var list = JsonSerializer.Deserialize<List<T>>(responseText, jsonOptions);
                if (list != null && list.Count > 0)
                {
                    return list[0];
                }

                throw new InvalidOperationException($"[{stepName}] Insert thành công nhưng không nhận được record trả về.\n\nResponse:\n{LimitText(responseText, 3000)}");
            }
        }

        private async Task<bool> PatchSheetByColumnAsync(string baseUrl, string columnName, string columnValue, Dictionary<string, object> fields, string stepName)
        {
            string url = BuildSheetRowUrl(baseUrl, columnName, columnValue);
            var payload = new Dictionary<string, object> { ["data"] = fields };
            string json = JsonSerializer.Serialize(payload, jsonOptions);

            using (var client = CreateClient(false))
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content })
            {
                var response = await client.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw BuildHttpException(stepName, "PATCH", url, json, response, responseText);
                }

                return true;
            }
        }

        private async Task<bool> PatchSupabaseByColumnAsync(string baseUrl, string columnName, string columnValue, Dictionary<string, object> fields, string stepName)
        {
            string url = $"{baseUrl}?{columnName}=eq.{Uri.EscapeDataString(columnValue)}";
            string json = JsonSerializer.Serialize(fields, jsonOptions);

            using (var client = CreateClient(true))
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var request = new HttpRequestMessage(new HttpMethod("PATCH"), url) { Content = content })
            {
                var response = await client.SendAsync(request);
                string responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw BuildHttpException(stepName, "PATCH", url, json, response, responseText);
                }

                return true;
            }
        }

        private HttpClient CreateClient(bool supabaseHeaders)
        {
            var handler = new SocketsHttpHandler
            {
                ConnectCallback = async (context, cancellationToken) =>
                {
                    var ips = await System.Net.Dns.GetHostAddressesAsync(context.DnsEndPoint.Host, cancellationToken);
                    var ipv4 = Array.Find(ips, x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    if (ipv4 == null)
                    {
                        throw new System.Net.Sockets.SocketException((int)System.Net.Sockets.SocketError.HostNotFound);
                    }
                    var socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
                    {
                        NoDelay = true
                    };
                    try
                    {
                        await socket.ConnectAsync(new System.Net.IPEndPoint(ipv4, context.DnsEndPoint.Port), cancellationToken);
                        return new System.Net.Sockets.NetworkStream(socket, ownsSocket: true);
                    }
                    catch
                    {
                        socket.Dispose();
                        throw;
                    }
                }
            };

            var client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            if (supabaseHeaders)
            {
                client.DefaultRequestHeaders.Add("apikey", supabaseKey);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + supabaseKey);
                client.DefaultRequestHeaders.Add("Prefer", "return=representation");
            }
            return client;
        }

        private static string ReadSetting(string key, string fallback)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        private static string WithSheetName(string baseUrl, string sheetName)
        {
            string url = (baseUrl ?? "").Trim().TrimEnd('/');
            if (string.IsNullOrWhiteSpace(sheetName) || url.IndexOf("sheet=", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return url;
            }

            string separator = url.Contains("?") ? "&" : "?";
            return $"{url}{separator}sheet={Uri.EscapeDataString(sheetName.Trim())}";
        }

        private static string BuildSheetRowUrl(string baseUrl, string columnName, string columnValue)
        {
            string url = (baseUrl ?? "").Trim();
            int queryIndex = url.IndexOf('?');
            string rowPath = $"/{columnName}/{Uri.EscapeDataString(columnValue)}";
            if (queryIndex < 0)
            {
                return url.TrimEnd('/') + rowPath;
            }

            string path = url.Substring(0, queryIndex).TrimEnd('/');
            string query = url.Substring(queryIndex);
            return path + rowPath + query;
        }

        private static Exception BuildHttpException(string stepName, string method, string url, string requestJson, HttpResponseMessage response, string responseText)
        {
            string body = $"[{stepName}] {method} thất bại\n\nURL:\n{url}\n\nStatusCode:\n{(int)response.StatusCode} - {response.StatusCode}\n\n";
            if (!string.IsNullOrWhiteSpace(requestJson))
            {
                body += $"JSON gửi đi:\n{LimitText(requestJson, 3000)}\n\n";
            }
            body += $"Response:\n{LimitText(responseText, 3000)}";
            return new InvalidOperationException(body);
        }

        private static string LimitText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "";
            return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "\n\n... [Đã rút gọn vì quá dài]";
        }

        public Task<List<FlatImagingRequestDetail>> GetSupabaseImagingRequestDetailsFlatAsync()
        {
            return GetListAsync<FlatImagingRequestDetail>($"{supabaseUrl}/rest/v1/imagingrequestdetails?select=*", true, "GET FLAT DETAILS");
        }

        public Task<List<FlatImagingRequest>> GetSupabaseImagingRequestsFlatAsync()
        {
            return GetListAsync<FlatImagingRequest>($"{supabaseUrl}/rest/v1/imagingrequests?select=*", true, "GET FLAT REQUESTS");
        }

        public Task<List<FlatEncounter>> GetSupabaseEncountersFlatAsync()
        {
            return GetListAsync<FlatEncounter>($"{supabaseUrl}/rest/v1/encounters?select=*", true, "GET FLAT ENCOUNTERS");
        }

        public Task<List<FlatService>> GetSupabaseServicesFlatAsync()
        {
            return GetListAsync<FlatService>($"{supabaseUrl}/rest/v1/services?select=*", true, "GET FLAT SERVICES");
        }

        public Task<List<FlatImagingResult>> GetSupabaseImagingResultsFlatAsync()
        {
            return GetListAsync<FlatImagingResult>($"{supabaseUrl}/rest/v1/imagingresults?select=*", true, "GET FLAT RESULTS");
        }

        public Task<List<FlatLabRequest>> GetSupabaseLabRequestsFlatAsync()
        {
            return GetListAsync<FlatLabRequest>($"{supabaseUrl}/rest/v1/labrequests?select=*", true, "GET FLAT LAB REQUESTS");
        }

        public Task<List<FlatLabResult>> GetSupabaseLabResultsFlatAsync()
        {
            return GetListAsync<FlatLabResult>($"{supabaseUrl}/rest/v1/labresults?select=*", true, "GET FLAT LAB RESULTS");
        }

        public async Task<int?> GetLocalPatientIdByCodeAsync(string patientCode)
        {
            if (string.IsNullOrWhiteSpace(patientCode)) return null;
            using (var conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                string sql = "SELECT TOP 1 PatientID FROM dbo.Patients WHERE PatientCode = @Code";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", patientCode.Trim());
                    var val = await cmd.ExecuteScalarAsync();
                    return val == null || val == DBNull.Value ? (int?)null : Convert.ToInt32(val);
                }
            }
        }

        public async Task<int?> GetLocalDoctorIdByCodeAsync(string doctorCode)
        {
            if (string.IsNullOrWhiteSpace(doctorCode)) return null;
            using (var conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                bool isNew = IsNewSchema(conn);
                string table = isNew ? "Employees" : "Doctors";
                string idCol = isNew ? "EmployeeID" : "DoctorID";
                string codeCol = isNew ? "EmployeeCode" : "DoctorCode";
                string sql = $"SELECT TOP 1 {idCol} FROM dbo.{table} WHERE {codeCol} = @Code";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", doctorCode.Trim());
                    var val = await cmd.ExecuteScalarAsync();
                    return val == null || val == DBNull.Value ? (int?)null : Convert.ToInt32(val);
                }
            }
        }

        public async Task UpsertLocalRequestAsync(string code, int patientId, int doctorId, string serviceType, string bodyPart, string priority, string status, string resultFile, string resultPdf, string labValues, DateTime? requestDate = null, string technicianNote = null)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                await conn.OpenAsync();
                DateTime createdAt = requestDate ?? DateTime.Now;
                string normalizedStatus = string.IsNullOrWhiteSpace(status) ? "Chờ xử lý" : status;
                int encounterId = await CreateEncounterAsync(conn, patientId, doctorId, createdAt);

                if (IsImagingService(serviceType))
                {
                    int imagingServiceId = await GetOrCreateImagingServiceIdAsync(conn, serviceType);
                    int imagingRequestId = await InsertImagingRequestAsync(conn, encounterId, doctorId, imagingServiceId, bodyPart, priority, normalizedStatus, createdAt);

                    if (!string.IsNullOrWhiteSpace(resultFile) || !string.IsNullOrWhiteSpace(resultPdf) || !string.IsNullOrWhiteSpace(technicianNote))
                    {
                        await ExecuteNonQueryAsync(conn, @"
INSERT INTO dbo.ImagingResults (ImagingRequestID, ResultText, ImageURL, PDFURL, TechnicianNote, CompletedAt)
VALUES (@ImagingRequestID, @ResultText, @ImageURL, @PDFURL, @TechnicianNote, @CompletedAt)",
                            new SqlParameter("@ImagingRequestID", imagingRequestId),
                            new SqlParameter("@ResultText", (object)labValues ?? DBNull.Value),
                            new SqlParameter("@ImageURL", (object)resultFile ?? DBNull.Value),
                            new SqlParameter("@PDFURL", (object)resultPdf ?? DBNull.Value),
                            new SqlParameter("@TechnicianNote", (object)technicianNote ?? DBNull.Value),
                            new SqlParameter("@CompletedAt", DateTime.Now));
                    }
                }
                else
                {
                    int labId = await InsertLabRequestAsync(conn, encounterId, doctorId, serviceType, normalizedStatus, createdAt);

                    if (!string.IsNullOrWhiteSpace(labValues) || !string.IsNullOrWhiteSpace(resultPdf))
                    {
                        await ExecuteNonQueryAsync(conn, @"
INSERT INTO dbo.LabResults (LabID, ResultText, FileURL, CompletedAt)
VALUES (@LabID, @ResultText, @FileURL, @CompletedAt)",
                            new SqlParameter("@LabID", labId),
                            new SqlParameter("@ResultText", (object)labValues ?? DBNull.Value),
                            new SqlParameter("@FileURL", (object)resultPdf ?? DBNull.Value),
                            new SqlParameter("@CompletedAt", DateTime.Now));
                    }
                }
            }
        }

        private static async Task<int> CreateEncounterAsync(SqlConnection conn, int patientId, int doctorId, DateTime startTime)
        {
            object value = await ExecuteScalarAsync(conn, @"
INSERT INTO dbo.Encounters (PatientID, DoctorID, StartTime, Status)
VALUES (@PatientID, @DoctorID, @StartTime, @Status);
SELECT CAST(SCOPE_IDENTITY() AS int);",
                new SqlParameter("@PatientID", patientId),
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@StartTime", startTime),
                new SqlParameter("@Status", "Open"));
            return Convert.ToInt32(value);
        }

        private static async Task<int> GetOrCreateImagingServiceIdAsync(SqlConnection conn, string serviceType)
        {
            string serviceName = string.IsNullOrWhiteSpace(serviceType) ? "Chẩn đoán hình ảnh" : serviceType;
            object existing = await ExecuteScalarAsync(conn,
                "SELECT TOP 1 ImagingServiceID FROM dbo.ImagingServices WHERE ServiceName = @ServiceName",
                new SqlParameter("@ServiceName", serviceName));

            if (existing != null && existing != DBNull.Value)
            {
                return Convert.ToInt32(existing);
            }

            await ExecuteNonQueryAsync(conn, @"
INSERT INTO dbo.ImagingServices (ServiceName, Modality, Price, IsActive)
VALUES (@ServiceName, @Modality, 0, 1)",
                new SqlParameter("@ServiceName", serviceName),
                new SqlParameter("@Modality", InferModality(serviceName)));

            return Convert.ToInt32(await ExecuteScalarAsync(conn,
                "SELECT TOP 1 ImagingServiceID FROM dbo.ImagingServices WHERE ServiceName = @ServiceName ORDER BY ImagingServiceID DESC",
                new SqlParameter("@ServiceName", serviceName)));
        }

        private static async Task<int> InsertImagingRequestAsync(SqlConnection conn, int encounterId, int doctorId, int imagingServiceId, string bodyPart, string priority, string status, DateTime createdAt)
        {
            object value = await ExecuteScalarAsync(conn, @"
INSERT INTO dbo.ImagingRequests (EncounterID, DoctorID, ImagingServiceID, BodyPart, CreatedAt, Priority, Status)
VALUES (@EncounterID, @DoctorID, @ImagingServiceID, @BodyPart, @CreatedAt, @Priority, @Status);
SELECT CAST(SCOPE_IDENTITY() AS int);",
                new SqlParameter("@EncounterID", encounterId),
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@ImagingServiceID", imagingServiceId),
                new SqlParameter("@BodyPart", (object)bodyPart ?? DBNull.Value),
                new SqlParameter("@CreatedAt", createdAt),
                new SqlParameter("@Priority", string.IsNullOrWhiteSpace(priority) ? "Thường" : priority),
                new SqlParameter("@Status", status));
            return Convert.ToInt32(value);
        }

        private static async Task<int> InsertLabRequestAsync(SqlConnection conn, int encounterId, int doctorId, string testType, string status, DateTime createdAt)
        {
            object value = await ExecuteScalarAsync(conn, @"
INSERT INTO dbo.LabRequests (EncounterID, DoctorID, TestType, Status, CreatedAt)
VALUES (@EncounterID, @DoctorID, @TestType, @Status, @CreatedAt);
SELECT CAST(SCOPE_IDENTITY() AS int);",
                new SqlParameter("@EncounterID", encounterId),
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@TestType", string.IsNullOrWhiteSpace(testType) ? "Xét nghiệm" : testType),
                new SqlParameter("@Status", status),
                new SqlParameter("@CreatedAt", createdAt));
            return Convert.ToInt32(value);
        }

        private static bool IsImagingService(string serviceType)
        {
            string value = (serviceType ?? "").ToLowerInvariant();
            return value.Contains("mri")
                || value.Contains("x-quang")
                || value.Contains("xray")
                || value.Contains("x-ray")
                || value.Contains("siêu âm")
                || value.Contains("sieu am")
                || value.Contains("imaging");
        }

        private static string InferModality(string serviceType)
        {
            string value = (serviceType ?? "").ToLowerInvariant();
            if (value.Contains("mri")) return "MRI";
            if (value.Contains("x-quang") || value.Contains("xray") || value.Contains("x-ray")) return "X-Ray";
            if (value.Contains("siêu âm") || value.Contains("sieu am")) return "Ultrasound";
            return "Imaging";
        }

        private class LocalIdentity
        {
            public int Id { get; set; }
            public Guid? Uuid { get; set; }
        }

        private class NullableGuidConverter : JsonConverter<Guid?>
        {
            public override Guid? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return null;
                if (reader.TokenType != JsonTokenType.String) return null;

                string value = reader.GetString();
                if (string.IsNullOrWhiteSpace(value)) return null;
                return Guid.TryParse(value, out Guid guid) ? guid : null;
            }

            public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
            {
                if (value.HasValue) writer.WriteStringValue(value.Value.ToString());
                else writer.WriteNullValue();
            }
        }

        private class FlexibleInt32Converter : JsonConverter<int>
        {
            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32();
                }
                if (reader.TokenType == JsonTokenType.String)
                {
                    string value = reader.GetString();
                    if (string.IsNullOrWhiteSpace(value)) return 0;
                    if (int.TryParse(value, out int result)) return result;
                    return 0;
                }
                return 0;
            }

            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                writer.WriteNumberValue(value);
            }
        }

        private class NullableInt32Converter : JsonConverter<int?>
        {
            public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return null;
                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32();
                }
                if (reader.TokenType == JsonTokenType.String)
                {
                    string value = reader.GetString();
                    if (string.IsNullOrWhiteSpace(value)) return null;
                    if (int.TryParse(value, out int result)) return result;
                    return null;
                }
                return null;
            }

            public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
            {
                if (value.HasValue) writer.WriteNumberValue(value.Value);
                else writer.WriteNullValue();
            }
        }
    }
}
