namespace Models
{
    public class ClinicalService
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal? Price { get; set; }
        public int? DepartmentID { get; set; }
    }
}
