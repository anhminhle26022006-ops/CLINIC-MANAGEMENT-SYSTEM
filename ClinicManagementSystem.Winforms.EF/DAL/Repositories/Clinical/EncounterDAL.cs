using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EncounterDAL
    {
        public EncounterDTO GetById(int encounterId)
        {
            using (var context = new ClinicDbContext())
            {
                var enc = context.Encounters.AsNoTracking().FirstOrDefault(e => e.EncounterID == encounterId);
                if (enc == null) return null;
                return new EncounterDTO
                {
                    EncounterID = enc.EncounterID,
                    AppointmentID = enc.AppointmentID ?? 0,
                    PatientID = enc.PatientID ?? 0,
                    DoctorID = enc.DoctorID ?? 0,
                    StartTime = enc.StartTime,
                    EndTime = enc.EndTime,
                    Status = enc.Status
                };
            }
        }
    }
}
