using System;

namespace DTO
{
    public class PatientDTO
    {
        public int PatientID { get; set; }
        public string PatientCode { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Allergy { get; set; }

        public int Age
        {
            get
            {
                return BirthDate.HasValue ? DateTime.Now.Year - BirthDate.Value.Year : 0;
            }
        }
    }
}
