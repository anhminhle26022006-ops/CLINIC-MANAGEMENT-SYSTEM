using System;

namespace DTO
{
    public class PatientDTO
    {
        public int PatientID { get; set; }

        public string PatientCode { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string BloodType { get; set; }

        public string Allergy { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;

                if (BirthDate.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}