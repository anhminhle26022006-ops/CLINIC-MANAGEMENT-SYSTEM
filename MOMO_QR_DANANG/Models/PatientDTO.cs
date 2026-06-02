using System;

namespace MOMO_QR_DANANG.Models
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

        public int Age
        {
            get
            {
                return DateTime.Now.Year - BirthDate.Year;
            }
        }
    }
}

