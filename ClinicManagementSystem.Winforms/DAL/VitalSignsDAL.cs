using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class VitalSignsDAL
    {
        private string connectionString =
            "YOUR_CONNECTION_STRING";

        public bool InsertVitalSigns(
            VitalSignDTO vital)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO VitalSigns
                (
                    AppointmentID,
                    Temperature,
                    BloodPressure,
                    HeartRate,
                    SPO2,
                    Weight,
                    Height,
                    Notes,
                    CreatedBy
                )
                VALUES
                (
                    @AppointmentID,
                    @Temperature,
                    @BloodPressure,
                    @HeartRate,
                    @SPO2,
                    @Weight,
                    @Height,
                    @Notes,
                    @CreatedBy
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@AppointmentID",
                    vital.AppointmentID);

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
                    "@Height",
                    vital.Height);

                cmd.Parameters.AddWithValue(
                    "@Notes",
                    vital.Notes);

                cmd.Parameters.AddWithValue(
                    "@CreatedBy",
                    vital.CreatedBy);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}