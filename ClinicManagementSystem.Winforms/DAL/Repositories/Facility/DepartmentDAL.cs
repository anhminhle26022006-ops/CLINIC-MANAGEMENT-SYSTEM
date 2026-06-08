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

            string query = @"
                SELECT DepartmentID, DepartmentName,
                       ISNULL(Description,'') AS Description,
                       ISNULL(IsActive,1)     AS IsActive
                FROM Departments
                ORDER BY DepartmentName";
            return Map(DatabaseHelper.ExecuteQuery(query));
        }

        public DepartmentDTO GetById(int id)
        {
            if (!SchemaHelper.TableExists("Departments") || id <= 0) return null;

            var list = Map(DatabaseHelper.ExecuteQuery(
                @"SELECT DepartmentID, DepartmentName,
                         ISNULL(Description,'') AS Description,
                         ISNULL(IsActive,1)     AS IsActive
                  FROM Departments WHERE DepartmentID = @ID",
                new[] { new SqlParameter("@ID", id) }));
            return list.Count > 0 ? list[0] : null;
        }

        public bool Exists(int id)
        {
            if (!SchemaHelper.TableExists("Departments") || id <= 0) return false;
            object r = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Departments WHERE DepartmentID=@ID",
                new[] { new SqlParameter("@ID", id) });
            return Convert.ToInt32(r) > 0;
        }

        public bool NameExists(string name, int excludeId = 0)
        {
            if (!SchemaHelper.TableExists("Departments")) return false;
            object r = DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Departments WHERE DepartmentName=@N AND DepartmentID<>@ExID",
                new[] { new SqlParameter("@N", name.Trim()), new SqlParameter("@ExID", excludeId) });
            return Convert.ToInt32(r) > 0;
        }

        public bool Add(DepartmentDTO dto)
        {
            if (!SchemaHelper.TableExists("Departments")) return false;

            bool hasDesc = SchemaHelper.ColumnExists("Departments", "Description");
            bool hasIsActive = SchemaHelper.ColumnExists("Departments", "IsActive");

            string query = hasDesc && hasIsActive
                ? "INSERT INTO Departments (DepartmentName, Description, IsActive) VALUES (@N,@D,@A)"
                : hasDesc
                    ? "INSERT INTO Departments (DepartmentName, Description) VALUES (@N,@D)"
                    : "INSERT INTO Departments (DepartmentName) VALUES (@N)";

            var ps = new List<SqlParameter> { new SqlParameter("@N", dto.DepartmentName.Trim()) };
            if (hasDesc) ps.Add(new SqlParameter("@D", (object)dto.Description ?? DBNull.Value));
            if (hasIsActive) ps.Add(new SqlParameter("@A", dto.IsActive ? 1 : 0));

            return DatabaseHelper.ExecuteNonQuery(query, ps.ToArray()) > 0;
        }

        public bool Update(DepartmentDTO dto)
        {
            if (!SchemaHelper.TableExists("Departments")) return false;

            bool hasDesc = SchemaHelper.ColumnExists("Departments", "Description");
            bool hasIsActive = SchemaHelper.ColumnExists("Departments", "IsActive");

            string sets = "DepartmentName=@N";
            if (hasDesc) sets += ", Description=@D";
            if (hasIsActive) sets += ", IsActive=@A";

            var ps = new List<SqlParameter>
            {
                new SqlParameter("@N",  dto.DepartmentName.Trim()),
                new SqlParameter("@ID", dto.DepartmentID)
            };
            if (hasDesc) ps.Insert(1, new SqlParameter("@D", (object)dto.Description ?? DBNull.Value));
            if (hasIsActive) ps.Insert(hasDesc ? 2 : 1, new SqlParameter("@A", dto.IsActive ? 1 : 0));

            return DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Departments SET {sets} WHERE DepartmentID=@ID", ps.ToArray()) > 0;
        }

        public bool Delete(int id)
        {
            if (!SchemaHelper.TableExists("Departments")) return false;

            if (SchemaHelper.ColumnExists("Departments", "IsActive"))
                return DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Departments SET IsActive=0 WHERE DepartmentID=@ID",
                    new[] { new SqlParameter("@ID", id) }) > 0;

            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM Departments WHERE DepartmentID=@ID",
                new[] { new SqlParameter("@ID", id) }) > 0;
        }

        private static List<DepartmentDTO> Map(DataTable t)
        {
            var list = new List<DepartmentDTO>();
            foreach (DataRow r in t.Rows)
                list.Add(new DepartmentDTO
                {
                    DepartmentID = Convert.ToInt32(r["DepartmentID"]),
                    DepartmentName = r["DepartmentName"].ToString(),
                    Description = r.Table.Columns.Contains("Description") && r["Description"] != DBNull.Value
                                        ? r["Description"].ToString() : "",
                    IsActive = r.Table.Columns.Contains("IsActive")
                                        ? Convert.ToBoolean(r["IsActive"]) : true
                });
            return list;
        }
    }
}