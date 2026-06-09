using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class PrescriptionListDto
    {
        public int PrescriptionId { get; set; }

        public DateTime CreatedAt { get; set; }

        public string PatientName { get; set; }

        public int MedicineCount { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }
    }
}
