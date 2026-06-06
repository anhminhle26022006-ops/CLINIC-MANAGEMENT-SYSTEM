using System;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class AppointmentDAL
    {
        public int CountNewPatients()
        {
            string query = @"
                SELECT COUNT(*)
                FROM
                (
                    SELECT PatientID,
                           MIN(AppointmentDate) AS FirstAppointment
                    FROM Appointments
                    GROUP BY PatientID
                ) t
                WHERE MONTH(FirstAppointment) = MONTH(GETDATE())
                  AND YEAR(FirstAppointment) = YEAR(GETDATE())";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int CountRevisitPatients()
        {
            string query = @"
                SELECT COUNT(*)
                FROM
                (
                    SELECT PatientID
                    FROM Appointments
                    GROUP BY PatientID
                    HAVING COUNT(*) > 1
                ) t";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int CountUpcomingAppointments()
        {
            string query = @"
                SELECT COUNT(*)
                FROM Appointments
                WHERE AppointmentDate >= GETDATE()
                  AND Status <> N'Cancelled'";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int CountAppointmentsToday()
        {
            string query = @"
                SELECT COUNT(*)
                FROM Appointments
                WHERE CAST(AppointmentDate AS DATE)
                      = CAST(GETDATE() AS DATE)";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public bool Create(AppointmentDTO appointment)
        {
            string query = @"
    INSERT INTO Appointments
    (
        PatientID,
        DoctorID,
        DepartmentID,
        RoomID,
        AppointmentDate,
        Status
    )
    VALUES
    (
        @PatientID,
        @DoctorID,
        @DepartmentID,
        @RoomID,
        @AppointmentDate,
        @Status
    )";

            SqlParameter[] parameters =
            {
        new SqlParameter("@PatientID", appointment.PatientID),
        new SqlParameter("@DoctorID", appointment.DoctorID),
        new SqlParameter("@DepartmentID", appointment.DepartmentID),
        new SqlParameter("@RoomID", appointment.RoomID),
        new SqlParameter("@AppointmentDate", appointment.AppointmentDate),
        new SqlParameter("@Status", appointment.Status)
    };

            return DatabaseHelper.ExecuteNonQuery(
                query,
                parameters) > 0;
        }

        public int CountAppointmentsByDoctor(
    int doctorId)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorID = @DoctorID
        AND CAST(AppointmentDate AS DATE)
            = CAST(GETDATE() AS DATE)
        AND Status <> 'Cancelled'";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId)
    };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters));
        }
    }
}