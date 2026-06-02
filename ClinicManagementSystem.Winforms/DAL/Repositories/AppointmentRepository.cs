using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.Data.SqlClient;
using Models;

namespace DAL.Repositories
{
    public class AppointmentRepository : RepositoryBase, IRepository<Appointment>
    {
        public List<Appointment> GetAll()
        {
            List<Appointment> appointments = new();

            using SqlConnection conn = GetConnection();

            string query = @"
        SELECT *
        FROM Appointments";

            SqlCommand cmd = new(query, conn);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                appointments.Add(new Appointment
                {
                    AppointmentId = (Guid)reader["AppointmentID"],
                    PatientId = (Guid)reader["PatientID"],
                    DepartmentId = (Guid)reader["DepartmentID"],
                    DoctorId = (Guid)reader["DoctorID"],
                    RoomId = reader["RoomID"] == DBNull.Value
                                ? null
                                : (Guid?)reader["RoomID"],

                    AppointmentDate = (DateTime)reader["AppointmentDate"],
                    AppointmentTime = (TimeSpan)reader["AppointmentTime"],

                    Reason = reader["Reason"].ToString(),

                    Status = Enum.Parse<AppointmentStatus>(
                        reader["Status"].ToString()
                    ),

                    CreatedAt = (DateTime)reader["CreatedAt"]
                });
            }

            return appointments;
        }

        public Appointment? GetById(Guid id)
        {
            using SqlConnection conn = GetConnection();

            string query = @"
        SELECT *
        FROM Appointments
        WHERE AppointmentID = @AppointmentID";

            SqlCommand cmd = new(query, conn);

            cmd.Parameters.AddWithValue("@AppointmentID", id);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Appointment
                {
                    AppointmentId = (Guid)reader["AppointmentID"],
                    PatientId = (Guid)reader["PatientID"],
                    DepartmentId = (Guid)reader["DepartmentID"],
                    DoctorId = (Guid)reader["DoctorID"],
                    RoomId = reader["RoomID"] == DBNull.Value
                                ? null
                                : (Guid?)reader["RoomID"],

                    AppointmentDate = (DateTime)reader["AppointmentDate"],
                    AppointmentTime = (TimeSpan)reader["AppointmentTime"],

                    Reason = reader["Reason"].ToString(),

                    Status = Enum.Parse<AppointmentStatus>(
                        reader["Status"].ToString()
                    ),

                    CreatedAt = (DateTime)reader["CreatedAt"]
                };
            }

            return null;
        }

        public bool Add(Appointment appointment)
        {
            using SqlConnection conn = GetConnection();

            string query = @"
        INSERT INTO Appointments
        (
            AppointmentID,
            PatientID,
            DepartmentID,
            DoctorID,
            RoomID,
            AppointmentDate,
            AppointmentTime,
            Reason,
            Status,
            CreatedAt
        )
        VALUES
        (
            @AppointmentID,
            @PatientID,
            @DepartmentID,
            @DoctorID,
            @RoomID,
            @AppointmentDate,
            @AppointmentTime,
            @Reason,
            @Status,
            @CreatedAt
        )";

            SqlCommand cmd = new(query, conn);

            cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentId);
            cmd.Parameters.AddWithValue("@PatientID", appointment.PatientId);
            cmd.Parameters.AddWithValue("@DepartmentID", appointment.DepartmentId);
            cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@RoomID",
                appointment.RoomId ?? (object)DBNull.Value);

            cmd.Parameters.AddWithValue("@AppointmentDate",
                appointment.AppointmentDate);

            cmd.Parameters.AddWithValue("@AppointmentTime",
                appointment.AppointmentTime);

            cmd.Parameters.AddWithValue("@Reason",
                appointment.Reason ?? string.Empty);

            cmd.Parameters.AddWithValue("@Status",
                appointment.Status.ToString());

            cmd.Parameters.AddWithValue("@CreatedAt",
                appointment.CreatedAt);

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Appointment appointment)
        {
            using SqlConnection conn = GetConnection();

            string query = @"
        UPDATE Appointments
        SET
            PatientID = @PatientID,
            DepartmentID = @DepartmentID,
            DoctorID = @DoctorID,
            RoomID = @RoomID,
            AppointmentDate = @AppointmentDate,
            AppointmentTime = @AppointmentTime,
            Reason = @Reason,
            Status = @Status
        WHERE AppointmentID = @AppointmentID";

            SqlCommand cmd = new(query, conn);

            cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentId);
            cmd.Parameters.AddWithValue("@PatientID", appointment.PatientId);
            cmd.Parameters.AddWithValue("@DepartmentID", appointment.DepartmentId);
            cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorId);

            cmd.Parameters.AddWithValue("@RoomID",
                appointment.RoomId ?? (object)DBNull.Value);

            cmd.Parameters.AddWithValue("@AppointmentDate",
                appointment.AppointmentDate);

            cmd.Parameters.AddWithValue("@AppointmentTime",
                appointment.AppointmentTime);

            cmd.Parameters.AddWithValue("@Reason",
                appointment.Reason ?? string.Empty);

            cmd.Parameters.AddWithValue("@Status",
                appointment.Status.ToString());

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(Guid id)
        {
            using SqlConnection conn = GetConnection();

            string query = @"
        DELETE FROM Appointments
        WHERE AppointmentID = @AppointmentID";

            SqlCommand cmd = new(query, conn);

            cmd.Parameters.AddWithValue("@AppointmentID", id);

            conn.Open();

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
