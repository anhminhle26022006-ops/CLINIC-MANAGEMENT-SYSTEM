using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EncounterDTO
    {
        public int EncounterID { get; set; }

        public int AppointmentID { get; set; }

        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Status { get; set; }
    }
}
