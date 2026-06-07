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
    public class EmployeeDAL
    {
        public List<EmployeeDTO> GetDoctorsByDepartment(int departmentId)
        {
            string query = @"
    SELECT EmployeeID,
           FullName
    FROM Employees
    WHERE DepartmentID = @DepartmentID
      AND RoleID =
      (
          SELECT RoleID
          FROM Roles
          WHERE RoleName = 'Doctor'
      )";

            SqlParameter[] parameters =
            {
        new SqlParameter("@DepartmentID", departmentId)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(query, parameters);

            List<EmployeeDTO> doctors = new();

            foreach (DataRow row in dt.Rows)
            {
                doctors.Add(new EmployeeDTO
                {
                    EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                    FullName = row["FullName"].ToString()
                });
            }

            return doctors;
        }

        public EmployeeDTO GetById(int employeeId)
        {
            string query = @"
SELECT EmployeeID,
       FullName
FROM Employees
WHERE EmployeeID = @EmployeeID";

            SqlParameter[] parameters =
            {
        new SqlParameter(
            "@EmployeeID",
            employeeId)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new EmployeeDTO
            {
                EmployeeID =
                    Convert.ToInt32(
                        row["EmployeeID"]),

                FullName =
                    row["FullName"]
                    .ToString()
            };
        }
    }
}
