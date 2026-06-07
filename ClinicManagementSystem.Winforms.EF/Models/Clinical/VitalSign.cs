using System;

namespace Models
{
    public class VitalSign
    {
        public int VitalID { get; set; }
        public int? EncounterID { get; set; }
        public decimal? Temperature { get; set; }
        public string BloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public int? SPO2 { get; set; }
        public decimal? Weight { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
