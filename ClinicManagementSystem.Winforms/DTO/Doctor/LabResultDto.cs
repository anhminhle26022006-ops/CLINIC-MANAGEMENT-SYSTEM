using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class LabResultDto
    {
        public string TestType { get; set; }
        public string Status { get; set; }
        public DateTime CompletedAt { get; set; }

        public string WBC { get; set; }
        public string RBC { get; set; }
        public string HGB { get; set; }
    }
}
