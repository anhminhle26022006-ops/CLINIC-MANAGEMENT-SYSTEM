namespace DAL.Entities
{
    public class PatientInsurance
    {
        public int InsuranceID { get; set; }
        public int PatientID { get; set; }
        public string InsuranceNumber { get; set; }
        public string Provider { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Patient Patient { get; set; }
    }
}