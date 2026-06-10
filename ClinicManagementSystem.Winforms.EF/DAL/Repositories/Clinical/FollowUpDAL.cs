using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories.Clinical
{
    public class FollowUpDAL
    {
        public List<FollowUpDTO> GetAll()
        {
            string query = @"
            SELECT
                FollowUpID,
                EncounterID,
                FollowUpDate,
                Status
            FROM FollowUps";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(query);

            List<FollowUpDTO> list = new();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FollowUpDTO
                {
                    FollowUpID =
                        Convert.ToInt32(row["FollowUpID"]),

                    EncounterID =
                        Convert.ToInt32(row["EncounterID"]),

                    FollowUpDate =
                        Convert.ToDateTime(row["FollowUpDate"]),

                    Status =
                        row["Status"].ToString()
                });
            }

            return list;
        }

        public List<FollowUpDTO>
            GetByStatus(params string[] statuses)
        {
            return GetAll()
                .Where(x => statuses.Contains(x.Status))
                .ToList();
        }

        public bool UpdateStatus(
    int followUpId,
    string status)
        {
            string query = @"
UPDATE FollowUps
SET Status = @Status
WHERE FollowUpID = @FollowUpID";

            SqlParameter[] parameters =
            {
        new("@Status", status),
        new("@FollowUpID", followUpId)
    };

            return DatabaseHelper
                .ExecuteNonQuery(
                    query,
                    parameters) > 0;
        }
    }
}