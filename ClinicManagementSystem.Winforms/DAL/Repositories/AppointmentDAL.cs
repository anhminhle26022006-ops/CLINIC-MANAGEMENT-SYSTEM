using System;
using DAL.DataContext;

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
    }
}