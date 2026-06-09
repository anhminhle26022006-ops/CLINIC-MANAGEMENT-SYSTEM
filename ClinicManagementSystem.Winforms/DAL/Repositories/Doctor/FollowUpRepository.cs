using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Repositories.Doctor.PatientRepository;

namespace BUS.Services.Doctor
{
    public class FollowUpRepository
    {
        private readonly string _connectionString;
        public FollowUpRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Create(int encounterId, DateTime date, string reason)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = @"
        INSERT INTO FollowUps(EncounterID, FollowUpDate, Status)
        VALUES(@id, @date, 'Pending')";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", encounterId);
            cmd.Parameters.AddWithValue("@date", date);

            cmd.ExecuteNonQuery();
        }
    }
}
