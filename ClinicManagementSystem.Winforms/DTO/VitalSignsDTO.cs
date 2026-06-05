using System;

namespace DTO
{
    public class VitalSignsDTO
    {
        public Guid VitalSignID { get; set; }

        public Guid AppointmentID { get; set; }

        public double Temperature { get; set; }

        public string BloodPressure { get; set; }

        public int HeartRate { get; set; }

        public int SPO2 { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public string Notes { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsArchived { get; set; }
    }
}