using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class AppointmentDto
    {
        public int EncounterID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }

        public string PatientName { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }

        public string VitalSummary { get; set; }
    }
}
