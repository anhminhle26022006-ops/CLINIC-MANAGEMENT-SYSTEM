using System;

namespace DTO
{
    public class ShiftDTO
    {
        public int ShiftID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftName { get; set; }
        public string Status { get; set; }
    }
}
