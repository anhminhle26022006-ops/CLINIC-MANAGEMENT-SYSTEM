using DAL.Interfaces.Doctor;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DAL.Repositories.Doctor
{
    public class PatientRepository : IPatientRepository
    {
        public static class Db
        {
            private static string conn =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            public static SqlConnection GetConnection()
                => new SqlConnection(conn);
        }
        public List<PatientDTO> GetAll()
        {
            var list = new List<PatientDTO>();

            using var conn = Db.GetConnection();
            conn.Open();


            var cmd = new SqlCommand("SELECT * FROM Patients", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new PatientDTO
                {
                    PatientID = (int)reader["PatientID"],
                    PatientCode = reader["PatientCode"].ToString(),
                    Name = reader["FullName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    BirthDate = reader["DOB"] as DateTime?,
                    Phone = reader["Phone"].ToString(),
                    Address = reader["Address"].ToString(),
                    BloodType = reader["BloodType"].ToString(),
                    Allergy = reader["Allergy"].ToString()
                });
            }

            return list;
        }

        public int Add(PatientDTO p)
        {
            using var conn = Db.GetConnection();
            conn.Open();


            var cmd = new SqlCommand(@"
            INSERT INTO Patients
            (PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
            VALUES
            (@code,@name,@gender,@dob,@phone,@addr,@blood,@allergy)
        ", conn);

            cmd.Parameters.AddWithValue("@code", p.PatientCode);
            cmd.Parameters.AddWithValue("@name", p.Name);
            cmd.Parameters.AddWithValue("@gender", p.Gender);
            cmd.Parameters.AddWithValue("@dob", (object)p.BirthDate ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@phone", p.Phone);
            cmd.Parameters.AddWithValue("@addr", p.Address);
            cmd.Parameters.AddWithValue("@blood", p.BloodType);
            cmd.Parameters.AddWithValue("@allergy", p.Allergy);

            return cmd.ExecuteNonQuery();
        }

        public PatientDTO GetById(int id)
        {
            using var conn = Db.GetConnection();
            conn.Open();

            var cmd = new SqlCommand("SELECT * FROM Patients WHERE PatientID=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            var r = cmd.ExecuteReader();

            if (r.Read())
            {
                return new PatientDTO
                {
                    PatientID = (int)r["PatientID"],
                    PatientCode = r["PatientCode"].ToString(),
                    Name = r["FullName"].ToString(),
                    Gender = r["Gender"].ToString(),
                    BirthDate = r["DOB"] as DateTime?,
                    Phone = r["Phone"].ToString(),
                    Address = r["Address"].ToString(),
                    BloodType = r["BloodType"].ToString(),
                    Allergy = r["Allergy"].ToString()
                };
            }

            return null;
        }
    }
}
