using System;

namespace DTO
{
    public class Payment_RecepDTO
    {
        public int PaymentID { get; set; }

        public int EncounterID { get; set; }

        public int PatientID { get; set; }

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
