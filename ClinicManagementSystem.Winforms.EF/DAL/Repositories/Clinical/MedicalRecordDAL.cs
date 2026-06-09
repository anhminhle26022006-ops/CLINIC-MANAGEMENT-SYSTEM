using System.Data;
using DAL.DataContext;
using DAL.Models;
using DTO;
using DTO.Clinical.erm;
using Microsoft.Data.SqlClient;

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

        public MedicalRecordDTO GetByEncounterId(int encounterId)
        {
            using var db = new CMSDbContext();

            var record = db.MedicalRecords
                .FirstOrDefault(x => x.EncounterId == encounterId);

            if (record == null)
                return null;

            return new MedicalRecordDTO
            {
                RecordID = record.RecordId,
                EncounterID = record.EncounterId ?? 0,
                Diagnosis = record.Diagnosis,
                Conclusion = record.Conclusion,
                Notes = record.Notes
            };
        }
    }
}
