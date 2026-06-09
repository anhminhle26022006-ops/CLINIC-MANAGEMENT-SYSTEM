using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;
using DAL.DataContext;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class Patient_RecepDAL : IPatientRepository
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
FROM Patients";

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
WHERE FullName LIKE @Term
   OR PatientCode LIKE @Term
   OR Phone LIKE @Term";

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
            string query = @"
        INSERT INTO Patients
        (
            PatientCode,
            FullName,
            Gender,
            DOB,
            Phone,
            Address,
            BloodType,
            Allergy
        )
        VALUES
        (
            @PatientCode,
            @FullName,
            @Gender,
            @DOB,
            @Phone,
            @Address,
            @BloodType,
            @Allergy
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters =
            {
        new SqlParameter("@PatientCode", patient.PatientCode),
        new SqlParameter("@FullName", patient.Name),
        new SqlParameter("@Gender", patient.Gender),
        new SqlParameter("@DOB", patient.BirthDate),
        new SqlParameter("@Phone", (object)patient.Phone ?? DBNull.Value),
        new SqlParameter("@Address", (object)patient.Address ?? DBNull.Value),
        new SqlParameter("@BloodType", (object)patient.BloodType ?? DBNull.Value),
        new SqlParameter("@Allergy", (object)patient.Allergy ?? DBNull.Value)
    };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query, parameters));
        }

        private PatientDTO MapRowToDTO(DataRow row)
        {
            return new PatientDTO
            {
                PatientID = Convert.ToInt32(row["PatientID"]),

                PatientCode = row["PatientCode"]?.ToString() ?? "",

                Name = row["Name"]?.ToString() ?? "",

                BirthDate = row["BirthDate"] != DBNull.Value
        ? Convert.ToDateTime(row["BirthDate"])
        : DateTime.MinValue,

                Gender = row["Gender"]?.ToString() ?? "",

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

        public bool Delete(int id)
        {
            string query = "DELETE FROM Patients WHERE PatientID = @PatientID";
            SqlParameter[] parameters =
            {
                new SqlParameter("@PatientID", id)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
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

