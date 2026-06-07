using System;

namespace Models
{
    public class Transfer
    {
        public int TransferID { get; set; }
        public Guid TransferUUID { get; set; }
        public int? EncounterID { get; set; }
        public string Reason { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
    }
}
