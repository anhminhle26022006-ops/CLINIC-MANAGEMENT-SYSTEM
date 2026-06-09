using System;

namespace DTO.Doctor
{
    public class DoctorLabResultDTO
    {
        public int LabID { get; set; }
        public string TestType { get; set; }
        public string Status { get; set; }
        public string ResultText { get; set; }
        public string FileURL { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public class DoctorImagingResultDTO
    {
        public int ImagingRequestID { get; set; }
        public string ServiceName { get; set; }
        public string BodyPart { get; set; }
        public string Status { get; set; }
        public string ResultText { get; set; }
        public string ImageURL { get; set; }
        public string PDFURL { get; set; }
        public string TechnicianNote { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
