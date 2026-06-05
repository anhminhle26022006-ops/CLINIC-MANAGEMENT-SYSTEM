using System.Data.SqlClient;

namespace DAL
{
    public class PaymentDAL
    {
        private string connectionString =
            "YOUR_CONNECTION_STRING";

        public bool UpdatePaymentStatus(
            Guid prescriptionId,
            string status,
            string method)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Prescriptions
                SET PaymentStatus = @Status,
                    PaymentMethod = @Method
                WHERE PrescriptionID =
                    @PrescriptionID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    status);

                cmd.Parameters.AddWithValue(
                    "@Method",
                    method);

                cmd.Parameters.AddWithValue(
                    "@PrescriptionID",
                    prescriptionId);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}