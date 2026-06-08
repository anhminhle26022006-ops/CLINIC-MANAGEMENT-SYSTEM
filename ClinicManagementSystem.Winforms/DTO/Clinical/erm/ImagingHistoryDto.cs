using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class ImagingHistoryDto
    {
        public Guid ImagingRequestUUID { get; set; }

        public string Modality { get; set; }

        public string BodyPart { get; set; }

        public string DoctorName { get; set; }
        public string PatientName { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Conclusion { get; set; }

        public string ImageUrl { get; set; }

        public string PdfUrl { get; set; }
    }
}
