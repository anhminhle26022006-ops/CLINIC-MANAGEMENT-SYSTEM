using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class SupplierDAL
    {
        private string connectionString =
            "Data Source=DESKTOP-KF6OV10;Integrated Security=True;Trust Server Certificate=True";

        public List<SupplierDTO> GetAllSuppliers()
        {
            List<SupplierDTO> list =
                new List<SupplierDTO>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query =
                    "SELECT * FROM Suppliers";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    SupplierDTO dto =
                        new SupplierDTO();

                    dto.SupplierID =
                        Guid.Parse(
                            reader["SupplierID"]
                            .ToString());

                    dto.SupplierName =
                        reader["SupplierName"]
                        .ToString();

                    dto.Phone =
                        reader["Phone"].ToString();

                    dto.Email =
                        reader["Email"].ToString();

                    list.Add(dto);
                }
            }

            return list;
        }

        public bool InsertSupplier(
            SupplierDTO supplier)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO Suppliers
                (
                    SupplierName,
                    Phone,
                    Email,
                    Address
                )
                VALUES
                (
                    @SupplierName,
                    @Phone,
                    @Email,
                    @Address
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@SupplierName",
                    supplier.SupplierName);

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    supplier.Phone);

                cmd.Parameters.AddWithValue(
                    "@Email",
                    supplier.Email);

                cmd.Parameters.AddWithValue(
                    "@Address",
                    supplier.Address);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool UpdateSupplier(SupplierDTO supplier)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
        UPDATE Suppliers
        SET SupplierName = @SupplierName,
            Phone = @Phone,
            Email = @Email,
            Address = @Address
        WHERE SupplierID = @SupplierID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@SupplierID",
                    supplier.SupplierID);

                cmd.Parameters.AddWithValue(
                    "@SupplierName",
                    supplier.SupplierName);

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    supplier.Phone);

                cmd.Parameters.AddWithValue(
                    "@Email",
                    supplier.Email);

                cmd.Parameters.AddWithValue(
                    "@Address",
                    supplier.Address);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteSupplier(Guid supplierId)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query =
                    "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@SupplierID",
                    supplierId);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}