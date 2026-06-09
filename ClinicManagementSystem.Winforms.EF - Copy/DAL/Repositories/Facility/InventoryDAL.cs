using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.Data.SqlClient;
using DAL.DataContext;

namespace DAL
{
    public class InventoryDAL
    {
        public List<MedicineDTO> GetAllMedicines()
        {
            List<MedicineDTO> list = new List<MedicineDTO>();
            string query = "SELECT MedicineID, Name, Stock, Price, Unit, BatchNumber, ExpiryDate FROM Medicines";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MedicineDTO
                {
                    MedicineID = Convert.ToInt32(row["MedicineID"]),
                    Name = row["Name"].ToString(),
                    Stock = Convert.ToInt32(row["Stock"]),
                    Price = Convert.ToDecimal(row["Price"]),
                    Unit = row["Unit"] != DBNull.Value ? row["Unit"].ToString() : "",
                    BatchNumber = row["BatchNumber"] != DBNull.Value ? row["BatchNumber"].ToString() : "",
                    ExpiryDate = row["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(row["ExpiryDate"]) : DateTime.MinValue
                });
            }

            return list;
        }
    }
}