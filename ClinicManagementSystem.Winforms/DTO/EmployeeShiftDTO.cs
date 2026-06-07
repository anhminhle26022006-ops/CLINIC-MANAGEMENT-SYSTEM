using System;

namespace DTO
{
    public class EmployeeShiftDTO
    {
        public int ShiftID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime ShiftDate { get; set; }

        public string ShiftName { get; set; }

        public string Status { get; set; }

        public string Room { get; set; }

        public string Department { get; set; }

        public string TechnicianName { get; set; }
    }
}