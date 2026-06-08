namespace Models
{
    public class InvoiceDetail
    {
        public int DetailID { get; set; }
        public int? InvoiceID { get; set; }
        public int? ServiceID { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
