using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class PatientQueueDto
    {
        public int QueueID { get; set; }
        public int EncounterID { get; set; }

        public string PatientName { get; set; }
        public string PatientCode { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string AgeGender { get; set; }

        public string Allergy { get; set; }

        public int QueueNumber { get; set; }

        public string Status { get; set; }
        public string CurrentStep { get; set; }
    }
}
