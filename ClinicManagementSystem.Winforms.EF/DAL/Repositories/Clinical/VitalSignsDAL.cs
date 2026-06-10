using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories.Clinical
{
    public class VitalSignsDAL
    {
        public async Task<bool> InsertVitalSigns(VitalSignsDTO vital)
        {
            string query = @"
                INSERT INTO VitalSigns
                (
                    EncounterID,
                    Temperature,
                    BloodPressure,
                    HeartRate,
                    SPO2,
                    Weight,
                    Notes
                )
                VALUES
                (
                    @EncounterID,
                    @Temperature,
                    @BloodPressure,
                    @HeartRate,
                    @SPO2,
                    @Weight,
                    @Notes
                )";

            SqlParameter[] parameters =
            {
                new SqlParameter("@EncounterID", vital.EncounterID),
                new SqlParameter("@Temperature", vital.Temperature),
                new SqlParameter("@BloodPressure", vital.BloodPressure),
                new SqlParameter("@HeartRate", vital.HeartRate),
                new SqlParameter("@SPO2", vital.SPO2),
                new SqlParameter("@Weight", vital.Weight),
                new SqlParameter("@Notes", (object)vital.Notes ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public async Task<int?> GetLatestEncounterIdByPatient(int patientId)
        {
            string query = @"
                SELECT TOP 1 EncounterID
                FROM Encounters
                WHERE PatientID = @PatientID
                ORDER BY CreatedAt DESC, EncounterID DESC";

            object result = DatabaseHelper.ExecuteScalar(
                query,
                new[] { new SqlParameter("@PatientID", patientId) });

            return result == null || result == DBNull.Value
                ? null
                : Convert.ToInt32(result);
        }
    }
}