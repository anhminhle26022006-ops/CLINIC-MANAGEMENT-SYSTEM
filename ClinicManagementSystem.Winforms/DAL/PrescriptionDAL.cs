using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class PrescriptionDAL
    {
        private string connectionString =
            "Data Source=DESKTOP-KF6OV10;Integrated Security=True;Trust Server Certificate=True";

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

                    dto.EncounterID =
                        Guid.Parse(
                            reader["EncounterID"]
                            .ToString());

                    dto.DoctorID =
                        Guid.Parse(
                            reader["DoctorID"]
                            .ToString());

                    dto.Status =
                        reader["Status"]
                        .ToString();

                    dto.CreatedAt =
                        Convert.ToDateTime(
                            reader["CreatedAt"]);

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