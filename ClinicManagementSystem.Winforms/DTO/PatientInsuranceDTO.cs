using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PatientInsuranceDTO
    {
        public int InsuranceID { get; set; }

        public int PatientID { get; set; }

        public string InsuranceNumber { get; set; }

        public string Provider { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
