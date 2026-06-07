using System;

namespace Models
{
    public class LabResult
    {
        public int ResultID { get; set; }
        public int? LabID { get; set; }
        public string ResultText { get; set; }
        public string FileURL { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
