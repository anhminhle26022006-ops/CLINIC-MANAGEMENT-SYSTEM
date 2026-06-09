using System;

namespace Models
{
    public class EmployeeShift
    {
        public int ID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ShiftID { get; set; }
        public DateTime? WorkDate { get; set; }
    }
}
