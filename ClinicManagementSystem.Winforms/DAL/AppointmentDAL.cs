using System;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class AppointmentDAL
    {
        public int CountNewPatients()
        {
            if (!SchemaHelper.TableExists("Appointments")) return 0;
            try
            {
                string query = @"
                    SELECT COUNT(DISTINCT PatientID) FROM Appointments
                    WHERE CAST(AppointmentDate AS date) = CAST(GETDATE() AS date)
                      AND AppointmentType = 'New'";
                object r = DatabaseHelper.ExecuteScalar(query);
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }

        public int CountRevisitPatients()
        {
            if (!SchemaHelper.TableExists("Appointments")) return 0;
            try
            {
                string query = @"
                    SELECT COUNT(DISTINCT PatientID) FROM Appointments
                    WHERE CAST(AppointmentDate AS date) = CAST(GETDATE() AS date)
                      AND AppointmentType = 'Revisit'";
                object r = DatabaseHelper.ExecuteScalar(query);
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }

        public int CountUpcomingAppointments()
        {
            if (!SchemaHelper.TableExists("Appointments")) return 0;
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM Appointments
                    WHERE AppointmentDate >= GETDATE()
                      AND Status NOT IN ('Cancelled','Completed')";
                object r = DatabaseHelper.ExecuteScalar(query);
                return r != null ? Convert.ToInt32(r) : 0;
            }
            catch { return 0; }
        }
    }
}