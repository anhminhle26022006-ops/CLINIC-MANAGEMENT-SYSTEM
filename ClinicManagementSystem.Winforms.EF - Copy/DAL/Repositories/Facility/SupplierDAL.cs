using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class SupplierDAL
    {
        public List<SupplierDTO> GetAllSuppliers()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT SupplierID, SupplierName, Phone, Email, Address FROM Suppliers");

            List<SupplierDTO> list = new List<SupplierDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRow(row));
            }

            return list;
        }

        public bool InsertSupplier(SupplierDTO supplier)
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

            return DatabaseHelper.ExecuteNonQuery(query, BuildSupplierParameters(supplier)) > 0;
        }

        public bool UpdateSupplier(SupplierDTO supplier)
        {
            string query = @"
                UPDATE Suppliers
                SET SupplierName = @SupplierName,
                    Phone = @Phone,
                    Email = @Email,
                    Address = @Address
                WHERE SupplierID = @SupplierID";

            SqlParameter[] parameters =
            {
                new SqlParameter("@SupplierID", supplier.SupplierID),
                new SqlParameter("@SupplierName", supplier.SupplierName),
                new SqlParameter("@Phone", (object)supplier.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object)supplier.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object)supplier.Address ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool DeleteSupplier(Guid supplierId)
        {
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM Suppliers WHERE SupplierID = @SupplierID",
                new[] { new SqlParameter("@SupplierID", supplierId) }) > 0;
        }

        private static SqlParameter[] BuildSupplierParameters(SupplierDTO supplier)
        {
            return new[]
            {
                new SqlParameter("@SupplierName", supplier.SupplierName),
                new SqlParameter("@Phone", (object)supplier.Phone ?? DBNull.Value),
                new SqlParameter("@Email", (object)supplier.Email ?? DBNull.Value),
                new SqlParameter("@Address", (object)supplier.Address ?? DBNull.Value)
            };
        }

        private static SupplierDTO MapRow(DataRow row)
        {
            return new SupplierDTO
            {
                SupplierID = row["SupplierID"] == DBNull.Value ? Guid.Empty : Guid.Parse(row["SupplierID"].ToString()),
                SupplierName = row["SupplierName"]?.ToString(),
                Phone = row["Phone"] == DBNull.Value ? "" : row["Phone"].ToString(),
                Email = row["Email"] == DBNull.Value ? "" : row["Email"].ToString(),
                Address = row.Table.Columns.Contains("Address") && row["Address"] != DBNull.Value ? row["Address"].ToString() : ""
            };
        }
    }
}
