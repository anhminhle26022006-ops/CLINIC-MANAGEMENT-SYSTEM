using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Doctor;
using DAL.Repositories.Doctor;

namespace BUS.Services.Doctor
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _dal;

        public AppointmentService(AppointmentRepository dal)
        {
            _dal = dal;
        }


            public List<AppointmentDto> GetToday()
            {
                return _dal.GetTodayAppointments();
            }

            public int CountWaiting()
            {
                return _dal.GetTodayAppointments()
                    .Count(x => x.Status == "Chờ tiếp nhận");
            }

            public int CountExamining()
            {
                return _dal.GetTodayAppointments()
                    .Count(x => x.Status == "Đang khám");
            }

            public int CountCompleted()
            {
                return _dal.GetTodayAppointments()
                    .Count(x => x.Status == "Hoàn thành");
            }

            public int GetCountWaiting()
        {
            return _dal.CountByStatus("Waiting");
        }

        public int GetCountExamining()
        {
            return _dal.CountByStatus("Examining");
        }

        public int GetCountCompleted()
        {
            return _dal.CountByStatus("Completed");
        }
    }
}
