using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class InventoryDAL
    {
        private string connectionString =
            "YOUR_CONNECTION_STRING";

        public List<MedicineDTO> GetAllMedicines()
        {
            List<MedicineDTO> list =
                new List<MedicineDTO>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT *
                    FROM Medicines
                    WHERE IsArchived = 0";

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
                            reader["MedicineID"].ToString());

                    medicine.MedicineName =
                        reader["MedicineName"].ToString();

                    medicine.StockQuantity =
                        Convert.ToInt32(
                            reader["StockQuantity"]);

                    medicine.Price =
                        Convert.ToDecimal(
                            reader["Price"]);

                    list.Add(medicine);
                }
            }

            return list;
        }
    }
}