using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;

namespace DAL.Repositories
{
    public class RoleDAL
    {
        public List<RoleDTO> GetAll()
        {
            string query =
                "SELECT RoleID, RoleName FROM Roles ORDER BY RoleName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<RoleDTO> list = new();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new RoleDTO
                {
                    RoleID = Convert.ToInt32(row["RoleID"]),
                    RoleName = row["RoleName"].ToString()
                });
            }

            return list;
        }
    }
}