using System;

namespace Models
{
    public class ClinicalFile
    {
        public int FileID { get; set; }
        public int? EncounterID { get; set; }
        public string FileType { get; set; }
        public string FileURL { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
