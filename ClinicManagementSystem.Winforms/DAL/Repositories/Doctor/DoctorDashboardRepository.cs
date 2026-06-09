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
                .ConnectionStrings["CMS"]
                .ConnectionString;
        }

        public DoctorDashboardDTO GetDashboard(int doctorId)
        {
            DoctorDashboardDTO dto = new();

            using SqlConnection conn =
                new SqlConnection(_connectionString);

            conn.Open();

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
            string sql =
            @"
            SELECT COUNT(*)
            FROM PatientQueues pq
            INNER JOIN Encounters e
                ON pq.EncounterID=e.EncounterID
            WHERE e.DoctorID=@DoctorID
            AND pq.Status='Waiting'
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
            string sql =
            @"
            SELECT COUNT(*)
            FROM LabRequests
            WHERE DoctorID=@DoctorID
            AND Status<>'Completed'
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
            string sql =
            @"
            SELECT COUNT(*)
            FROM Encounters
            WHERE DoctorID=@DoctorID
            AND Status='Completed'
            AND CAST(StartTime AS DATE)
                = CAST(GETDATE() AS DATE)
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
            string sql =
            @"
            SELECT COUNT(*)
            FROM Encounters
            WHERE DoctorID=@DoctorID
            AND Status='InProgress'
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
            string sql =
            @"
            SELECT TOP 1
                   s.Name,
                   d.DepartmentName,
                   r.RoomCode
            FROM EmployeeShifts es

            INNER JOIN Shifts s
                ON es.ShiftID=s.ShiftID

            INNER JOIN Employees e
                ON es.EmployeeID=e.EmployeeID

            INNER JOIN Departments d
                ON e.DepartmentID=d.DepartmentID

            LEFT JOIN DoctorSchedules ds
                ON ds.DoctorID=e.EmployeeID
                AND ds.WorkDate=es.WorkDate

            LEFT JOIN Rooms r
                ON ds.RoomID=r.RoomID

            WHERE es.EmployeeID=@DoctorID
            AND es.WorkDate=CAST(GETDATE() AS DATE)
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
    }
}
