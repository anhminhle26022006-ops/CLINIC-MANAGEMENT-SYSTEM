using DTO.Doctor;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Doctor
{
    public class LabResultRepository
    {
        private readonly string _connectionString;

        public LabResultRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<LabResultDto> GetByEncounter(int encounterId)
        {
            var list = new List<LabResultDto>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = @"
                SELECT 
                    lr.ResultText,
                    lr.CompletedAt,
                    lr.FileURL,
                    lr.LabID,
                    lr.Status
                FROM LabResults lr
                JOIN LabRequests lq ON lr.LabID = lq.LabID
                WHERE lq.EncounterID = @id
                ORDER BY lr.CompletedAt DESC";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", encounterId);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new LabResultDto
                {
                    TestType = "Lab",
                    Status = r["Status"].ToString(),
                    CompletedAt = Convert.ToDateTime(r["CompletedAt"]),

                    // fake parse từ ResultText (vì DB chưa tách WBC/RBC)
                    WBC = "7.2",
                    RBC = "5.1",
                    HGB = "15.2"
                });
            }

            return list;
        }
    }
}
