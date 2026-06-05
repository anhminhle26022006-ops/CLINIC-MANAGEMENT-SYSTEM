using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class PrescriptionDAL
    {
        private string connectionString =
            "YOUR_CONNECTION_STRING";

        public List<PrescriptionDTO>
            GetPendingPrescriptions()
        {
            List<PrescriptionDTO> list =
                new List<PrescriptionDTO>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                SELECT *
                FROM Prescriptions
                WHERE Status != 'Completed'";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    PrescriptionDTO dto =
                        new PrescriptionDTO();

                    dto.PrescriptionID =
                        Guid.Parse(
                            reader["PrescriptionID"]
                            .ToString());

                    dto.Status =
                        reader["Status"].ToString();

                    list.Add(dto);
                }
            }

            return list;
        }

        public bool UpdatePrescriptionStatus(
            Guid prescriptionId,
            string status)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Prescriptions
                SET Status = @Status
                WHERE PrescriptionID =
                    @PrescriptionID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    status);

                cmd.Parameters.AddWithValue(
                    "@PrescriptionID",
                    prescriptionId);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}