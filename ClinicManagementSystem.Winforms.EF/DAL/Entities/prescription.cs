namespace DAL.Entities
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public Guid PrescriptionUUID { get; set; }
        public int EncounterID { get; set; }
        public int DoctorID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Encounter Encounter { get; set; }
        public ICollection<PrescriptionDetail> Details { get; set; }
    }
}