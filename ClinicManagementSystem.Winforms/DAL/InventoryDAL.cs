using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class InventoryDAL
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

                    medicine.Name =
                        reader["MedicineName"].ToString();

                    medicine.Stock =
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