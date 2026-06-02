namespace Models
{
    public class Patient : Person
    {
        public string PatientCode { get; set; }  

        public string InsuranceNumber { get; set; }

        public string BloodType { get; set; }       

        // Liên hệ khẩn cấp
        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public string EmergencyContactRelation { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
