using System;
using System.Linq;
using DTO;
using DAL.DataContext;
using Models;

namespace DAL
{
    public class VitalSignsDAL
    {
        public bool InsertVitalSigns(VitalSignsDTO vital)
        {
            using (var context = new ClinicDbContext())
            {
                var vs = new VitalSign
                {
                    EncounterID = BitConverter.ToInt32(vital.EncounterID.ToByteArray(), 0),
                    Temperature = (decimal?)vital.Temperature,
                    BloodPressure = vital.BloodPressure,
                    HeartRate = vital.HeartRate,
                    SPO2 = vital.SPO2,
                    Weight = (decimal?)vital.Weight,
                    Notes = vital.Notes,
                    CreatedAt = DateTime.Now
                };
                context.VitalSigns.Add(vs);
                return context.SaveChanges() > 0;
            }
        }
    }
}
