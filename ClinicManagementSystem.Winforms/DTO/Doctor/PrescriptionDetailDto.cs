using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class PrescriptionDetailDto
    {
        public int PrescriptionId { get; set; }

        public string PatientName { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; }

        public List<MedicinePrescriptionDto> Medicines { get; set; }
            = new List<MedicinePrescriptionDto>();
    }
}
