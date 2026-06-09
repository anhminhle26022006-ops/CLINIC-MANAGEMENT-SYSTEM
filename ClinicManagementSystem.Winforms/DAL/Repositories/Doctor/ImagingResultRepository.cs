using DTO.Doctor;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Doctor
{
    public class ImagingResultRepository
    {
        private readonly string _connectionString;

        public ImagingResultRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ImagingResultDto> GetByEncounter(int encounterId)
        {
            var list = new List<ImagingResultDto>();

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            string sql = @"
                SELECT 
                    ires.ResultText,
                    ires.ImageURL,
                    ires.CompletedAt,
                    isv.ServiceName
                FROM ImagingResults ires
                JOIN ImagingRequests ir ON ires.ImagingRequestID = ir.ImagingRequestID
                JOIN ImagingServices isv ON ir.ImagingServiceID = isv.ImagingServiceID
                WHERE ir.EncounterID = @id
                ORDER BY ires.CompletedAt DESC";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", encounterId);

            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new ImagingResultDto
                {
                    ServiceName = r["ServiceName"].ToString(),
                    ResultText = r["ResultText"].ToString(),
                    CompletedAt = Convert.ToDateTime(r["CompletedAt"]),
                    ImageURL = r["ImageURL"]?.ToString()
                });
            }

            return list;
        }
    }
}
