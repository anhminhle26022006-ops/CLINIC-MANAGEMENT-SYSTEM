using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Models;

namespace DAL.Repositories
{
    public class PatientRepository : RepositoryBase,IRepository<Patient>
    {
        public List<Patient> GetAll()
        {
            var patients = new List<Patient>();

            using var conn = GetConnection();

            string query = "SELECT * FROM Patients";

            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                patients.Add(new Patient
                {
                    PatientId = (Guid)reader["PatientId"],
                    PatientCode = reader["PatientCode"].ToString(),
                    FullName = reader["FullName"].ToString()
                });
            }

            return patients;
        }

        public Patient? GetById(Guid id)
        {
            using var conn = GetConnection();

            string query =
                "SELECT * FROM Patients WHERE PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PatientID", id);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Patient
                {
                    PatientId = (Guid)reader["PatientID"],
                    PatientCode = reader["PatientCode"].ToString(),
                    FullName = reader["FullName"].ToString()
                };
            }

            return null;
        }

        public bool Add(Patient patient)
        {
            using var conn = GetConnection();

            string query = @"INSERT INTO Patients
        (
            PatientCode,
            FullName
        )
        VALUES
        (
            @PatientCode,
            @FullName
        )";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PatientCode", patient.PatientCode);
            cmd.Parameters.AddWithValue("@FullName", patient.FullName);

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Patient patient)
        {
            using var conn = GetConnection();

            string query = @" UPDATE Patients
        SET
            PatientCode = @PatientCode,
            FullName = @FullName
        WHERE PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PatientID", patient.PatientId);
            cmd.Parameters.AddWithValue("@PatientCode", patient.PatientCode);
            cmd.Parameters.AddWithValue("@FullName", patient.FullName);

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(Guid id)
        {
            using var conn = GetConnection();

            string query =
                "DELETE FROM Patients WHERE PatientID = @PatientID";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@PatientID", id);

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}