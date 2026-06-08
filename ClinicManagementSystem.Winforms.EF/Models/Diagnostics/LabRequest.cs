using System;

namespace Models
{
    public class LabRequest
    {
        public int LabID { get; set; }
        public Guid LabRequestUUID { get; set; }
        public int? EncounterID { get; set; }
        public int? DoctorID { get; set; }
        public string TestType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
