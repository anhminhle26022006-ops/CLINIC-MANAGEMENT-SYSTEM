using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FollowUpCardDTO
    {
        public int FollowUpID { get; set; }

        public string PatientCode { get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public string Diagnosis { get; set; }

        public DateTime FollowUpDate { get; set; }

        public string Status { get; set; }
    }
}
