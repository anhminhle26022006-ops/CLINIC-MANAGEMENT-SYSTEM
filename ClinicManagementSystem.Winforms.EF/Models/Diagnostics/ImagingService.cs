namespace Models
{
    public class ImagingService
    {
        public int ImagingServiceID { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string Modality { get; set; }
        public decimal? Price { get; set; }
        public bool IsActive { get; set; }
    }
}
