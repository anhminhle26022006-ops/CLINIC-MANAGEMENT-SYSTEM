using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class InvoiceHistoryDto
    {
        public Guid InvoiceUUID { get; set; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public string PaymentMethod { get; set; }

        public List<ServiceItemDto> Services { get; set; }
    }
}
