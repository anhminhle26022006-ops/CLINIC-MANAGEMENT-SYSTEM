using System;

namespace Models
{
    public class MedicalRecord
    {
        public int RecordID { get; set; }
        public Guid RecordUUID { get; set; }
        public int? EncounterID { get; set; }
        public string ChiefComplaint { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string ICDCode { get; set; }
        public string Conclusion { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
