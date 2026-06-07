using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class ServiceItemDto
    {
        public string ServiceName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
