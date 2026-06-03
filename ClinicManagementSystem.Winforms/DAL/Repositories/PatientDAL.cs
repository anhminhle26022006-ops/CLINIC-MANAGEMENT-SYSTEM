using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;
using DAL.DataContext;

namespace DAL.Repositories
{
    public class PatientDAL
    {
        private bool IsNewSchema()
        {
            string checkColumnQuery = "SELECT COUNT(*) FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[Patients]') AND name = 'Name'";
            int nameColumnExists = 0;
            try
            {
                nameColumnExists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkColumnQuery));
            }
            catch { }
            return nameColumnExists == 0;
        }

        public List<PatientDTO> GetAll()
        {
            string query = IsNewSchema() 
                ? "SELECT PatientID, PatientCode, FullName AS Name, DOB AS BirthDate, Gender, Phone, Address FROM Patients"
                : "SELECT * FROM Patients";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<PatientDTO> list = new List<PatientDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToDTO(row));
            }
            return list;
        }

        public List<PatientDTO> Search(string term)
        {
            string query = IsNewSchema()
                ? "SELECT PatientID, PatientCode, FullName AS Name, DOB AS BirthDate, Gender, Phone, Address FROM Patients WHERE FullName LIKE @Term OR PatientCode LIKE @Term OR Phone LIKE @Term"
                : "SELECT * FROM Patients WHERE Name LIKE @Term OR PatientCode LIKE @Term OR Phone LIKE @Term";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Term", "%" + term + "%")
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            List<PatientDTO> list = new List<PatientDTO>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapRowToDTO(row));
            }
            return list;
        }

        public bool Add(PatientDTO patient)
        {
            string query = IsNewSchema()
                ? "INSERT INTO Patients (PatientCode, FullName, DOB, Gender, Phone, Address) VALUES (@PatientCode, @Name, @BirthDate, @Gender, @Phone, @Address)"
                : "INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES (@PatientCode, @Name, @BirthDate, @Gender, @Phone, @Address)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PatientCode", patient.PatientCode),
                new SqlParameter("@Name", patient.Name),
                new SqlParameter("@BirthDate", patient.BirthDate),
                new SqlParameter("@Gender", patient.Gender),
                new SqlParameter("@Phone", (object)patient.Phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)patient.Address ?? DBNull.Value)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        private PatientDTO MapRowToDTO(DataRow row)
        {
            return new PatientDTO
            {
                PatientID = Convert.ToInt32(row["PatientID"]),
                PatientCode = row["PatientCode"].ToString(),
                Name = row["Name"].ToString(),
                BirthDate = Convert.ToDateTime(row["BirthDate"]),
                Gender = row["Gender"].ToString(),
                Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : ""
            };
        }
    }
}

