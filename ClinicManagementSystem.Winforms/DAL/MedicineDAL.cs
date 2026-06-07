using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class MedicineDAL
    {
        private string connectionString =
            "Data Source=DESKTOP-KF6OV10;Integrated Security=True;Trust Server Certificate=True";

        public List<MedicineDTO> GetAllMedicines()
        {
            List<MedicineDTO> list =
                new List<MedicineDTO>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                SELECT *
                FROM Medicines";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    MedicineDTO medicine =
                        new MedicineDTO();

                    medicine.MedicineID =
                        Guid.Parse(
                            reader["MedicineID"]
                            .ToString());

                    medicine.Name =
                        reader["Name"]
                        .ToString();

                    medicine.Unit =
                        reader["Unit"]
                        .ToString();

                    medicine.Price =
                        Convert.ToDecimal(
                            reader["Price"]);

                    medicine.Stock =
                        Convert.ToInt32(
                            reader["Stock"]);

                    medicine.BatchNumber =
                        reader["BatchNumber"]
                        .ToString();

                    medicine.ExpiryDate =
                        Convert.ToDateTime(
                            reader["ExpiryDate"]);

                    list.Add(medicine);
                }
            }

            return list;
        }

        public bool InsertMedicine(
            MedicineDTO medicine)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Medicines
                (
                    Name,
                    Unit,
                    Price,
                    Stock,
                    BatchNumber,
                    ExpiryDate
                )
                VALUES
                (
                    @Name,
                    @Unit,
                    @Price,
                    @Stock,
                    @BatchNumber,
                    @ExpiryDate
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Name",
                    medicine.Name);

                cmd.Parameters.AddWithValue(
                    "@Unit",
                    medicine.Unit);

                cmd.Parameters.AddWithValue(
                    "@Price",
                    medicine.Price);

                cmd.Parameters.AddWithValue(
                    "@Stock",
                    medicine.Stock);

                cmd.Parameters.AddWithValue(
                    "@BatchNumber",
                    medicine.BatchNumber);

                cmd.Parameters.AddWithValue(
                    "@ExpiryDate",
                    medicine.ExpiryDate);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateStock(
            Guid medicineId,
            int qty)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Medicines
                SET Stock = Stock - @Qty
                WHERE MedicineID =
                    @MedicineID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Qty",
                    qty);

                cmd.Parameters.AddWithValue(
                    "@MedicineID",
                    medicineId);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int GetStock(Guid medicineId)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                SELECT Stock
                FROM Medicines
                WHERE MedicineID =
                    @MedicineID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@MedicineID",
                    medicineId);

                conn.Open();

                return Convert.ToInt32(
                    cmd.ExecuteScalar());
            }
        }
    }
}