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

        public List<MedicalRecordDto> GetAllErmRecords()
        {
            using var db = new CMSDbContext();

            return db.MedicalRecords
                .OrderByDescending(x => x.CreatedAt)
                .ThenByDescending(x => x.RecordId)
                .Select(x => new MedicalRecordDto
                {
                    RecordID = x.RecordId,

                    RecordUUID = x.RecordUuid,

                    PatientUUID =
                        x.Encounter.Patient.PatientUuid,

                    Code = "MR-" + x.RecordId.ToString("D5"),

                    Date =
                        x.CreatedAt ?? DateTime.MinValue,

                    Patient =
                        x.Encounter.Patient.FullName ?? "",

                    Diagnosis =
                        x.Diagnosis ?? "",

                    Doctor =
                        x.Encounter.Doctor.FullName ?? "",

                    Status =
                        x.Encounter.Status ?? ""
                })
                .ToList();
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
