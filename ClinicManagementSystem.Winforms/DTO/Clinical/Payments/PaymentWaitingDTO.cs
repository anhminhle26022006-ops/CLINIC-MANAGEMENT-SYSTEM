using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentWaitingDTO
    {
        public int EncounterID { get; set; }

        public int PatientID { get; set; }

        public string PatientName { get; set; }

        public string PatientCode { get; set; }

        public string DoctorName { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
    }
}
