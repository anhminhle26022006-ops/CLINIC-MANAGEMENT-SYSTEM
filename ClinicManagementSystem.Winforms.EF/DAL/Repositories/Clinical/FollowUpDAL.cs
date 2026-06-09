using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DTO;

namespace DAL.Repositories
{
    public class FollowUpDAL
    {
        private FollowUpDTO MapToDTO(FollowUp followUp)
        {
            return new FollowUpDTO
            {
                FollowUpID = followUp.FollowUpId,
                EncounterID = followUp.EncounterId ?? 0,
                FollowUpDate = followUp.FollowUpDate ?? DateTime.MinValue,
                Status = followUp.Status
            };
        }

        public List<FollowUpDTO> GetAll()
        {
            using var db = new CMSDbContext();

            return db.FollowUps
                .Select(f => new FollowUpDTO
                {
                    FollowUpID = f.FollowUpId,
                    EncounterID = f.EncounterId ?? 0,
                    FollowUpDate = f.FollowUpDate ?? DateTime.MinValue,
                    Status = f.Status
                })
                .ToList();
        }

        public List<FollowUpDTO> GetByStatus(params string[] statuses)
        {
            using var db = new CMSDbContext();

            return db.FollowUps
                .Where(f => statuses.Contains(f.Status))
                .Select(f => new FollowUpDTO
                {
                    FollowUpID = f.FollowUpId,
                    EncounterID = f.EncounterId ?? 0,
                    FollowUpDate = f.FollowUpDate ?? DateTime.MinValue,
                    Status = f.Status
                })
                .ToList();
        }

        public bool UpdateStatus(int followUpId, string status)
        {
            using var db = new CMSDbContext();

            var followUp = db.FollowUps
                .FirstOrDefault(f => f.FollowUpId == followUpId);

            if (followUp == null)
                return false;

            followUp.Status = status;

            return db.SaveChanges() > 0;
        }
    }
}