using System;
using System.Data;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class AppointmentDAL
    {
        public int CountNewPatients()
        {
            string query = @"
                SELECT COUNT(*)
                FROM
                (
                    SELECT PatientID,
                           MIN(AppointmentDate) AS FirstAppointment
                    FROM Appointments
                    GROUP BY PatientID
                ) t
                WHERE MONTH(FirstAppointment) = MONTH(GETDATE())
                  AND YEAR(FirstAppointment) = YEAR(GETDATE())";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int CountRevisitPatients()
        {
            string query = @"
                SELECT COUNT(*)
                FROM
                (
                    SELECT PatientID
                    FROM Appointments
                    GROUP BY PatientID
                    HAVING COUNT(*) > 1
                ) t";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int CountUpcomingAppointments()
        {
            string query = @"
                SELECT COUNT(*)
                FROM Appointments
                WHERE AppointmentDate >= GETDATE()
                  AND Status <> N'Cancelled'";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public int CountAppointmentsToday()
        {
            string query = @"
                SELECT COUNT(*)
                FROM Appointments
                WHERE CAST(AppointmentDate AS DATE)
                      = CAST(GETDATE() AS DATE)";

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(query));
        }

        public bool Create(AppointmentDTO appointment)
        {
            string query = @"
    INSERT INTO Appointments
    (
        PatientID,
        DoctorID,
        DepartmentID,
        RoomID,
        AppointmentDate,
        Status
    )
    VALUES
    (
        @PatientID,
        @DoctorID,
        @DepartmentID,
        @RoomID,
        @AppointmentDate,
        @Status
    )";

            SqlParameter[] parameters =
            {
        new SqlParameter("@PatientID", appointment.PatientID),
        new SqlParameter("@DoctorID", appointment.DoctorID),
        new SqlParameter("@DepartmentID", appointment.DepartmentID),
        new SqlParameter("@RoomID", appointment.RoomID),
        new SqlParameter("@AppointmentDate", appointment.AppointmentDate),
        new SqlParameter("@Status", appointment.Status)
    };

            return DatabaseHelper.ExecuteNonQuery(
                query,
                parameters) > 0;
        }

        public int CountAppointmentsByDoctorAndDate(
     int doctorId,
     DateTime date)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorID = @DoctorID
          AND CAST(AppointmentDate AS DATE) = @Date";

            SqlParameter[] parameters =
            {
        new SqlParameter("@DoctorID", doctorId),
        new SqlParameter("@Date", date.Date)
    };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters));
        }

        public bool ExistsAppointment(
    int doctorId,
    DateTime appointmentDate)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorID = @DoctorID
          AND AppointmentDate = @AppointmentDate";

            SqlParameter[] parameters =
            {
        new SqlParameter("@DoctorID", doctorId),
        new SqlParameter("@AppointmentDate", appointmentDate)
    };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters)) > 0;
        }

        public int CountAppointmentsByStatusToday(
    string status)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE CAST(AppointmentDate AS DATE)
              = CAST(GETDATE() AS DATE)
          AND Status = @Status";

            SqlParameter[] parameters =
            {
        new SqlParameter("@Status", status)
    };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters));
        }

        public DataTable GetAppointmentsToday()
        {
            string query = @"
        SELECT
            a.AppointmentID,
            CONVERT(VARCHAR(5), a.AppointmentDate, 108) AS [Giờ khám],
            p.FullName AS [Bệnh nhân],
            e.FullName AS [Bác sĩ],
            d.DepartmentName AS [Chuyên khoa],
            r.RoomCode AS [Phòng],
            a.Status AS [Trạng thái]
        FROM Appointments a
        INNER JOIN Patients p
            ON a.PatientID = p.PatientID
        INNER JOIN Employees e
            ON a.DoctorID = e.EmployeeID
        INNER JOIN Departments d
            ON a.DepartmentID = d.DepartmentID
        INNER JOIN Rooms r
            ON a.RoomID = r.RoomID
        WHERE CAST(a.AppointmentDate AS DATE)
              = CAST(GETDATE() AS DATE)
        ORDER BY a.AppointmentDate";

            return DatabaseHelper.ExecuteQuery(query);
        }

        public bool UpdateStatus(
    int appointmentId,
    string status)
        {
            string query = @"
        UPDATE Appointments
        SET Status = @Status
        WHERE AppointmentID = @AppointmentID";

            SqlParameter[] parameters =
            {
        new("@Status", status),
        new("@AppointmentID", appointmentId)
    };

            return DatabaseHelper.ExecuteNonQuery(
                query,
                parameters) > 0;
        }

        public DataTable SearchAppointmentsToday(
     string keyword,
     string department,
     string status)
        {
            string query = @"
    SELECT
        a.AppointmentID,
        CONVERT(VARCHAR(5), a.AppointmentDate, 108) AS [Giờ khám],
        p.FullName AS [Bệnh nhân],
        e.FullName AS [Bác sĩ],
        d.DepartmentName AS [Chuyên khoa],
        r.RoomCode AS [Phòng],
        a.Status AS [Trạng thái]
    FROM Appointments a
    INNER JOIN Patients p
        ON a.PatientID = p.PatientID
    INNER JOIN Employees e
        ON a.DoctorID = e.EmployeeID
    INNER JOIN Departments d
        ON a.DepartmentID = d.DepartmentID
    INNER JOIN Rooms r
        ON a.RoomID = r.RoomID
    WHERE CAST(a.AppointmentDate AS DATE)
          = CAST(GETDATE() AS DATE)

      AND (@Keyword = ''
           OR p.FullName LIKE '%' + @Keyword + '%'
           OR p.PatientCode LIKE '%' + @Keyword + '%'
           OR p.Phone LIKE '%' + @Keyword + '%')

      AND (@Department = ''
           OR d.DepartmentName = @Department)

      AND (@Status = ''
           OR a.Status = @Status)

    ORDER BY a.AppointmentDate";

            SqlParameter[] parameters =
            {
        new("@Keyword", keyword),
        new("@Department", department),
        new("@Status", status)
    };

            return DatabaseHelper.ExecuteQuery(
                query,
                parameters);
        }

        public int CountAppointmentsByDoctorAndStatusToday(
    int doctorId,
    string status)
        {
            string query = @"
        SELECT COUNT(*)
        FROM Appointments
        WHERE DoctorID = @DoctorID
          AND Status = @Status
          AND CAST(AppointmentDate AS DATE)
              = CAST(GETDATE() AS DATE)";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId),
        new("@Status", status)
    };

            return Convert.ToInt32(
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters));
        }

        public string GetCurrentPatientByDoctor(
    int doctorId)
        {
            string query = @"
        SELECT TOP 1 p.FullName
        FROM Appointments a
        INNER JOIN Patients p
            ON p.PatientID = a.PatientID
        WHERE a.DoctorID = @DoctorID
          AND a.Status = 'Examining'
        ORDER BY a.AppointmentDate";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId)
    };

            object result =
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters);

            return result?.ToString() ?? "";
        }

        public List<WaitingPatientDTO>
