using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class DoctorScheduleDAL
    {
        public int? GetRoomIdByDoctor(int doctorId)
        {
            string query = @"
        SELECT TOP 1 RoomID
        FROM DoctorSchedules
        WHERE DoctorID = @DoctorID";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId)
    };

            object result =
                DatabaseHelper.ExecuteScalar(
                    query,
                    parameters);

            if (result == null ||
                result == DBNull.Value)
                return null;

            return Convert.ToInt32(result);
        }

        public DoctorScheduleDTO GetSchedule(
    int doctorId,
    DateTime workDate)
        {
            string query = @"
        SELECT TOP 1 *
        FROM DoctorSchedules
        WHERE DoctorID = @DoctorID
          AND CAST(WorkDate AS DATE) =
              CAST(@WorkDate AS DATE)";

            SqlParameter[] parameters =
            {
        new("@DoctorID", doctorId),
        new("@WorkDate", workDate)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new DoctorScheduleDTO
            {
                ScheduleID =
                    Convert.ToInt32(
                        row["ScheduleID"]),

                DoctorID =
                    Convert.ToInt32(
                        row["DoctorID"]),

                WorkDate =
                    Convert.ToDateTime(
                        row["WorkDate"]),

                StartTime =
                    (TimeSpan)row["StartTime"],

                EndTime =
                    (TimeSpan)row["EndTime"],

                RoomID =
                    Convert.ToInt32(
                        row["RoomID"])
            };
        }

        public int CountActiveRoomsToday()
        {
            string query = @"
        SELECT COUNT(DISTINCT RoomID)
        FROM DoctorSchedules
        WHERE WorkDate = CAST(GETDATE() AS DATE)";

            object result = DatabaseHelper.ExecuteScalar(query);

            return result == null
                ? 0
                : Convert.ToInt32(result);
        }

        public List<DoctorQueueDTO> GetDoctorQueues()
        {
            string query = @"
    SELECT
    e.EmployeeID,
    e.FullName,
    d.DepartmentName,
    ISNULL(r.RoomCode, '-') AS RoomCode
FROM Employees e
INNER JOIN Departments d
    ON d.DepartmentID = e.DepartmentID
LEFT JOIN DoctorSchedules ds
    ON ds.DoctorID = e.EmployeeID
    AND CAST(ds.WorkDate AS DATE)
        = CAST(GETDATE() AS DATE)
LEFT JOIN Rooms r
    ON r.RoomID = ds.RoomID
WHERE e.RoleID =
(
    SELECT RoleID
    FROM Roles
    WHERE RoleName = 'Doctor'
)";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(query);

            List<DoctorQueueDTO> list = new();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DoctorQueueDTO
                {
                    DoctorId =
                        Convert.ToInt32(
                            row["EmployeeID"]),

                    DoctorName =
                        row["FullName"].ToString(),

                    DepartmentName =
                        row["DepartmentName"].ToString(),

                    RoomCode =
                        row["RoomCode"].ToString(),

                    Shift = "Cả ngày"
                });
            }

            return list;
        }
    }
}
