using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class VitalSignDto
    {
        public string BloodPressure { get; set; }

        public decimal Temperature { get; set; }

        public int HeartRate { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }
    }
}
