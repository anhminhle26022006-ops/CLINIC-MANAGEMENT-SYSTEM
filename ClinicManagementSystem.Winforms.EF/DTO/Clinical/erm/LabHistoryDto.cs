using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class LabHistoryDto
    {
        public Guid LabRequestUUID { get; set; }

        public string TestType { get; set; }

        public DateTime CreatedAt { get; set; }

        public string DoctorName { get; set; }

        public string Status { get; set; }

        public string FileUrl { get; set; }

        public List<LabResultItemDto> ResultItems { get; set; }
    }
}
