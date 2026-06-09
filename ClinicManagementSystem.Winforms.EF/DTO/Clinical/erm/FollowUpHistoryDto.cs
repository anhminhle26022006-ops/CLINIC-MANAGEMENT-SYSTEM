using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class FollowUpHistoryDto
    {
        public Guid FollowUpUUID { get; set; }

        public DateTime FollowUpDate { get; set; }

        public string DoctorName { get; set; }

        public string Status { get; set; }

        public string Content { get; set; }
    }
}
