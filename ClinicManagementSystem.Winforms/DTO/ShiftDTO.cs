using System;

namespace DTO
{
    public class ShiftDTO
    {
        public Guid ShiftID { get; set; }

        public Guid EmployeeID { get; set; }

        public DateTime ShiftDate { get; set; }

        public string ShiftType { get; set; }

        public string Status { get; set; }
    }
}