GetWaitingPatientsByDoctor(
    int doctorId)
        {
            string query = @"
    SELECT
        p.FullName,
        p.PatientCode,
        a.AppointmentDate
    FROM Appointments a
    INNER JOIN Patients p
        ON a.PatientID = p.PatientID
    WHERE a.DoctorID = @DoctorID
      AND a.Status = 'Waiting'
      AND CAST(a.AppointmentDate AS DATE)
          = CAST(GETDATE() AS DATE)
    ORDER BY a.AppointmentDate";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            List<WaitingPatientDTO> list =
                new();

            int queueNumber = 1;

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new WaitingPatientDTO
                {
                    QueueNumber = queueNumber++,

                    PatientName =
                        row["FullName"]
                            .ToString(),

                    PatientCode =
                        row["PatientCode"]
                            .ToString(),

                    AppointmentTime =
                        Convert.ToDateTime(
                            row["AppointmentDate"])
                });
            }

            return list;
        }

        public int GetCurrentQueueNumber(
    int doctorId)
        {
            string query = @"
    SELECT AppointmentID
    FROM Appointments
    WHERE DoctorID = @DoctorID
      AND Status = 'Examining'
      AND CAST(AppointmentDate AS DATE)
          = CAST(GETDATE() AS DATE)";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId)
    };

            object currentAppointmentId =
    DatabaseHelper.ExecuteScalar(
        query,
        new SqlParameter[]
        {
            new("@DoctorID", doctorId)
        });

            if (currentAppointmentId == null)
                return 0;

            string orderQuery = @"
    SELECT AppointmentID
    FROM Appointments
    WHERE DoctorID = @DoctorID
      AND CAST(AppointmentDate AS DATE)
          = CAST(GETDATE() AS DATE)
    ORDER BY AppointmentDate";

            DataTable dt =
    DatabaseHelper.ExecuteQuery(
        orderQuery,
        new SqlParameter[]
        {
            new("@DoctorID", doctorId)
        });

            int queueNumber = 1;

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(
                        row["AppointmentID"])
                    ==
                    Convert.ToInt32(
                        currentAppointmentId))
                {
                    return queueNumber;
                }

                queueNumber++;
            }

            return 0;
        }

        public string GetCurrentPatientCodeByDoctor(
    int doctorId)
        {
            string query = @"
    SELECT TOP 1 p.PatientCode
    FROM Appointments a
    INNER JOIN Patients p
        ON a.PatientID = p.PatientID
    WHERE a.DoctorID = @DoctorID
      AND a.Status = 'Examining'
      AND CAST(a.AppointmentDate AS DATE)
          = CAST(GETDATE() AS DATE)";

            object result =
    DatabaseHelper.ExecuteScalar(
        query,
        new SqlParameter[]
        {
            new("@DoctorID", doctorId)
        });

            return result?.ToString() ?? "";
        }
    }
}