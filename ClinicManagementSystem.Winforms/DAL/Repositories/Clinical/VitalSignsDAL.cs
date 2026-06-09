using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class VitalSignsDAL
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS;\r\nInitial Catalog=CMS;\r\nIntegrated Security=True;\r\nTrustServerCertificate=True;";

        public bool InsertVitalSigns(
            VitalSignsDTO vital)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
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

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@EncounterID",
                    vital.EncounterID);

                cmd.Parameters.AddWithValue(
                    "@Temperature",
                    vital.Temperature);

                cmd.Parameters.AddWithValue(
                    "@BloodPressure",
                    vital.BloodPressure);

                cmd.Parameters.AddWithValue(
                    "@HeartRate",
                    vital.HeartRate);

                cmd.Parameters.AddWithValue(
                    "@SPO2",
                    vital.SPO2);

                cmd.Parameters.AddWithValue(
                    "@Weight",
                    vital.Weight);

                cmd.Parameters.AddWithValue(
                    "@Notes",
                    vital.Notes);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}