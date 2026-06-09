using System.Linq;
using DAL.Models;
using DTO;

namespace DAL
{
    public class VitalSignsDAL
    {
        public bool InsertVitalSigns(VitalSignsDTO vital)
        {
            using var db = new CMSDbContext();

            db.VitalSigns.Add(new VitalSign
            {
                EncounterId = vital.EncounterID,

                Temperature = (decimal)vital.Temperature,

                BloodPressure = vital.BloodPressure,

                HeartRate = vital.HeartRate,

                Spo2 = vital.SPO2,

                Weight = (decimal)vital.Weight,

                Notes = vital.Notes
            });

            return db.SaveChanges() > 0;
        }

        public int? GetLatestEncounterIdByPatient(int patientId)
        {
            using var db = new CMSDbContext();

            return db.Encounters
                .Where(e => e.PatientId == patientId)
                .OrderByDescending(e => e.CreatedAt)
                .ThenByDescending(e => e.EncounterId)
                .Select(e => (int?)e.EncounterId)
                .FirstOrDefault();
        }
    }
}