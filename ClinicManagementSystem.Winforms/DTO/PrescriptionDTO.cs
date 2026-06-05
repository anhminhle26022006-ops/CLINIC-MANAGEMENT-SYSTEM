using System;

namespace DTO
{
    public class PrescriptionDTO
    {
        public Guid PrescriptionID { get; set; }

        public Guid EncounterID { get; set; }

        public Guid DoctorID { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
