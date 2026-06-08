using System.Data;
using Microsoft.Data.SqlClient;
using DAL.DataContext;
using DTO;

namespace DAL.Repositories
{
    public class MedicalRecordDAL
    {
        private MedicalRecordDTO
            MapRowToDTO(DataRow row)
        {
            return new MedicalRecordDTO
            {
                RecordID =
                    Convert.ToInt32(
                        row["RecordID"]),

                EncounterID =
                    Convert.ToInt32(
                        row["EncounterID"]),

                Diagnosis =
                    row["Diagnosis"]?.ToString(),

                Conclusion =
                    row["Conclusion"]?.ToString(),

                Notes =
                    row["Notes"]?.ToString()
            };
        }

        public MedicalRecordDTO
            GetByEncounterId(
                int encounterId)
        {
            string query = @"
SELECT *
FROM MedicalRecords
WHERE EncounterID = @EncounterID";

            SqlParameter[] parameters =
            {
                new("@EncounterID",
                    encounterId)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            if (dt.Rows.Count == 0)
                return null;

            return MapRowToDTO(
                dt.Rows[0]);
        }
    }
}