using DTO.Clinical.Patient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Repositories.Doctor.PatientRepository;
using System.Configuration;
using DTO.Clinical.erm;


namespace DAL.Repositories.Doctor
{
   
    
        public class MedicalRecordRepository
        {
            private readonly string _connectionString;

            public MedicalRecordRepository()
            {
                _connectionString =
                    ConfigurationManager
                    .ConnectionStrings["DbConnection"]
                    .ConnectionString;
            }

            public List<MedicalRecordDto> GetAll()
            {
                List<MedicalRecordDto> records = new();

                string sql = @"
                SELECT
                    MR.RecordID,
                    MR.RecordUUID,
                    MR.CreatedAt,

                    P.FullName AS Patient,

                    MR.Diagnosis,

                    E.FullName AS Doctor,

                    CASE
                        WHEN EN.Status = 'Completed'
                            THEN N'Hoàn thành'

                        WHEN EN.Status = 'InProgress'
                            THEN N'Đang theo dõi'

                        ELSE EN.Status
                    END AS Status

                FROM MedicalRecords MR

                INNER JOIN Encounters EN
                    ON EN.EncounterID = MR.EncounterID

                INNER JOIN Patients P
                    ON P.PatientID = EN.PatientID

                INNER JOIN Employees E
                    ON E.EmployeeID = EN.DoctorID

                ORDER BY MR.CreatedAt DESC";

                using SqlConnection conn =
                    new SqlConnection(_connectionString);

                using SqlCommand cmd =
                    new SqlCommand(sql, conn);

                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    records.Add(new MedicalRecordDto
                    {
                        RecordID = Convert.ToInt32(rd["RecordID"]),
                        RecordUUID = Guid.Parse(rd["RecordUUID"].ToString()),
                        Date = Convert.ToDateTime(rd["CreatedAt"]),
                        Patient = rd["Patient"].ToString(),
                        Diagnosis = rd["Diagnosis"].ToString(),
                        Doctor = rd["Doctor"].ToString(),
                        Status = rd["Status"].ToString()
                    });
                }

                return records;
            }
        public List<MedicalRecordDto> GetHistory(int encounterId)
        {
            List<MedicalRecordDto> records = new();

            string sql = @"
    SELECT
        MR.RecordID,
        MR.RecordUUID,
        MR.CreatedAt,

        P.FullName AS Patient,

        MR.Diagnosis,

        E.FullName AS Doctor,

        CASE
            WHEN EN.Status = 'Completed'
                THEN N'Hoàn thành'
            WHEN EN.Status = 'InProgress'
                THEN N'Đang theo dõi'
            ELSE EN.Status
        END AS Status

    FROM MedicalRecords MR

    INNER JOIN Encounters EN
        ON EN.EncounterID = MR.EncounterID

    INNER JOIN Patients P
        ON P.PatientID = EN.PatientID

    INNER JOIN Employees E
        ON E.EmployeeID = EN.DoctorID

    WHERE EN.PatientID =
    (
        SELECT PatientID
        FROM Encounters
        WHERE EncounterID = @EncounterID
    )

    ORDER BY MR.CreatedAt DESC";

            using SqlConnection conn =
                new SqlConnection(_connectionString);

            using SqlCommand cmd =
                new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@EncounterID", encounterId);

            conn.Open();

            using SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                records.Add(new MedicalRecordDto
                {
                    RecordID = Convert.ToInt32(rd["RecordID"]),
                    RecordUUID = Guid.Parse(rd["RecordUUID"].ToString()),
                    Date = Convert.ToDateTime(rd["CreatedAt"]),
                    Patient = rd["Patient"].ToString(),
                    Diagnosis = rd["Diagnosis"].ToString(),
                    Doctor = rd["Doctor"].ToString(),
                    Status = rd["Status"].ToString()
                });
            }

            return records;
        }
    }
    
}
