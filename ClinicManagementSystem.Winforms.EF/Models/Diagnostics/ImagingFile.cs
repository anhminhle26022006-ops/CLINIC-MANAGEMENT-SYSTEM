namespace Models
{
    public class ImagingFile
    {
        public int FileID { get; set; }
        public int? ImagingResultID { get; set; }
        public string FileType { get; set; }
        public string FileURL { get; set; }
    }
}
