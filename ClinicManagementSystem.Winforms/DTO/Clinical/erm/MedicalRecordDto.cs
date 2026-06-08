namespace DTO.Clinical.erm
{
    public class MedicalRecordDto
    {
        public int RecordID { get; set; }
        public Guid RecordUUID { get; set; }

        public string Code { get; set; } // mapping từ RecordID hoặc custom format
        public DateTime Date { get; set; }

        public string Patient { get; set; }
        public string Diagnosis { get; set; }
        public string Doctor { get; set; }

        public string Status { get; set; } // mapping từ Encounters.Status
    }
}