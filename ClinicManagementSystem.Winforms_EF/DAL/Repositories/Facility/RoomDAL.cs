using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class RoomDAL : IRoomDAL
    {
        public List<RoomDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Rooms"))
            {
                return new List<RoomDTO>();
            }

            string query = @"
                SELECT rm.RoomID,
                       rm.RoomCode,
                       rm.DepartmentID,
                       ISNULL(d.DepartmentName, '') AS DepartmentName,
                       rm.Status
                FROM Rooms rm
                LEFT JOIN Departments d ON rm.DepartmentID = d.DepartmentID
                ORDER BY rm.RoomCode";
            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        public RoomDTO GetById(int roomId)
        {
            if (!SchemaHelper.TableExists("Rooms") || roomId <= 0)
            {
                return null;
            }

            string query = @"
                SELECT rm.RoomID,
                       rm.RoomCode,
                       rm.DepartmentID,
                       ISNULL(d.DepartmentName, '') AS DepartmentName,
                       rm.Status
                FROM Rooms rm
                LEFT JOIN Departments d ON rm.DepartmentID = d.DepartmentID
                WHERE rm.RoomID = @RoomID";
            List<RoomDTO> list = Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@RoomID", roomId)
            }));
            return list.Count > 0 ? list[0] : null;
        }

        public bool Exists(int roomId)
        {
            return GetById(roomId) != null;
        }

        private static List<RoomDTO> Map(DataTable table)
        {
            List<RoomDTO> list = new List<RoomDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new RoomDTO
                {
                    RoomID = Convert.ToInt32(row["RoomID"]),
                    RoomCode = row["RoomCode"].ToString(),
                    DepartmentID = row["DepartmentID"] != DBNull.Value ? Convert.ToInt32(row["DepartmentID"]) : 0,
                    DepartmentName = row["DepartmentName"].ToString(),
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : ""
                });
            }
            return list;
        }
    }
}
