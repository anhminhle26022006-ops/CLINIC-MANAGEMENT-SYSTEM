using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;
using DAL.DataContext;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PatientDAL : IPatientRepository
    {
        public List<PatientDTO> GetAll()
        {
            string query = "SELECT PatientID, PatientCode, FullName AS Name, DOB AS BirthDate, Gender, Phone, Address FROM Patients WHERE PatientCode NOT LIKE 'BS%' AND PatientCode NOT LIKE 'EMP%' AND PatientCode NOT LIKE 'KTV%'";

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

        public int Add(PatientDTO patient)
        {
            string query = IsNewSchema()
                ? "INSERT INTO Patients (PatientCode, FullName, DOB, Gender, Phone, Address) VALUES (@PatientCode, @Name, @BirthDate, @Gender, @Phone, @Address)"
                : "INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES (@PatientCode, @Name, @BirthDate, @Gender, @Phone, @Address)";

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters =
            {
                new SqlParameter("@PatientCode", patient.PatientCode),
                new SqlParameter("@Name", patient.Name),
                new SqlParameter("@BirthDate", patient.BirthDate),
                new SqlParameter("@Gender", patient.Gender),
                new SqlParameter("@Phone", (object)patient.Phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)patient.Address ?? DBNull.Value)
            };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query, parameters));
        }

        private PatientDTO MapRowToDTO(DataRow row)
        {
            return new PatientDTO
            {
                PatientID = Convert.ToInt32(row["PatientID"]),
                PatientCode = row["PatientCode"].ToString(),
                Name = row["Name"].ToString(),
                BirthDate = row["BirthDate"] != DBNull.Value ? Convert.ToDateTime(row["BirthDate"]) : (DateTime?)null,
                Gender = row["Gender"].ToString(),
                Phone = row["Phone"] != DBNull.Value
            ? row["Phone"].ToString()
            : "",
                Address = row["Address"]?.ToString() ?? "",
                BloodType = row["BloodType"]?.ToString() ?? "",
                Allergy = row["Allergy"]?.ToString() ?? ""
            };
        }

        public PatientDTO GetById(int id)
        {
            string query = @"
SELECT
    PatientID,
    PatientCode,
    FullName AS Name,
    DOB AS BirthDate,
    Gender,
    Phone,
    Address,
    BloodType,
    Allergy,
    CreatedAt
FROM Patients
WHERE PatientID = @PatientID";

            SqlParameter[] parameters =
            {
        new SqlParameter("@PatientID", id)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToDTO(dt.Rows[0]);
        }

        public bool Update(PatientDTO patient)
        {
            string query = @"
    UPDATE Patients
    SET FullName = @FullName,
        DOB = @DOB,
        Gender = @Gender,
        Phone = @Phone,
        Address = @Address,
        BloodType = @BloodType,
        Allergy = @Allergy
    WHERE PatientID = @PatientID";

            SqlParameter[] parameters =
            {
        new SqlParameter("@PatientID", patient.PatientID),
        new SqlParameter("@FullName", patient.Name),
        new SqlParameter("@DOB", patient.BirthDate),
        new SqlParameter("@Gender", patient.Gender),
        new SqlParameter("@Phone", patient.Phone),
        new SqlParameter("@Address", patient.Address),
        new SqlParameter("@BloodType", patient.BloodType),
        new SqlParameter("@Allergy", patient.Allergy)
    };

            return DatabaseHelper.ExecuteNonQuery(
                query,
                parameters) > 0;
        }

        public int CountPatients()
        {
            string query = "SELECT COUNT(*) FROM Patients";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int GetNextPatientId()
        {
            string query = @"
        SELECT ISNULL(MAX(PatientID),0) + 1
        FROM Patients";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }
    }
}
