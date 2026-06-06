namespace Models
{
    public class PaymentDetail
    {
        public int PaymentDetailID { get; set; }
        public int PaymentID { get; set; }
        public string ItemType { get; set; }
        public int? ItemID { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Amount { get; set; }
    }
}
