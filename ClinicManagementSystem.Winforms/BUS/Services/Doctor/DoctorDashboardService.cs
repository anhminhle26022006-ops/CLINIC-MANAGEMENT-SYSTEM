using DAL.Repositories.Doctor;
using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services.Doctor
{
    public class DoctorDashboardService
    {
        private readonly DoctorDashboardRepository _repo;

        public DoctorDashboardService(
            DoctorDashboardRepository repo)
        {
            _repo = repo;
        }

        public DoctorDashboardDTO GetDashboard(
            int doctorId)
        {
            return _repo.GetDashboard(doctorId);
        }
        public void ChangeShift(int doctorId, int newShiftId)
        {
            _repo.ChangeShiftToday(doctorId, newShiftId);
        }
    }
}
