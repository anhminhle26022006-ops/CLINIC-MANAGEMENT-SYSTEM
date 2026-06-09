using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.DataContext;
using DTO;
using Models;

namespace DAL.Repositories
{
    public class MedicalRecordDAL
    {
        public MedicalRecordDTO GetByEncounterId(int encounterId)
        {
            using (var context = new ClinicDbContext())
            {
                var record = context.MedicalRecords
                    .AsNoTracking()
                    .FirstOrDefault(r => r.EncounterID == encounterId);
                
                if (record == null) return null;

                return new MedicalRecordDTO
                {
                    RecordID = record.RecordID,
                    EncounterID = record.EncounterID ?? 0,
                    Diagnosis = record.Diagnosis,
                    Conclusion = record.Conclusion,
                    Notes = record.Notes
                };
            }
        }
    }
}
