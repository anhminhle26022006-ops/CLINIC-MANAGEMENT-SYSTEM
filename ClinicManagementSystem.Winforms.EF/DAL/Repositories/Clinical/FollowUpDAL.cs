using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DTO;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class FollowUpDAL
    {
        public List<FollowUpDTO> GetAll()
        {
            using (var context = new ClinicDbContext())
            {
                return context.FollowUps
                    .AsNoTracking()
                    .Select(f => new FollowUpDTO
                    {
                        FollowUpID = f.FollowUpID,
                        EncounterID = f.EncounterID ?? 0,
                        FollowUpDate = f.FollowUpDate ?? DateTime.MinValue,
                        Status = f.Status
                    })
                    .ToList();
            }
        }

        public List<FollowUpDTO> GetByStatus(params string[] statuses)
        {
            return GetAll()
                .Where(x => statuses.Contains(x.Status))
                .ToList();
        }

        public bool UpdateStatus(int followUpId, string status)
        {
            using (var context = new ClinicDbContext())
            {
                var f = context.FollowUps.FirstOrDefault(x => x.FollowUpID == followUpId);
                if (f != null)
                {
                    f.Status = status;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }
    }
}
