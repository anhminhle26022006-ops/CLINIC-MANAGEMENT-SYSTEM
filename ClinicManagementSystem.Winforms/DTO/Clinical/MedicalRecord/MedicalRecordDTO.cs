using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MedicalRecordDTO
    {
        public int RecordID { get; set; }

        public int EncounterID { get; set; }

        public string Diagnosis { get; set; }

        public string Conclusion { get; set; }

        public string Notes { get; set; }
    }
}
