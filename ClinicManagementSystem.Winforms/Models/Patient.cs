using System;

namespace Models
{
    public class Patient
    {
        public Guid PatientId { get; set; }

        public string PatientCode { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string CitizenId { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string InsuranceNumber { get; set; }

        public string BloodType { get; set; }

        public string Allergy { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public string EmergencyContactRelation { get; set; }

        public DateTime CreatedAt { get; set; }

        public int GetAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > DateTime.Today.AddYears(-age))
                age--;

            return age;
        }
    }
}