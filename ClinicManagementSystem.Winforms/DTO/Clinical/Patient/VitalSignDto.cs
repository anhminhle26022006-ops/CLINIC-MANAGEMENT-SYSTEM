using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.Patient
{
    public class VitalSignsDto
    {
        public int EncounterID { get; set; }

        public decimal Temperature { get; set; }
        public string BloodPressure { get; set; }
        public int HeartRate { get; set; }
        public int SPO2 { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
    }
}
