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
    }
}
