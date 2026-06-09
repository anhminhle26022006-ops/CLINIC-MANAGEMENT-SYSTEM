using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class FollowUpBUS
    {
        private readonly FollowUpDAL dal =
            new();

        public List<FollowUpDTO>
            GetProcessingFollowUps()
        {
            return dal.GetByStatus(
                "Upcoming",
                "Overdue");
        }

        public List<FollowUpDTO>
            GetCompletedFollowUps()
        {
            return dal.GetByStatus(
                "Reminded",
                "Completed");
        }

        public List<FollowUpDTO>
            GetAll()
        {
            return dal.GetAll();
        }

        public bool UpdateStatus(
    int followUpId,
    string status)
        {
            return dal.UpdateStatus(
                followUpId,
                status);
        }
    }
}
