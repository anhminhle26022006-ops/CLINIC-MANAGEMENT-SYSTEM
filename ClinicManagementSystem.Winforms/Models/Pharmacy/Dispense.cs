using System;

namespace Models
{
    public class Dispense
    {
        public int DispenseID { get; set; }
        public Guid DispenseUUID { get; set; }
        public int? PrescriptionID { get; set; }
        public int? PharmacistID { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
