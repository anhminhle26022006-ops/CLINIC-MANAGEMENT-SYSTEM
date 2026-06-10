using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class FollowUpDAL
    {
        public async Task<List<FollowUpDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.FollowUps
                .Select(f => new FollowUpDTO
                {
                    FollowUpID = f.FollowUpID,
                    EncounterID = f.EncounterID,
                    FollowUpDate = f.FollowUpDate ?? DateTime.MinValue,
                    Status = f.Status
                })
                .ToListAsync();
        }

        public async Task<List<FollowUpDTO>> GetByStatus(params string[] statuses)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.FollowUps
                .Where(f => statuses.Contains(f.Status))
                .Select(f => new FollowUpDTO
                {
                    FollowUpID = f.FollowUpID,
                    EncounterID = f.EncounterID,
                    FollowUpDate = f.FollowUpDate ?? DateTime.MinValue,
                    Status = f.Status
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateStatus(int followUpId, string status)
        {
            using var context = DbContextProvider.CreateContext();
            var followUp = await context.FollowUps
                .FirstOrDefaultAsync(f => f.FollowUpID == followUpId);

            if (followUp == null) return false;

            followUp.Status = status;
            return await context.SaveChangesAsync() > 0;
        }
    }
}