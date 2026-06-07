using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ShiftDAL
    {
        private string connectionString =
            "Data Source=DESKTOP-KF6OV10;Database=CMS;Integrated Security=True;Trust Server Certificate=True";

        public List<ShiftDTO> GetAllShifts()
        {
            List<ShiftDTO> list =
                new List<ShiftDTO>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NurseShifts";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    ShiftDTO dto =
                        new ShiftDTO();

                    dto.ShiftID =
                    Convert.ToInt32(reader["ShiftID"]);

                    dto.ShiftName =
                        reader["ShiftType"].ToString();

                    dto.Status =
                        reader["Status"].ToString();

                    list.Add(dto);
                }
            }

            return list;
        }

        public bool InsertShift(ShiftDTO shift)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                INSERT INTO NurseShifts
                (
                    NurseID,
                    ShiftDate,
                    ShiftType,
                    Status
                )
                VALUES
                (
                    @NurseID,
                    @ShiftDate,
                    @ShiftType,
                    @Status
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@NurseID",
                    shift.EmployeeID);

                cmd.Parameters.AddWithValue(
                    "@ShiftDate",
                    shift.ShiftDate);

                cmd.Parameters.AddWithValue(
                    "@ShiftType",
                    shift.ShiftName);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    shift.Status);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RequestSwap(int shiftId, int employeeId)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE NurseShifts
                SET Status = 'PendingSwap'
                WHERE ShiftID = @ShiftID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@ShiftID",
                    shiftId);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}