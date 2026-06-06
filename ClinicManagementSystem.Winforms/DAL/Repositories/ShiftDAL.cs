using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class ShiftDAL
    {
        private string GetTableName()
        {
            try
            {
                string checkQuery = "SELECT COUNT(*) FROM sys.tables WHERE name = 'TechnicianShifts'";
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));
                if (count > 0) return "TechnicianShifts";
            }
            catch { }
            return "Shifts";
        }

        public List<ShiftDTO> GetAll()
        {
            string tableName = GetTableName();
            string query = $"SELECT * FROM {tableName} ORDER BY ShiftDate ASC, ShiftName ASC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<ShiftDTO> list = new List<ShiftDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ShiftDTO
                {
                    ShiftID = Convert.ToInt32(row["ShiftID"]),
                    ShiftDate = Convert.ToDateTime(row["ShiftDate"]),
                    ShiftName = row["ShiftName"].ToString(),
                    Room = row["Room"].ToString(),
                    Department = row["Department"].ToString(),
                    Status = row["Status"].ToString(),
                    TechnicianName = row.Table.Columns.Contains("TechnicianName") ? row["TechnicianName"].ToString() : ""
                });
            }
            return list;
        }

        public bool Add(ShiftDTO shift)
        {
            string tableName = GetTableName();
            string query = $"INSERT INTO {tableName} (ShiftDate, ShiftName, Room, Department, Status, TechnicianName) VALUES (@ShiftDate, @ShiftName, @Room, @Department, @Status, @TechnicianName)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ShiftDate", shift.ShiftDate.Date),
                new SqlParameter("@ShiftName", shift.ShiftName),
                new SqlParameter("@Room", shift.Room),
                new SqlParameter("@Department", shift.Department),
                new SqlParameter("@Status", shift.Status),
                new SqlParameter("@TechnicianName", shift.TechnicianName)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public int GetCount()
        {
            string tableName = GetTableName();
            string query = $"SELECT COUNT(*) FROM {tableName}";
            object res = DatabaseHelper.ExecuteScalar(query);
            return res != null ? Convert.ToInt32(res) : 0;
        }
    }
}

