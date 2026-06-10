namespace DAL.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public Guid PaymentUUID { get; set; }
        public int EncounterID { get; set; }
        public int PatientID { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public Encounter Encounter { get; set; }
    }
}