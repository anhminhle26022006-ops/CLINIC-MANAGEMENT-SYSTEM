namespace DAL.Entities
{
    public class PatientQueue
    {
        public int QueueID { get; set; }
        public Guid QueueUUID { get; set; }
        public int EncounterID { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string CurrentStep { get; set; }
        public Encounter Encounter { get; set; }
    }
}