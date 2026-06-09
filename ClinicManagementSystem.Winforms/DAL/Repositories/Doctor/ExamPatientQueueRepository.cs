using DTO.Doctor;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Repositories.Doctor.PatientRepository;

namespace DAL.Repositories.Doctor
{
    public class ExamPatientQueueRepository
    {
        private readonly string _connectionString;
        public ExamPatientQueueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private int CalculateAge(object dobObj)
        {
            if (dobObj == null || dobObj == DBNull.Value)
                return 0;

            DateTime dob = Convert.ToDateTime(dobObj);

            int age = DateTime.Today.Year - dob.Year;

            if (dob.Date > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }
        public List<PatientQueueDto> GetTodayQueue(int doctorId)
        {
            var list = new List<PatientQueueDto>();

            using (var conn = new SqlConnection(_connectionString))
            {
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
            WHERE e.DoctorID = @DoctorID
              AND CAST(a.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
            ORDER BY q.QueueNumber";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DoctorID", doctorId);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new PatientQueueDto
                    {
                        QueueID = (int)reader["QueueID"],
                        EncounterID = (int)reader["EncounterID"],
                        PatientName = reader["FullName"].ToString(),
                        PatientCode = reader["PatientCode"].ToString(),
                        AppointmentTime = Convert.ToDateTime(reader["AppointmentDate"]),
                        AgeGender = $"{CalculateAge(reader["DOB"])} tuổi • {reader["Gender"]}",
                        Allergy = reader["Allergy"].ToString(),
                        QueueNumber = (int)reader["QueueNumber"],
                        Status = reader["Status"].ToString()
                    });
                }
                return list;
            }
        }
    }
}
