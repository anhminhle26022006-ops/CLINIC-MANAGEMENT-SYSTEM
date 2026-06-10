using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Admin
{
    public class MedicineDAL
    {
        public async Task<List<MedicineDTO>> GetAllMedicines()
        {
            List<MedicineDTO> list = new List<MedicineDTO>();
            string query = "SELECT * FROM Medicines";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MedicineDTO
                {
                    MedicineID = Convert.ToInt32(row["MedicineID"]),
                    Name = row["Name"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Price = Convert.ToDecimal(row["Price"]),
                    Stock = Convert.ToInt32(row["Stock"]),
                    BatchNumber = row["BatchNumber"] != DBNull.Value ? row["BatchNumber"].ToString() : "",
                    ExpiryDate = row["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(row["ExpiryDate"]) : DateTime.MinValue
                });
            }
            return list;
        }

        public async Task<bool> UpdateMedicine(MedicineDTO medicine)
        {
            string query = @"
                INSERT INTO Medicines (Name, Unit, Price, Stock, BatchNumber, ExpiryDate)
                VALUES (@Name, @Unit, @Price, @Stock, @BatchNumber, @ExpiryDate)";

            SqlParameter[] parameters = {
                new SqlParameter("@Name", medicine.Name),
                new SqlParameter("@Unit", medicine.Unit),
                new SqlParameter("@Price", medicine.Price),
                new SqlParameter("@Stock", medicine.Stock),
                new SqlParameter("@BatchNumber", medicine.BatchNumber ?? (object)DBNull.Value),
                new SqlParameter("@ExpiryDate", medicine.ExpiryDate == DateTime.MinValue ? (object)DBNull.Value : medicine.ExpiryDate)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public async Task<bool> UpdateStock(int medicineId, int qty)
        {
            string query = @"
                UPDATE Medicines
                SET Name = @Name,
                    Unit = @Unit,
                    Price = @Price,
                    Stock = @Stock,
                    BatchNumber = @BatchNumber,
                    ExpiryDate = @ExpiryDate
                WHERE MedicineID = @MedicineID";

            SqlParameter[] parameters = {
                new SqlParameter("@MedicineID", medicine.MedicineID),
                new SqlParameter("@Name", medicine.Name),
                new SqlParameter("@Unit", medicine.Unit),
                new SqlParameter("@Price", medicine.Price),
                new SqlParameter("@Stock", medicine.Stock),
                new SqlParameter("@BatchNumber", string.IsNullOrWhiteSpace(medicine.BatchNumber) ? DBNull.Value : (object)medicine.BatchNumber),
                new SqlParameter("@ExpiryDate", medicine.ExpiryDate == DateTime.MinValue ? DBNull.Value : (object)medicine.ExpiryDate)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public async Task<bool> AdjustStock(int medicineId, int quantityDelta)
        {
            string query = @"
                UPDATE Medicines
                SET Stock = Stock - @Qty
                WHERE MedicineID = @MedicineID";

            SqlParameter[] parameters = {
                new SqlParameter("@Qty", qty),
                new SqlParameter("@MedicineID", medicineId)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public async Task<int> GetStock(int medicineId)
        {
            string query = @"
                UPDATE Medicines
                SET Stock = Stock + @QuantityDelta
                WHERE MedicineID = @MedicineID
                  AND Stock + @QuantityDelta >= 0";

            SqlParameter[] parameters = {
                new SqlParameter("@QuantityDelta", quantityDelta),
                new SqlParameter("@MedicineID", medicineId)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public async Task<bool> DeleteMedicine(int id)
        {
            string query = "SELECT Stock FROM Medicines WHERE MedicineID = @MedicineID";
            SqlParameter[] parameters = {
                new SqlParameter("@MedicineID", medicineId)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }

        public bool DeleteMedicine(int id)
        {
            string query = "DELETE FROM Medicines WHERE MedicineID = @MedicineID";
            SqlParameter[] parameters = {
                new SqlParameter("@MedicineID", id)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}