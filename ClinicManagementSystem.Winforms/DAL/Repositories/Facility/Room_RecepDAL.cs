using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class Room_RecepDAL
    {
        public int CountRooms()
        {
            string query =
                "SELECT COUNT(*) FROM Rooms";

            object result =
                DatabaseHelper.ExecuteScalar(query);

            return Convert.ToInt32(result);
        }

        public Room_RecepDTO GetRoomByDepartment(int departmentId)
        {
            string query = @"
    SELECT TOP 1 *
    FROM Rooms
    WHERE DepartmentID = @DepartmentID";

            SqlParameter[] parameters =
            {
        new SqlParameter("@DepartmentID", departmentId)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new Room_RecepDTO
            {
                RoomID = Convert.ToInt32(row["RoomID"]),
                RoomCode = row["RoomCode"].ToString(),
                DepartmentID = Convert.ToInt32(row["DepartmentID"]),
                Status = row["Status"].ToString()
            };
        }

        public Room_RecepDTO GetById(int roomId)
        {
            string query = @"
        SELECT *
        FROM Rooms
        WHERE RoomID = @RoomID";

            SqlParameter[] parameters =
            {
        new SqlParameter("@RoomID", roomId)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new Room_RecepDTO
            {
                RoomID =
                    Convert.ToInt32(row["RoomID"]),

                RoomCode =
                    row["RoomCode"].ToString(),

                DepartmentID =
                    Convert.ToInt32(row["DepartmentID"]),

                Status =
                    row["Status"].ToString()
            };
        }
    }
}
