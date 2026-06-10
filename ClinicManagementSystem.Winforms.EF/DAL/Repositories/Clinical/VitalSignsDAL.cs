using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class VitalSignsDAL
    {
        public async Task<bool> InsertVitalSigns(VitalSignsDTO vital)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = new VitalSign
            {
                EncounterID = vital.EncounterID,
                Temperature = vital.Temperature,
                BloodPressure = vital.BloodPressure,
                HeartRate = vital.HeartRate,
                SPO2 = vital.SPO2,
                Weight = vital.Weight,
                Notes = vital.Notes
            };
            context.VitalSigns.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int?> GetLatestEncounterIdByPatient(int patientId)
        {
            using var context = DbContextProvider.CreateContext();
            var encounter = await context.Encounters
                .Where(e => e.PatientID == patientId)
                .OrderByDescending(e => e.CreatedAt)
                .ThenByDescending(e => e.EncounterID)
                .FirstOrDefaultAsync();

            return encounter?.EncounterID;
        }
    }
}