using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class PrescriptionStatisticDto
    {
        public int Total { get; set; }

        public int Today { get; set; }

        public int ThisWeek { get; set; }

        public int Processing { get; set; }
    }
}
