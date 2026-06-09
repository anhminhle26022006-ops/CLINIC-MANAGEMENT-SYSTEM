using BUS.Services;
using BUS.Services.Doctor;
using DAL.Repositories.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class DoctorAppointmentController
    {
        private readonly AppointmentService _service;

        public DoctorAppointmentController(AppointmentService service)
        {
            _service = service;
        }

        public List<AppointmentDto> LoadToday()
        {
            return _service.GetToday();
        }

        public int Waiting() => _service.CountWaiting();
        public int Examining() => _service.CountExamining();
        public int Completed() => _service.CountCompleted();
    }
}
