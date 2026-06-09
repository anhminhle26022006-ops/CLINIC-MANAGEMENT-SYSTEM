using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Repositories.Doctor.PatientRepository;
using DTO.Clinical.Patient;

namespace DAL.Repositories.Doctor
{
    public class VitalSignsRepository
    {
        private readonly string _connectionString;
        public VitalSignsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public VitalSignsDto GetByEncounter(int encounterId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = @"
        SELECT TOP 1 *
        FROM VitalSigns
        WHERE EncounterID = @id
        ORDER BY CreatedAt DESC";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", encounterId);

            var r = cmd.ExecuteReader();

            if (r.Read())
            {
                return new VitalSignsDto
                {
                    EncounterID = encounterId,
                    Temperature = (decimal)r["Temperature"],
                    BloodPressure = r["BloodPressure"].ToString(),
                    HeartRate = (int)r["HeartRate"],
                    SPO2 = (int)r["SPO2"],
                    Weight = (decimal)r["Weight"],
                    Height = (decimal)r["Height"]
                };
            }

            return null;
        }
    }
}
