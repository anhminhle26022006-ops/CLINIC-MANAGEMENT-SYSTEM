using DTO.Doctor;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Doctor
{
    public class PatientQueueRepository
    {
        private readonly string _connStr;

        public PatientQueueRepository(string connStr)
        {
            _connStr = connStr;
        }

        public List<PatientQueueDto> GetTodayQueue(int doctorId)
        {
            var list = new List<PatientQueueDto>();

            System.Diagnostics.Debug.WriteLine($"[GetTodayQueue] connStr='{_connStr}', doctorId={doctorId}");

            using var conn = new SqlConnection(_connStr);
            conn.Open();

            string sql = @"
SELECT 
    q.QueueID,
    q.EncounterID,
    a.AppointmentID, 
    p.FullName,
    p.PatientCode,
    a.AppointmentDate,
    p.DOB,
    p.Gender,
    p.Allergy,
    q.QueueNumber,
    q.Status,
    q.CurrentStep
FROM PatientQueues q
JOIN Encounters e ON q.EncounterID = e.EncounterID
JOIN Patients p ON e.PatientID = p.PatientID
JOIN Appointments a ON e.AppointmentID = a.AppointmentID
WHERE e.DoctorID = @DoctorID
  AND CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY q.QueueNumber";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DoctorID", doctorId);

            using var reader = cmd.ExecuteReader();

            int rows = 0;
            while (reader.Read())
            {
                rows++;
                DateTime dob = Convert.ToDateTime(reader["DOB"]);
                int age = DateTime.Today.Year - dob.Year;
                if (dob.Date > DateTime.Today.AddYears(-age)) age--;

                list.Add(new PatientQueueDto
                {
                    QueueID = (int)reader["QueueID"],
                    EncounterID = (int)reader["EncounterID"],
                    AppointmentID = reader["AppointmentID"] != DBNull.Value ? (int)reader["AppointmentID"] : 0,
                    PatientName = reader["FullName"].ToString(),
                    PatientCode = reader["PatientCode"].ToString(),
                    AppointmentTime = Convert.ToDateTime(reader["AppointmentDate"]),
                    AgeGender = $"{age} tuổi • {reader["Gender"]}",
                    Allergy = reader["Allergy"].ToString(),
                    QueueNumber = (int)reader["QueueNumber"],
                    Status = reader["Status"].ToString(),
                    CurrentStep = reader["CurrentStep"].ToString()
                });
            }

            System.Diagnostics.Debug.WriteLine($"[GetTodayQueue] rowsRead={rows}, list.Count={list.Count}");
            return list;
        }
        public PatientQueueDto GetByEncounterId(int encounterId)
        {
            using var conn = new SqlConnection(_connStr);
            conn.Open();

            string sql = @"
    SELECT 
        q.QueueID,
        q.EncounterID,
        p.FullName,
        p.PatientCode,
        a.AppointmentDate,
        p.DOB,
        p.Gender,
        p.Allergy,
        q.QueueNumber,
        q.Status
    FROM PatientQueues q
    JOIN Encounters e ON q.EncounterID = e.EncounterID
    JOIN Patients p ON e.PatientID = p.PatientID
    JOIN Appointments a ON e.AppointmentID = a.AppointmentID
    WHERE q.EncounterID = @id";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", encounterId);

            var r = cmd.ExecuteReader();

            if (!r.Read()) return null;

            DateTime dob = Convert.ToDateTime(r["DOB"]);
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age)) age--;

            return new PatientQueueDto
            {
                QueueID = (int)r["QueueID"],
                EncounterID = (int)r["EncounterID"],
                PatientName = r["FullName"].ToString(),
                PatientCode = r["PatientCode"].ToString(),
                AppointmentTime = Convert.ToDateTime(r["AppointmentDate"]),
                AgeGender = $"{age} tuổi • {r["Gender"]}",
                Allergy = r["Allergy"].ToString(),
                QueueNumber = (int)r["QueueNumber"],
                Status = r["Status"].ToString()
            };
        }
    }
}
