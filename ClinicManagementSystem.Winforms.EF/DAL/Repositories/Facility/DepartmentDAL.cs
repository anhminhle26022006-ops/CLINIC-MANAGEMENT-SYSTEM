using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class DepartmentDAL : IDepartmentDAL
    {
        public List<DepartmentDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Departments"))
            {
                return new List<DepartmentDTO>();
            }

            string descriptionExpression = SchemaHelper.ColumnExists("Departments", "Description")
                ? "Description"
                : "CAST('' AS nvarchar(255)) AS Description";
            string activeExpression = SchemaHelper.ColumnExists("Departments", "IsActive")
                ? "IsActive"
                : "CAST(1 AS bit) AS IsActive";
            string query = $"SELECT DepartmentID, DepartmentName, {descriptionExpression}, {activeExpression} FROM Departments ORDER BY DepartmentName";
            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        public DepartmentDTO GetById(int departmentId)
        {
            if (!SchemaHelper.TableExists("Departments") || departmentId <= 0)
            {
                return null;
            }

            string descriptionExpression = SchemaHelper.ColumnExists("Departments", "Description")
                ? "Description"
                : "CAST('' AS nvarchar(255)) AS Description";
            string activeExpression = SchemaHelper.ColumnExists("Departments", "IsActive")
                ? "IsActive"
                : "CAST(1 AS bit) AS IsActive";
            string query = $"SELECT DepartmentID, DepartmentName, {descriptionExpression}, {activeExpression} FROM Departments WHERE DepartmentID = @DepartmentID";
            List<DepartmentDTO> list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@DepartmentID", departmentId)
            }));
            return list.Count > 0 ? list[0] : null;
        }

        public bool Exists(int departmentId)
        {
            return GetById(departmentId) != null;
        }

        private static List<DepartmentDTO> Map(DataTable table)
        {
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new DepartmentDTO
                {
                    DepartmentID = Convert.ToInt32(row["DepartmentID"]),
                    DepartmentName = row["DepartmentName"].ToString(),
                    Description = row.Table.Columns.Contains("Description") ? row["Description"].ToString() : "",
                    IsActive = !row.Table.Columns.Contains("IsActive") || row["IsActive"] == DBNull.Value || Convert.ToBoolean(row["IsActive"])
                });
            }
            return list;
        }

        public bool Add(DepartmentDTO department)
        {
            string query = "INSERT INTO Departments(DepartmentName) VALUES(@DepartmentName)";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@DepartmentName", department.DepartmentName)
            }) > 0;
        }

        public bool Update(DepartmentDTO department)
        {
            string query = "UPDATE Departments SET DepartmentName = @DepartmentName WHERE DepartmentID = @DepartmentID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@DepartmentName", department.DepartmentName),
                new SqlParameter("@DepartmentID", department.DepartmentID)
            }) > 0;
        }

        public bool SetActive(int id, bool isActive)
        {
            if (SchemaHelper.ColumnExists("Departments", "IsActive"))
            {
                return DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Departments SET IsActive = @IsActive WHERE DepartmentID = @DepartmentID",
                    new[]
                    {
                        new SqlParameter("@IsActive", isActive),
                        new SqlParameter("@DepartmentID", id)
                    }) > 0;
            }

            return false;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Departments WHERE DepartmentID = @DepartmentID";
            SqlParameter[] parameters = {
                new SqlParameter("@DepartmentID", id)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
