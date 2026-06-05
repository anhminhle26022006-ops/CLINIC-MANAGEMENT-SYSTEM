using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class MedicineDAL
    {
        private string connectionString =
            "YOUR_CONNECTION_STRING";

        public bool InsertMedicine(
            MedicineDTO medicine)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Medicines
                (
                    MedicineName,
                    Unit,
                    Price,
                    StockQuantity,
                    ExpiredDate,
                    BatchNumber
                )
                VALUES
                (
                    @MedicineName,
                    @Unit,
                    @Price,
                    @StockQuantity,
                    @ExpiredDate,
                    @BatchNumber
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@MedicineName",
                    medicine.MedicineName);

                cmd.Parameters.AddWithValue(
                    "@Unit",
                    medicine.Unit);

                cmd.Parameters.AddWithValue(
                    "@Price",
                    medicine.Price);

                cmd.Parameters.AddWithValue(
                    "@StockQuantity",
                    medicine.StockQuantity);

                cmd.Parameters.AddWithValue(
                    "@ExpiredDate",
                    medicine.ExpiredDate);

                cmd.Parameters.AddWithValue(
                    "@BatchNumber",
                    medicine.BatchNumber);

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
                SET StockQuantity =
                    StockQuantity - @Qty
                WHERE MedicineID = @MedicineID";

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
                SELECT StockQuantity
                FROM Medicines
                WHERE MedicineID = @MedicineID";

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

        public bool SoftDeleteMedicine(
            Guid medicineId)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Medicines
                SET IsArchived = 1
                WHERE MedicineID = @MedicineID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@MedicineID",
                    medicineId);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}