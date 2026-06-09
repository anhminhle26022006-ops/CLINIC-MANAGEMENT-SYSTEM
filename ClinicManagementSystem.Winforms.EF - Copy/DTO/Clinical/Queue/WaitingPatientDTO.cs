using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WaitingPatientDTO
    {
        public int QueueNumber { get; set; }

        public string PatientName { get; set; }

        public string PatientCode { get; set; }

        public DateTime AppointmentTime { get; set; }

        public List<WaitingPatientDTO>
    WaitingPatients
        {
            get;
            set;
        }
    = new();
    }
}
