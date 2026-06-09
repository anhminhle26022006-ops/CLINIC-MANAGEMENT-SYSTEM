using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.Patient
{
    public class MedicalHistoryDto
    {
        public string Date { get; set; }
        public string Diagnosis { get; set; }
        public string DoctorName { get; set; }
        public string PrescriptionSummary { get; set; }
    }
}
