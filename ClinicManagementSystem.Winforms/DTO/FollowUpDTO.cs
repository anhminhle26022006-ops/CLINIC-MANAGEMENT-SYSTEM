using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FollowUpDTO
    {
        public int FollowUpID { get; set; }

        public int EncounterID { get; set; }

        public DateTime FollowUpDate { get; set; }

        public string Status { get; set; }
    }
}
