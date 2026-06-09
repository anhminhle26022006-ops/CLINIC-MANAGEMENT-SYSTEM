using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Clinical.erm
{
    public class LabResultItemDto
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Unit { get; set; }

        public string ReferenceRange { get; set; }
    }
}
