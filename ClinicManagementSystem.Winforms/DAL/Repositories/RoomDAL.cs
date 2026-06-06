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
    public class RoomDAL
    {
        public RoomDTO GetRoomByDepartment(int departmentId)
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

            return new RoomDTO
            {
                RoomID = Convert.ToInt32(row["RoomID"]),
                RoomCode = row["RoomCode"].ToString(),
                DepartmentID = Convert.ToInt32(row["DepartmentID"]),
                Status = row["Status"].ToString()
            };
        }

        public RoomDTO GetById(int roomId)
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

            return new RoomDTO
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
