using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;
using DTO;

namespace DAL.Repositories
{
    public class DepartmentDAL
    {
        public List<DepartmentDTO> GetAll()
        {
            string query = @"
        SELECT DepartmentID,
               DepartmentName
        FROM Departments
        ORDER BY DepartmentName";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            List<DepartmentDTO> list = new();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DepartmentDTO
                {
                    DepartmentID = Convert.ToInt32(row["DepartmentID"]),
                    DepartmentName = row["DepartmentName"].ToString()
                });
            }

            return list;
        }
    }
}
