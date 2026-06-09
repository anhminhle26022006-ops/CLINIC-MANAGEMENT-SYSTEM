using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Doctor
{
    public class ImagingResultDto
    {
        public string ServiceName { get; set; }
        public string ResultText { get; set; }
        public DateTime CompletedAt { get; set; }
        public string ImageURL { get; set; }
    }
}
