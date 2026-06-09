using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class DoctorDashboardDTO
    {
        public int TodayAppointments { get; set; }  // thêm dòng này
        public int WaitingPatients { get; set; }
        public int PendingLabs { get; set; }
        public int CompletedToday { get; set; }
        public int InProgress { get; set; }
        public ShiftInfoDTO TodayShift { get; set; }
    }
}
