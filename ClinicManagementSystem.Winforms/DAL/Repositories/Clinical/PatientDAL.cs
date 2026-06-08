using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class PatientDAL
    {
        public List<PatientDTO> GetAll()
        {
            if (!SchemaHelper.TableExists("Patients"))
                return new List<PatientDTO>();
            return Map(DatabaseHelper.ExecuteQuery(
                "SELECT PatientID, PatientCode, Name, BirthDate, Gender, Phone, Address, BloodType, Allergy FROM Patients ORDER BY Name"));
        }

        public List<PatientDTO> Search(string term)
        {
            if (!SchemaHelper.TableExists("Patients"))
                return new List<PatientDTO>();
            string query = @"
                SELECT PatientID, PatientCode, Name, BirthDate, Gender, Phone, Address, BloodType, Allergy
                FROM Patients
                WHERE Name LIKE @Term OR PatientCode LIKE @Term OR Phone LIKE @Term
                ORDER BY Name";
            return Map(DatabaseHelper.ExecuteQuery(query,
                new[] { new SqlParameter("@Term", "%" + term + "%") }));
        }

        public PatientDTO GetById(int id)
        {
            if (!SchemaHelper.TableExists("Patients") || id <= 0) return null;
            var list = Map(DatabaseHelper.ExecuteQuery(
                "SELECT PatientID, PatientCode, Name, BirthDate, Gender, Phone, Address, BloodType, Allergy FROM Patients WHERE PatientID = @ID",
                new[] { new SqlParameter("@ID", id) }));
            return list.Count > 0 ? list[0] : null;
        }

        public bool Add(PatientDTO patient)
        {
            if (!SchemaHelper.TableExists("Patients")) return false;
            string query = @"
                INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address, BloodType, Allergy)
                VALUES (@Code, @Name, @BirthDate, @Gender, @Phone, @Address, @BloodType, @Allergy)";
            return DatabaseHelper.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Code",      patient.PatientCode ?? ""),
                new SqlParameter("@Name",      patient.Name ?? ""),
                new SqlParameter("@BirthDate", patient.BirthDate.HasValue ? (object)patient.BirthDate.Value : DBNull.Value),
                new SqlParameter("@Gender",    patient.Gender    != null ? (object)patient.Gender    : DBNull.Value),
                new SqlParameter("@Phone",     patient.Phone     != null ? (object)patient.Phone     : DBNull.Value),
                new SqlParameter("@Address",   patient.Address   != null ? (object)patient.Address   : DBNull.Value),
                new SqlParameter("@BloodType", patient.BloodType != null ? (object)patient.BloodType : DBNull.Value),
                new SqlParameter("@Allergy",   patient.Allergy   != null ? (object)patient.Allergy   : DBNull.Value)
            }) > 0;
        }

        public bool Update(PatientDTO patient)
        {
            if (!SchemaHelper.TableExists("Patients")) return false;
            string query = @"
                UPDATE Patients SET
                    Name      = @Name,
                    BirthDate = @BirthDate,
                    Gender    = @Gender,
                    Phone     = @Phone,
                    Address   = @Address,
                    BloodType = @BloodType,
                    Allergy   = @Allergy
                WHERE PatientID = @ID";
            return DatabaseHelper.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Name",      patient.Name ?? ""),
                new SqlParameter("@BirthDate", patient.BirthDate.HasValue ? (object)patient.BirthDate.Value : DBNull.Value),
                new SqlParameter("@Gender",    patient.Gender    != null ? (object)patient.Gender    : DBNull.Value),
                new SqlParameter("@Phone",     patient.Phone     != null ? (object)patient.Phone     : DBNull.Value),
                new SqlParameter("@Address",   patient.Address   != null ? (object)patient.Address   : DBNull.Value),
                new SqlParameter("@BloodType", patient.BloodType != null ? (object)patient.BloodType : DBNull.Value),
                new SqlParameter("@Allergy",   patient.Allergy   != null ? (object)patient.Allergy   : DBNull.Value),
                new SqlParameter("@ID",        patient.PatientID)
            }) > 0;
        }

        public int CountPatients()
        {
            if (!SchemaHelper.TableExists("Patients")) return 0;
            object r = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Patients");
            return r != null ? Convert.ToInt32(r) : 0;
        }

        public string GenerateNewPatientCode()
        {
            if (!SchemaHelper.TableExists("Patients"))
                return "BN" + DateTime.Now.ToString("yyMMddHHmmss");
            object r = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Patients");
            int count = r != null ? Convert.ToInt32(r) : 0;
            return "BN" + (count + 1).ToString("D5");
        }

        private static List<PatientDTO> Map(DataTable table)
        {
            var list = new List<PatientDTO>();
            foreach (DataRow row in table.Rows)
                list.Add(new PatientDTO
                {
                    PatientID = Convert.ToInt32(row["PatientID"]),
                    PatientCode = row["PatientCode"].ToString(),
                    Name = row["Name"].ToString(),
                    BirthDate = row["BirthDate"] != DBNull.Value ? Convert.ToDateTime(row["BirthDate"]) : (DateTime?)null,
                    Gender = row["Gender"] != DBNull.Value ? row["Gender"].ToString() : "",
                    Phone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : "",
                    Address = row["Address"] != DBNull.Value ? row["Address"].ToString() : "",
                    BloodType = row["BloodType"] != DBNull.Value ? row["BloodType"].ToString() : "",
                    Allergy = row["Allergy"] != DBNull.Value ? row["Allergy"].ToString() : ""
                });
            return list;
        }
    }
}