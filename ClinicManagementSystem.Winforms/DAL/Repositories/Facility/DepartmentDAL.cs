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
                return new List<DepartmentDTO>();

            string query = "SELECT DepartmentID, DepartmentName FROM Departments ORDER BY DepartmentName";
            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        public DepartmentDTO GetById(int departmentId)
        {
            if (!SchemaHelper.TableExists("Departments") || departmentId <= 0)
                return null;

            string query = "SELECT DepartmentID, DepartmentName FROM Departments WHERE DepartmentID = @DepartmentID";
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

        public bool Insert(string departmentName)
        {
            string query = "INSERT INTO Departments (DepartmentName) VALUES (@DepartmentName)";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@DepartmentName", departmentName)
            }) > 0;
        }

        public bool Update(int departmentId, string departmentName)
        {
            string query = @"UPDATE Departments 
                             SET DepartmentName = @DepartmentName 
                             WHERE DepartmentID = @DepartmentID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@DepartmentName", departmentName),
                new SqlParameter("@DepartmentID",   departmentId)
            }) > 0;
        }

        public bool Delete(int departmentId)
        {
            string query = "DELETE FROM Departments WHERE DepartmentID = @DepartmentID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@DepartmentID", departmentId)
            }) > 0;
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
                    IsActive = true
                });
            }
            return list;
        }
    }
}