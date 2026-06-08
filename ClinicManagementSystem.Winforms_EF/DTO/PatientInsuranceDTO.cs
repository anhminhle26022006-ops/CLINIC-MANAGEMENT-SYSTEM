using System;

namespace DTO
{
    public class PatientInsuranceDTO
    {
        public int InsuranceID { get; set; }
        public int PatientID { get; set; }
        public string InsuranceCode { get; set; }
        public string InsuranceNumber { get; set; }
        public string Provider { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}