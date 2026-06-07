using System;

namespace DTO
{
    public class PaymentDTO
    {
        public Guid PaymentID { get; set; }

        public Guid InvoiceID { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; }

        public string Status { get; set; }

        public DateTime PaidAt { get; set; }
    }
}