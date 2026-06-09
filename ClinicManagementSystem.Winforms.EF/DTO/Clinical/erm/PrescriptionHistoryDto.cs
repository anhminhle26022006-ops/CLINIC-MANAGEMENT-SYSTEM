using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class PrescriptionHistoryDto
    {
        public Guid PrescriptionUUID { get; set; }
        public string PrescriptionCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public string DoctorName { get; set; }

        public List<PrescriptionItemDto> Medicines { get; set; }
    }
}
