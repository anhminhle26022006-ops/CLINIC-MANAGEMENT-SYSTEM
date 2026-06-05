using System;

namespace DTO
{
    public class PaymentDTO
    {
        public Guid PaymentID { get; set; }

        public Guid PrescriptionID { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime PaidAt { get; set; }
    }
}