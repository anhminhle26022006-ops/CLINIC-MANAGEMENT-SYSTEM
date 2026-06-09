using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Doctor;

namespace DAL.Repositories.Doctor
{
    public class AppointmentRepository
    {
        private readonly string _connectionString;

        public AppointmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<AppointmentDto> GetTodayAppointments()
        {
            var list = new List<AppointmentDto>();

            string query = @"
        SELECT 
    A.AppointmentID,
    A.AppointmentDate,
    P.FullName AS PatientName,
    D.DepartmentName,
    E.EncounterID,
    ISNULL(PQ.Status, N'Waiting') AS Status
        FROM Appointments A
        JOIN Patients P ON P.PatientID = A.PatientID
        JOIN Departments D ON D.DepartmentID = A.DepartmentID
        LEFT JOIN Encounters E ON E.AppointmentID = A.AppointmentID
        LEFT JOIN PatientQueues PQ ON PQ.EncounterID = E.EncounterID
        WHERE CAST(A.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
        ORDER BY A.AppointmentDate ASC";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new AppointmentDto
                    {
                        EncounterID = (int)reader["EncounterID"],
                        AppointmentID = (int)reader["AppointmentID"],
                        AppointmentDate = (DateTime)reader["AppointmentDate"],
                        PatientName = reader["PatientName"].ToString(),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return list;
        }
        public List<AppointmentDto> GetAppointmentsByDate(DateTime date)
        {
            var list = new List<AppointmentDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    a.AppointmentID,
                    a.AppointmentDate,
                    p.FullName AS PatientName,
                    d.DepartmentName,
                    a.Status
                FROM Appointments a
                JOIN Patients p ON a.PatientID = p.PatientID
                JOIN Departments d ON a.DepartmentID = d.DepartmentID
                WHERE CAST(a.AppointmentDate AS DATE) = @Date
                ORDER BY a.AppointmentDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", date.Date);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new AppointmentDto
                    {
                        AppointmentID = (int)reader["AppointmentID"],
                        AppointmentDate = (DateTime)reader["AppointmentDate"],
                        PatientName = reader["PatientName"].ToString(),
                        DepartmentName = reader["DepartmentName"].ToString(),
                        Status = reader["Status"].ToString(),
                        VitalSummary = ""
                    });
                }
            }

            return list;
        }
        
        public int CountByStatus(string status)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Appointments WHERE Status = @Status";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
