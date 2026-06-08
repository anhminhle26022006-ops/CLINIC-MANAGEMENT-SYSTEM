namespace DTO
{
    public class PaymentDetailDTO
    {
        public string ItemType { get; set; }

        public string Description { get; set; }

        public string PatientName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }
    }
}
