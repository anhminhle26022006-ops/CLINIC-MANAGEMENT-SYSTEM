using DTO.Doctor;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Doctor
{
    public class PrescriptionRepository
    {
        private readonly string _connectionString;

        public PrescriptionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PrescriptionListDto> GetAll()
        {
            List<PrescriptionListDto> result = new();

            using SqlConnection conn = new SqlConnection(_connectionString);

            string sql =
            @"
            SELECT
                p.PrescriptionID,
                p.CreatedAt,

                pt.FullName,

                COUNT(pd.DetailID) AS MedicineCount,

                MAX(pd.Instruction) AS Note,

                p.Status

            FROM Prescriptions p

            INNER JOIN Encounters e
                ON e.EncounterID = p.EncounterID

            INNER JOIN Patients pt
                ON pt.PatientID = e.PatientID

            LEFT JOIN PrescriptionDetails pd
                ON pd.PrescriptionID = p.PrescriptionID

            GROUP BY
                p.PrescriptionID,
                p.CreatedAt,
                pt.FullName,
                p.Status

            ORDER BY p.CreatedAt DESC
            ";

            SqlCommand cmd = new(sql, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new PrescriptionListDto
                {
                    PrescriptionId = Convert.ToInt32(reader["PrescriptionID"]),
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                    PatientName = reader["FullName"].ToString(),
                    MedicineCount = Convert.ToInt32(reader["MedicineCount"]),
                    Note = reader["Note"]?.ToString(),
                    Status = reader["Status"].ToString()
                });
            }

            return result;
        }
        public PrescriptionDetailDto GetDetail(int prescriptionId)
        {
            PrescriptionDetailDto dto = null;

            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            string headerSql =
            @"
    SELECT
        p.PrescriptionID,
        p.CreatedAt,
        p.Status,
        pt.FullName

    FROM Prescriptions p

    INNER JOIN Encounters e
        ON e.EncounterID = p.EncounterID

    INNER JOIN Patients pt
        ON pt.PatientID = e.PatientID

    WHERE p.PrescriptionID = @id
    ";

            SqlCommand cmd = new(headerSql, conn);
            cmd.Parameters.AddWithValue("@id", prescriptionId);

            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                dto = new PrescriptionDetailDto
                {
                    PrescriptionId =
                        Convert.ToInt32(rd["PrescriptionID"]),

                    CreatedAt =
                        Convert.ToDateTime(rd["CreatedAt"]),

                    PatientName =
                        rd["FullName"].ToString(),

                    Status =
                        rd["Status"].ToString()
                };
            }

            rd.Close();

            if (dto == null)
                return null;

            string detailSql =
            @"
    SELECT
        m.Name,
        pd.Quantity,
        pd.Dosage,
        pd.Frequency,
        pd.Instruction

    FROM PrescriptionDetails pd

    INNER JOIN Medicines m
        ON m.MedicineID = pd.MedicineID

    WHERE pd.PrescriptionID = @id
    ";

            SqlCommand detailCmd = new(detailSql, conn);

            detailCmd.Parameters.AddWithValue("@id", prescriptionId);

            SqlDataReader dr = detailCmd.ExecuteReader();

            while (dr.Read())
            {
                dto.Medicines.Add(new MedicinePrescriptionDto
                {
                    MedicineName = dr["Name"].ToString(),
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Dosage = dr["Dosage"].ToString(),
                    Frequency = dr["Frequency"].ToString(),
                    Instruction = dr["Instruction"].ToString()
                });
            }

            return dto;
        }
        public PrescriptionStatisticDto GetStatistics()
        {
            using SqlConnection conn =
                new SqlConnection(_connectionString);

            conn.Open();

            string sql =
            @"
    SELECT
        COUNT(*) Total,

        SUM(
            CASE
                WHEN CAST(CreatedAt AS DATE)
                    = CAST(GETDATE() AS DATE)
                THEN 1
                ELSE 0
            END
        ) Today,

        SUM(
            CASE
                WHEN CreatedAt >=
                     DATEADD(DAY,-7,GETDATE())
                THEN 1
                ELSE 0
            END
        ) ThisWeek,

        SUM(
            CASE
                WHEN Status IN
                (
                    'Pending',
                    'Processing'
                )
                THEN 1
                ELSE 0
            END
        ) Processing

    FROM Prescriptions
    ";

            SqlCommand cmd =
                new SqlCommand(sql, conn);

            SqlDataReader rd =
                cmd.ExecuteReader();

            if (rd.Read())
            {
                return new PrescriptionStatisticDto
                {
                    Total =
                        Convert.ToInt32(rd["Total"]),

                    Today =
                        Convert.ToInt32(rd["Today"]),

                    ThisWeek =
                        Convert.ToInt32(rd["ThisWeek"]),

                    Processing =
                        Convert.ToInt32(rd["Processing"])
                };
            }

            return new PrescriptionStatisticDto();
        }
    }
}
