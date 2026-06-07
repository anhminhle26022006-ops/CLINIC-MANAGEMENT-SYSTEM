using System.Data;
using Microsoft.Data.SqlClient;
using DAL.DataContext;
using DTO;

namespace DAL.Repositories
{
    public class EncounterDAL
    {
        private EncounterDTO MapRowToDTO(
            DataRow row)
        {
            return new EncounterDTO
            {
                EncounterID =
                    Convert.ToInt32(
                        row["EncounterID"]),

                AppointmentID =
                    Convert.ToInt32(
                        row["AppointmentID"]),

                PatientID =
                    Convert.ToInt32(
                        row["PatientID"]),

                DoctorID =
                    Convert.ToInt32(
                        row["DoctorID"]),

                StartTime =
                    row["StartTime"] != DBNull.Value
                        ? Convert.ToDateTime(
                            row["StartTime"])
                        : null,

                EndTime =
                    row["EndTime"] != DBNull.Value
                        ? Convert.ToDateTime(
                            row["EndTime"])
                        : null,

                Status =
                    row["Status"]?.ToString()
            };
        }

        public EncounterDTO GetById(
            int encounterId)
        {
            string query = @"
SELECT *
FROM Encounters
WHERE EncounterID = @EncounterID";

            SqlParameter[] parameters =
            {
                new("@EncounterID",
                    encounterId)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToDTO(
                dt.Rows[0]);
        }
    }
}