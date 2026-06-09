using System;

namespace DTO
{
    public class VitalSignsDTO
    {
        public Guid VitalID { get; set; }

        public int EncounterID { get; set; }

        public double Temperature { get; set; }

        public string BloodPressure { get; set; }

        public int HeartRate { get; set; }

        public int SPO2 { get; set; }

        public double Weight { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
