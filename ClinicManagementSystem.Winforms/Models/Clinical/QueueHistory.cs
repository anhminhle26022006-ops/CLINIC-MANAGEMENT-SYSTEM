using System;

namespace Models
{
    public class QueueHistory
    {
        public int HistoryID { get; set; }
        public int? QueueID { get; set; }
        public string StepName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? EmployeeID { get; set; }
    }
}
