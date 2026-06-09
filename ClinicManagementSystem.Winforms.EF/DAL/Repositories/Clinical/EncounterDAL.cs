using System.Linq;
using DAL.Models;
using DTO;

namespace DAL.Repositories
{
    public class EncounterDAL
    {
        private EncounterDTO MapToDTO(Encounter encounter)
        {
            return new EncounterDTO
            {
                EncounterID = encounter.EncounterId,
                AppointmentID = encounter.AppointmentId ?? 0,
                PatientID = encounter.PatientId ?? 0,
                DoctorID = encounter.DoctorId ?? 0,
                StartTime = encounter.StartTime,
                EndTime = encounter.EndTime,
                Status = encounter.Status
            };
        }

        public EncounterDTO GetById(int encounterId)
        {
            using var db = new CMSDbContext();

            var encounter = db.Encounters
                .FirstOrDefault(e => e.EncounterId == encounterId);

            if (encounter == null)
                return null;

            return MapToDTO(encounter);
        }
    }
}