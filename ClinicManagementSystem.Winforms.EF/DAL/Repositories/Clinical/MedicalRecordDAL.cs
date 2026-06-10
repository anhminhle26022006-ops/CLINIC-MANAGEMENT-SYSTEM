using System.Data;
using DAL.DataContext;
using DAL.Models;
using DTO;
using DTO.Clinical.erm;

namespace DAL.Repositories.Clinical
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

        public List<MedicalRecordDto> GetAllErmRecords()
        {
            string query = @"
SELECT
    mr.RecordID,
    mr.RecordUUID,
    p.PatientUUID,
    mr.CreatedAt,
    ISNULL(p.FullName, '') AS PatientName,
    ISNULL(mr.Diagnosis, '') AS Diagnosis,
    ISNULL(e.FullName, '') AS DoctorName,
    ISNULL(en.Status, '') AS Status
FROM MedicalRecords mr
LEFT JOIN Encounters en ON mr.EncounterID = en.EncounterID
LEFT JOIN Patients p ON en.PatientID = p.PatientID
LEFT JOIN Employees e ON en.DoctorID = e.EmployeeID
ORDER BY mr.CreatedAt DESC, mr.RecordID DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            List<MedicalRecordDto> list = new();

            foreach (DataRow row in dt.Rows)
            {
                int recordId = Convert.ToInt32(row["RecordID"]);
                list.Add(new MedicalRecordDto
                {
                    RecordID = recordId,
                    RecordUUID = row["RecordUUID"] != DBNull.Value ? Guid.Parse(row["RecordUUID"].ToString()) : Guid.Empty,
                    PatientUUID = row["PatientUUID"] != DBNull.Value ? Guid.Parse(row["PatientUUID"].ToString()) : Guid.Empty,
                    Code = "MR-" + recordId.ToString("D5"),
                    Date = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.MinValue,
                    Patient = row["PatientName"].ToString(),
                    Diagnosis = row["Diagnosis"].ToString(),
                    Doctor = row["DoctorName"].ToString(),
                    Status = row["Status"].ToString()
                });
            }

            return list;
        }
    }
}