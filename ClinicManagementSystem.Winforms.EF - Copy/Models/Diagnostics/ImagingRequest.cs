using System;

namespace Models
{
    public class ImagingRequest
    {
        public int ImagingRequestID { get; set; }
        public Guid ImagingRequestUUID { get; set; }
        public int? EncounterID { get; set; }
        public int? DoctorID { get; set; }
        public int? ImagingServiceID { get; set; }
        public string BodyPart { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
