using DAL.DataContext;
using DTO;
using DTO.Clinical.erm;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class MedicalRecordDAL
    {
        public async Task<MedicalRecordDTO> GetByEncounterId(int encounterId)
        {
            using var context = DbContextProvider.CreateContext();

            var record = await context.MedicalRecords
                .FirstOrDefaultAsync(m => m.EncounterID == encounterId);

            if (record == null) return null;

            return new MedicalRecordDTO
            {
                RecordID = record.RecordID,
                EncounterID = record.EncounterID,
                Diagnosis = record.Diagnosis,
                Conclusion = record.Conclusion,
                Notes = record.Notes
            };
        }

        public async Task<List<MedicalRecordDto>> GetAllErmRecords()
        {
            using var context = DbContextProvider.CreateContext();

            return await context.MedicalRecords
                .OrderByDescending(mr => mr.CreatedAt)
                .ThenByDescending(mr => mr.RecordID)
                .Select(mr => new MedicalRecordDto
                {
                    RecordID = mr.RecordID,
                    RecordUUID = mr.RecordUUID,
                    PatientUUID = mr.Encounter.Patient.PatientUUID,
                    Code = "MR-" + mr.RecordID.ToString("D5"),
                    Date = mr.CreatedAt,
                    Patient = mr.Encounter.Patient.FullName ?? "",
                    Diagnosis = mr.Diagnosis ?? "",
                    Doctor = mr.Encounter.Doctor.FullName ?? "",
                    Status = mr.Encounter.Status ?? ""
                })
                .ToListAsync();
        }
    }
}