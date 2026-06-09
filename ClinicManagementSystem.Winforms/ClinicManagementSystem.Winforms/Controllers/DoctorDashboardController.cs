using BUS.Services.Doctor;
using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class DoctorDashboardController
    {
        private readonly DoctorDashboardService _service;

        public DoctorDashboardController(
            DoctorDashboardService service)
        {
            _service = service;
        }

        public DoctorDashboardDTO Load(
            int doctorId)
        {
            return _service.GetDashboard(
                doctorId);
        }
        public void ChangeShift(int doctorId, int newShiftId)
        {
            _service.ChangeShift(doctorId, newShiftId);
        }
    }
}
