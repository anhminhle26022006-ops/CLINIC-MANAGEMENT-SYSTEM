using System;

namespace DTO
{
    public class ShiftDTO
    {
        public Guid ID { get; set; }

        public Guid EmployeeID { get; set; }

        public Guid ShiftID { get; set; }

        public DateTime WorkDate { get; set; }
    }
}