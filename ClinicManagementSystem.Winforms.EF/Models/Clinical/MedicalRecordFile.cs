using System;

namespace Models
{
    public class MedicalRecordFile
    {
        public int FileID { get; set; }
        public int RecordID { get; set; }
        public string FileType { get; set; }
        public string FileURL { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
