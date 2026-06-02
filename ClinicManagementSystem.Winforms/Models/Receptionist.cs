using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Receptionist : Person
    {
        public string ReceptionistCode { get; set; }

        public string DepartmentId { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsWorking { get; set; }
    }
}
