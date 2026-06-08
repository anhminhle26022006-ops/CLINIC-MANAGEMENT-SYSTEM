using DAL.Interfaces.Doctor;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Doctor
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository()
        {
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CMS;Trusted_Connection=True;";
        }

        public async Task<List<ApiPatientDTO>> GetAllAsync()
        {
            var list = new List<ApiPatientDTO>();

            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            var cmd = new SqlCommand("SELECT * FROM Patients", conn);
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                list.Add(new ApiPatientDTO
                {
                    LegacyPatientUuid = reader["PatientUUID"] == DBNull.Value
    ? null
    : (Guid?)reader["PatientUUID"],
                    PatientCode = reader["PatientCode"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    DOB = reader["DOB"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString(),
                    BloodType = reader["BloodType"].ToString(),
                    Allergy = reader["Allergy"].ToString()
                });
            }

            return list;
        }

        public async Task<ApiPatientDTO> InsertAsync(ApiPatientDTO dto)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
                INSERT INTO Patients(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
                OUTPUT INSERTED.PatientID
                VALUES (@code,@name,@gender,@dob,@phone,@addr,@blood,@allergy)
            ", conn);

            cmd.Parameters.AddWithValue("@code", dto.PatientCode);
            cmd.Parameters.AddWithValue("@name", dto.FullName);
            cmd.Parameters.AddWithValue("@gender", dto.Gender);
            cmd.Parameters.AddWithValue("@dob", dto.DOB ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", dto.Phone);
            cmd.Parameters.AddWithValue("@addr", dto.Address);
            cmd.Parameters.AddWithValue("@blood", dto.BloodType);
            cmd.Parameters.AddWithValue("@allergy", dto.Allergy);

            await cmd.ExecuteScalarAsync();
            return dto;
        }

        public Task<ApiPatientDTO> UpdateAsync(ApiPatientDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task UpsertAsync(ApiPatientDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiPatientDTO> GetByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetIdByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

    }
}
