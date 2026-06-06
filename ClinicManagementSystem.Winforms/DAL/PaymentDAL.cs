using Microsoft.Data.SqlClient;

namespace DAL
{
    public class PaymentDAL
    {
        private string connectionString =
            "Data Source=DESKTOP-KF6OV10;Integrated Security=True;Trust Server Certificate=True";

        public bool UpdatePaymentStatus(
            Guid invoiceId,
            string status,
            string method)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Payments
                (
                    PaymentID,
                    InvoiceID,
                    Method,
                    Status,
                    PaidAt
                )
                VALUES
                (
                    NEWID(),
                    @InvoiceID,
                    @Method,
                    @Status,
                    GETDATE()
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@InvoiceID",
                    invoiceId);

                cmd.Parameters.AddWithValue(
                    "@Method",
                    method);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    status);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}