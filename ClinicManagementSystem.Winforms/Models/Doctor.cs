using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Doctor : Employee
    {
        public string DepartmentId { get; set; }

        public DateTime HireDate { get; set; }

        public int YearsOfExperience { get; set; }

        public bool IsWorking { get; set; }
    }
}
