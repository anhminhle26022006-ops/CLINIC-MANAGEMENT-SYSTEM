namespace DAL.Entities
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public Guid InvoiceUUID { get; set; }
        public int EncounterID { get; set; }
        public int PatientID { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Encounter Encounter { get; set; }
        public ICollection<InvoiceDetail> Details { get; set; }
    }
}