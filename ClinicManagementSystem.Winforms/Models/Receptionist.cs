using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Receptionist : Employee
    {
        public string ReceptionistId { get; set; }

        public string DepartmentId { get; set; }

        public DateTime HireDate { get; set; }

        public bool IsWorking { get; set; }
    }
}
