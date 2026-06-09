using System;

namespace Models
{
    public class Encounter
    {
        public int EncounterID { get; set; }
        public Guid EncounterUUID { get; set; }
        public int? AppointmentID { get; set; }
        public int? PatientID { get; set; }
        public int? DoctorID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
