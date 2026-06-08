using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoctorQueueDTO
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public string DepartmentName { get; set; }

        public string RoomCode { get; set; }

        public string Shift { get; set; }

        public int CurrentQueueNumber { get; set; }

        public int ExaminingCount { get; set; }

        public int TotalAppointments { get; set; }

        public int WaitingCount { get; set; }

        public int CompletedCount { get; set; }

        public string CurrentPatientCode { get; set; }

        public string CurrentPatient { get; set; }

        public List<WaitingPatientDTO>
            WaitingPatients
        { get; set; }
            = new();
    }
}
