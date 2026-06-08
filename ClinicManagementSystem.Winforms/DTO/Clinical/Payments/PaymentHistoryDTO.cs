using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.Payments
{
    public class PaymentHistoryDTO
    {
        public int PaymentID { get; set; }

        public int EncounterID { get; set; }

        public string PatientName { get; set; }
            = string.Empty;

        public decimal Amount { get; set; }

        public string Method { get; set; }
            = string.Empty;

        public string Status { get; set; }
            = string.Empty;

        public DateTime PaidAt { get; set; }
    }
}
