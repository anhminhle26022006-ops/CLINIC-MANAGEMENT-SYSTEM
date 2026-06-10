using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.Repositories.Clinical
{
    public class EncounterDAL
    {
        private readonly AppDbContext _context;

        public EncounterDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EncounterDTO> GetById(int encounterId)
        {
            var encounter = await _context.Encounters
                .FirstOrDefaultAsync(e => e.EncounterID == encounterId);

            if (encounter == null) return null;

            return new EncounterDTO
            {
                EncounterID = encounter.EncounterID,
     
                PatientID = encounter.PatientID,
                DoctorID = encounter.DoctorID,
                StartTime = encounter.StartTime,
                EndTime = encounter.EndTime,
                Status = encounter.Status
            };
        }
    }
}