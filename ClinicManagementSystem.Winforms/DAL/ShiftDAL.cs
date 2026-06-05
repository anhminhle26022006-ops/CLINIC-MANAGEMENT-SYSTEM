using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class ShiftDAL
    {
        private string connectionString =
            "YOUR_CONNECTION_STRING";

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
                        Guid.Parse(
                            reader["ShiftID"].ToString());

                    dto.ShiftType =
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
                    shift.ShiftType);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    shift.Status);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RequestSwap(
            Guid shiftId,
            Guid employeeId)
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