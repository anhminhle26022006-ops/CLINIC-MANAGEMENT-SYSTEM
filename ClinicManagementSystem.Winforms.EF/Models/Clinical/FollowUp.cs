using System;

namespace Models
{
    public class FollowUp
    {
        public int FollowUpID { get; set; }
        public Guid FollowUpUUID { get; set; }
        public int? EncounterID { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string Status { get; set; }
    }
}
