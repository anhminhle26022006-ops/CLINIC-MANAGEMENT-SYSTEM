using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class MedicinePrescriptionDto
    {
        public string MedicineName { get; set; }

        public int Quantity { get; set; }

        public string Dosage { get; set; }

        public string Frequency { get; set; }

        public string Instruction { get; set; }
    }
}
