using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DAL.DataContext;
using DAL.Interfaces.Doctor;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories.Doctor
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<List<ApiPatientDTO>> GetAllAsync()
        {
            string query = @"
                SELECT PatientID, PatientUUID, PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy
                FROM Patients";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(query, conn);
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            List<ApiPatientDTO> list = new List<ApiPatientDTO>();
            while (await reader.ReadAsync())
            {
                list.Add(MapReader(reader));
            }

            return list;
        }

        public async Task<ApiPatientDTO> GetByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            string query = @"
                SELECT TOP 1 PatientID, PatientUUID, PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy
                FROM Patients
                WHERE PatientCode = @PatientCode";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PatientCode", code.Trim());
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            return await reader.ReadAsync() ? MapReader(reader) : null;
        }

        public async Task<int?> GetIdByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return null;
            }

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand("SELECT TOP 1 PatientID FROM Patients WHERE PatientCode = @PatientCode", conn);
            cmd.Parameters.AddWithValue("@PatientCode", code.Trim());
            await conn.OpenAsync();
            object result = await cmd.ExecuteScalarAsync();

            return result == null || result == DBNull.Value ? null : Convert.ToInt32(result);
        }

        public async Task<ApiPatientDTO> InsertAsync(ApiPatientDTO dto)
        {
            string query = @"
                INSERT INTO Patients(PatientUUID, PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
                VALUES (@uuid, @code, @name, @gender, @dob, @phone, @addr, @blood, @allergy)";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(query, conn);
            AddParameters(cmd, dto);
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return dto;
        }

        public async Task<ApiPatientDTO> UpdateAsync(ApiPatientDTO dto)
        {
            string query = @"
                UPDATE Patients
                SET PatientUUID = COALESCE(@uuid, PatientUUID),
                    FullName = @name,
                    Gender = @gender,
                    DOB = @dob,
                    Phone = @phone,
                    Address = @addr,
                    BloodType = @blood,
                    Allergy = @allergy
                WHERE PatientCode = @code";

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(query, conn);
            AddParameters(cmd, dto);
            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            return dto;
        }

        public async Task UpsertAsync(ApiPatientDTO dto)
        {
            int? existingId = await GetIdByCodeAsync(dto.PatientCode);
            if (existingId.HasValue)
            {
                await UpdateAsync(dto);
                return;
            }

            await InsertAsync(dto);
        }

        private static void AddParameters(SqlCommand cmd, ApiPatientDTO dto)
        {
            cmd.Parameters.AddWithValue("@uuid", (object)dto.SyncUuid ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@code", dto.PatientCode ?? "");
            cmd.Parameters.AddWithValue("@name", dto.FullName ?? "");
            cmd.Parameters.AddWithValue("@gender", (object)dto.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@dob", (object)dto.DOB ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", (object)dto.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@addr", (object)dto.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@blood", (object)dto.BloodType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@allergy", (object)dto.Allergy ?? DBNull.Value);
        }

        private static ApiPatientDTO MapReader(IDataRecord reader)
        {
            return new ApiPatientDTO
            {
                LegacyPatientUuid = reader["PatientUUID"] == DBNull.Value ? null : (Guid?)Guid.Parse(reader["PatientUUID"].ToString()),
                PatientCode = reader["PatientCode"]?.ToString(),
                FullName = reader["FullName"]?.ToString(),
                Gender = reader["Gender"] == DBNull.Value ? "" : reader["Gender"].ToString(),
                DOB = reader["DOB"] == DBNull.Value ? "" : Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd"),
                Phone = reader["Phone"] == DBNull.Value ? "" : reader["Phone"].ToString(),
                Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString(),
                BloodType = reader["BloodType"] == DBNull.Value ? "" : reader["BloodType"].ToString(),
                Allergy = reader["Allergy"] == DBNull.Value ? "" : reader["Allergy"].ToString()
            };
        }
    }
}
