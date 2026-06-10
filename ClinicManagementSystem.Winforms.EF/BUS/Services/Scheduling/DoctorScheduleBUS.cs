using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class DoctorScheduleBUS
    {
        private readonly DoctorScheduleDAL dal;

        public DoctorScheduleBUS(CMSDbContext context)
        {
            dal = new DoctorScheduleDAL(context);
        }

        public int? GetRoomIdByDoctor(int doctorId)
        {
            return dal.GetRoomIdByDoctor(doctorId);
        }

        public DoctorScheduleDTO GetSchedule(
            int doctorId,
            DateTime workDate)
        {
            return dal.GetSchedule(
                doctorId,
                workDate);
        }

        public int CountActiveRoomsToday()
        {
            return dal.CountActiveRoomsToday();
        }

        public List<DoctorQueueDTO> GetDoctorQueues()
        {
            return dal.GetDoctorQueues();
        }
    }
}