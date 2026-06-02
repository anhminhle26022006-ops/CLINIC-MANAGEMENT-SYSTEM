using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MOMO_QR_DANANG.Models;

namespace MOMO_QR_DANANG.DataAccess
{
    public class PatientDAL
    {
        public List<PatientDTO> GetAll()
        {
            string query = "SELECT * FROM Patients";
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
            string query = "SELECT * FROM Patients WHERE Name LIKE @Term OR PatientCode LIKE @Term OR Phone LIKE @Term";
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
            string query = "INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES (@PatientCode, @Name, @BirthDate, @Gender, @Phone, @Address)";
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

