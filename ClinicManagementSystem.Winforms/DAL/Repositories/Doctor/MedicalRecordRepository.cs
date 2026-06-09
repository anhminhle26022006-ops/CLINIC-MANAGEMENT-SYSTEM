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
        public PatientERMDto GetPatientERM(Guid patientUuid)
        {
            PatientERMDto patient = null;

            using SqlConnection conn = new SqlConnection(_connectionString);

            conn.Open();

            #region Patient Info

            string patientSql = @"
    SELECT *
    FROM Patients
    WHERE PatientUUID = @uuid";

            using (SqlCommand cmd = new SqlCommand(patientSql, conn))
            {
                cmd.Parameters.AddWithValue("@uuid", patientUuid);

                using SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    patient = new PatientERMDto
                    {
                        PatientUUID = Guid.Parse(rd["PatientUUID"].ToString()),
                        PatientCode = rd["PatientCode"].ToString(),
                        FullName = rd["FullName"].ToString(),
                        Gender = rd["Gender"].ToString(),
                        DOB = Convert.ToDateTime(rd["DOB"]),
                        BloodType = rd["BloodType"]?.ToString(),
                        Phone = rd["Phone"]?.ToString(),
                        Email = rd["Email"]?.ToString(),
                        Address = rd["Address"]?.ToString(),
                        InsuranceNumber = rd["InsuranceNumber"]?.ToString(),
                        EmergencyContact = rd["EmergencyContact"]?.ToString(),
                        Allergy = rd["Allergy"]?.ToString(),

                        Encounters = new(),
                        Prescriptions = new(),
                        LabResults = new(),
                        ImagingResults = new(),
                        Invoices = new(),
                        FollowUps = new()
                    };
                }
            }

            #endregion

            if (patient == null)
                return null;

            patient.Encounters = GetEncounters(conn, patientUuid);

            return patient;
        }
        private List<EncounterHistoryDto> GetEncounters(
    SqlConnection conn,
    Guid patientUuid)
        {
            List<EncounterHistoryDto> list = new();

            string sql = @"
    SELECT
        E.EncounterID,
        E.EncounterUUID,
        E.CheckInTime,

        D.FullName DoctorName,
        DP.DepartmentName,

        MR.Symptoms,
        MR.Diagnosis,
        MR.Conclusion

    FROM Encounters E

    LEFT JOIN MedicalRecords MR
        ON MR.EncounterID = E.EncounterID

    LEFT JOIN Employees D
        ON D.EmployeeID = E.DoctorID

    LEFT JOIN Departments DP
        ON DP.DepartmentID = E.DepartmentID

    INNER JOIN Patients P
        ON P.PatientID = E.PatientID

    WHERE P.PatientUUID = @uuid

    ORDER BY E.CheckInTime DESC";

            using SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@uuid", patientUuid);

            using SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new EncounterHistoryDto
                {
                    EncounterId = Convert.ToInt32(rd["EncounterID"]),
                    EncounterUUID = Guid.Parse(rd["EncounterUUID"].ToString()),

                    VisitDate =
                        Convert.ToDateTime(rd["CheckInTime"]),

                    DoctorName =
                        rd["DoctorName"]?.ToString(),

                    DepartmentName =
                        rd["DepartmentName"]?.ToString(),

                    Symptoms =
                        rd["Symptoms"]?.ToString(),

                    Diagnosis =
                        rd["Diagnosis"]?.ToString(),

                    Conclusion =
                        rd["Conclusion"]?.ToString()
                });
            }

            return list;
        }
        private List<PrescriptionHistoryDto>
GetPrescriptions(
    SqlConnection conn,
    int encounterId)
        {
            List<PrescriptionHistoryDto> list = new();

            string sql = @"
    SELECT
        PrescriptionUUID,
        PrescriptionCode,
        CreatedAt
    FROM Prescriptions
    WHERE EncounterID = @id";

            using SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@id", encounterId);

            using SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new PrescriptionHistoryDto
                {
                    PrescriptionUUID =
                        Guid.Parse(rd["PrescriptionUUID"].ToString()),

                    PrescriptionCode =
                        rd["PrescriptionCode"].ToString(),

                    CreatedAt =
                        Convert.ToDateTime(rd["CreatedAt"])
                });
            }

            return list;
        }
        private List<LabHistoryDto>
GetLabs(
    SqlConnection conn,
    int encounterId)
        {
            List<LabHistoryDto> list = new();

            string sql = @"
    SELECT
        LabRequestUUID,
        TestType,
        CreatedAt,
        Status
    FROM LabRequests
    WHERE EncounterID=@id";

            using SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@id", encounterId);

            using SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new LabHistoryDto
                {
                    LabRequestUUID =
                        Guid.Parse(rd["LabRequestUUID"].ToString()),

                    TestType =
                        rd["TestType"].ToString(),

                    CreatedAt =
                        Convert.ToDateTime(rd["CreatedAt"]),

                    Status =
                        rd["Status"].ToString()
                });
            }

            return list;
        }
        private List<ImagingHistoryDto>
GetImaging(
    SqlConnection conn,
    int encounterId)
        {
            List<ImagingHistoryDto> list = new();

            string sql = @"
    SELECT
        ImagingRequestUUID,
        Modality,
        BodyPart,
        CreatedAt,
        Conclusion,
        ImageUrl,
        PdfUrl
    FROM ImagingRequests
    WHERE EncounterID=@id";

            using SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@id", encounterId);

            using SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new ImagingHistoryDto
                {
                    ImagingRequestUUID =
                        Guid.Parse(rd["ImagingRequestUUID"].ToString()),

                    Modality =
                        rd["Modality"].ToString(),

                    BodyPart =
                        rd["BodyPart"].ToString(),

                    CreatedAt =
                        Convert.ToDateTime(rd["CreatedAt"]),

                    Conclusion =
                        rd["Conclusion"]?.ToString(),

                    ImageUrl =
                        rd["ImageUrl"]?.ToString(),

                    PdfUrl =
                        rd["PdfUrl"]?.ToString()
                });
            }

            return list;
        }
    }
    
}
