using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class DoctorScheduleBUS
    {
        private readonly DoctorScheduleDAL dal = new();
        public int? GetRoomIdByDoctor(
    int doctorId)
        {
            return dal.GetRoomIdByDoctor(
                doctorId);
        }

        public DoctorScheduleDTO GetSchedule(
    int doctorId,
    DateTime workDate)
        {
            return dal.GetSchedule(
                doctorId,
                workDate);
        }
    }
}
