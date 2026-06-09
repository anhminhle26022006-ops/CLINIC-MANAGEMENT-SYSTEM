using System;

namespace Models
{
    public class ImagingResult
    {
        public int ImagingResultID { get; set; }
        public int? ImagingRequestID { get; set; }
        public string ResultText { get; set; }
        public string ImageURL { get; set; }
        public string PDFURL { get; set; }
        public string TechnicianNote { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
