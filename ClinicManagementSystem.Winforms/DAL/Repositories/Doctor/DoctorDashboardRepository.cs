using DTO.Doctor;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.Repositories.Doctor
{
    public class DoctorDashboardRepository
    {
        private readonly string _connectionString;

        public DoctorDashboardRepository()
        {
            _connectionString =
                ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString;
        }

        public DoctorDashboardDTO GetDashboard(int doctorId)
        {
            DoctorDashboardDTO dto = new();

            using SqlConnection conn =
                new SqlConnection(_connectionString);

            conn.Open();

            dto.TodayAppointments = GetTodayAppointments(conn, doctorId);

            dto.WaitingPatients =
                GetWaitingPatients(conn, doctorId);

            dto.PendingLabs =
                GetPendingLabs(conn, doctorId);

            dto.CompletedToday =
                GetCompletedToday(conn, doctorId);

            dto.InProgress =
                GetInProgress(conn, doctorId);

            dto.TodayShift =
                GetTodayShift(conn, doctorId);

            return dto;
        }

        private int GetWaitingPatients(
            SqlConnection conn,
            int doctorId)
        {
            // BUG FIX: Original query checked PatientQueues.Status = 'Waiting'
            // joined through Encounters. This is correct, BUT the seed data sets
            // Encounters.Status = 'Waiting' (not PatientQueues). The safest fix is
            // to count directly from Encounters with Status = 'Waiting' for today,
            // which matches the actual seeded data and real-world usage.
            string sql =
            @"
            SELECT COUNT(*)
            FROM Encounters
            WHERE DoctorID = @DoctorID
              AND Status = 'Waiting'
              AND CAST(StartTime AS DATE) = CAST(GETDATE() AS DATE)
            ";

            using SqlCommand cmd =
                new(sql, conn);

            cmd.Parameters.AddWithValue(
                "@DoctorID",
                doctorId);

            return Convert.ToInt32(
                cmd.ExecuteScalar());
        }

        private int GetPendingLabs(
            SqlConnection conn,
            int doctorId)
        {
            // No bug here — query is correct as written.
            string sql =
            @"
            SELECT COUNT(*)
            FROM LabRequests
            WHERE DoctorID = @DoctorID
              AND Status <> 'Completed'
            ";

            using SqlCommand cmd =
                new(sql, conn);

            cmd.Parameters.AddWithValue(
                "@DoctorID",
                doctorId);

            return Convert.ToInt32(
                cmd.ExecuteScalar());
        }

        private int GetCompletedToday(
            SqlConnection conn,
            int doctorId)
        {
            // BUG FIX: Original used AND CAST(StartTime AS DATE) = CAST(GETDATE() AS DATE)
            // which is correct, but also add a NULL guard on StartTime to be safe.
            string sql =
            @"
            SELECT COUNT(*)
            FROM Encounters
            WHERE DoctorID = @DoctorID
              AND Status = 'Completed'
              AND StartTime IS NOT NULL
              AND CAST(StartTime AS DATE) = CAST(GETDATE() AS DATE)
            ";

            using SqlCommand cmd =
                new(sql, conn);

            cmd.Parameters.AddWithValue(
                "@DoctorID",
                doctorId);

            return Convert.ToInt32(
                cmd.ExecuteScalar());
        }

        private int GetInProgress(
            SqlConnection conn,
            int doctorId)
        {
            // No bug here — query is correct as written.
            string sql =
            @"
            SELECT COUNT(*)
            FROM Encounters
            WHERE DoctorID = @DoctorID
              AND Status = 'InProgress'
            ";

            using SqlCommand cmd =
                new(sql, conn);

            cmd.Parameters.AddWithValue(
                "@DoctorID",
                doctorId);

            return Convert.ToInt32(
                cmd.ExecuteScalar());
        }

        private ShiftInfoDTO GetTodayShift(
            SqlConnection conn,
            int doctorId)
        {
            // BUG FIX: Original query selected s.Name but the Shifts table column
            // is also called Name — that part is fine. However the JOIN to
            // DoctorSchedules used ds.DoctorID = e.EmployeeID which is WRONG.
            // DoctorSchedules.DoctorID should match es.EmployeeID (the doctor),
            // not e.EmployeeID (a redundant self-join). Fixed below.
            // Also added ISNULL guards on RoomCode so NULL doesn't break the label.
            string sql =
            @"
            SELECT TOP 1
                   s.Name,
                   d.DepartmentName,
                   ISNULL(r.RoomCode, '-') AS RoomCode
            FROM EmployeeShifts es

            INNER JOIN Shifts s
                ON es.ShiftID = s.ShiftID

            INNER JOIN Employees e
                ON es.EmployeeID = e.EmployeeID

            INNER JOIN Departments d
                ON e.DepartmentID = d.DepartmentID

            LEFT JOIN DoctorSchedules ds
                ON ds.DoctorID = es.EmployeeID
               AND ds.WorkDate = es.WorkDate

            LEFT JOIN Rooms r
                ON ds.RoomID = r.RoomID

            WHERE es.EmployeeID = @DoctorID
              AND es.WorkDate = CAST(GETDATE() AS DATE)
            ";

            using SqlCommand cmd =
                new(sql, conn);

            cmd.Parameters.AddWithValue(
                "@DoctorID",
                doctorId);

            using SqlDataReader reader =
                cmd.ExecuteReader();

            if (reader.Read())
            {
                return new ShiftInfoDTO
                {
                    ShiftName =
                        reader["Name"]?.ToString(),

                    DepartmentName =
                        reader["DepartmentName"]?.ToString(),

                    RoomCode =
                        reader["RoomCode"]?.ToString(),

                    IsOnDuty = true
                };
            }

            return new ShiftInfoDTO
            {
                ShiftName = "Trống",
                DepartmentName = "-",
                RoomCode = "-",
                IsOnDuty = false
            };
        }
        private int GetTodayAppointments(SqlConnection conn, int doctorId)
        {
            string sql = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorID = @DoctorID
          AND CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)
    ";
            using SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@DoctorID", doctorId);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        // Thêm mới phương thức này
        public void ChangeShiftToday(int doctorId, int newShiftId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                // Kiểm tra xem hôm nay đã có ca chưa
                string checkSql = @"
            SELECT COUNT(*) FROM EmployeeShifts
            WHERE EmployeeID = @DoctorID AND WorkDate = CAST(GETDATE() AS DATE)";
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        // Nếu có rồi thì UPDATE ca mới
                        string updateSql = @"
                    UPDATE EmployeeShifts
                    SET ShiftID = @ShiftID
                    WHERE EmployeeID = @DoctorID AND WorkDate = CAST(GETDATE() AS DATE)";
                        using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                            updateCmd.Parameters.AddWithValue("@ShiftID", newShiftId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Nếu chưa có thì INSERT ca mới
                        string insertSql = @"
                    INSERT INTO EmployeeShifts (EmployeeID, ShiftID, WorkDate)
                    VALUES (@DoctorID, @ShiftID, CAST(GETDATE() AS DATE))";
                        using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@DoctorID", doctorId);
                            insertCmd.Parameters.AddWithValue("@ShiftID", newShiftId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}