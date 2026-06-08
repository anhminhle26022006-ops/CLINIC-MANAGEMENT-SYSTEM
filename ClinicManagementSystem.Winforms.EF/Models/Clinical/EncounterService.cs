using System;

namespace Models
{
    public class EncounterService
    {
        public int EncounterServiceID { get; set; }
        public int EncounterID { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? OrderedBy { get; set; }
        public DateTime OrderedAt { get; set; }
        public string Status { get; set; }
    }
}
