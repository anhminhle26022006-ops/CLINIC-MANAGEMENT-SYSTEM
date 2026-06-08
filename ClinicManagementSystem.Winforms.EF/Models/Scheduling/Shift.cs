using System;

namespace Models
{
    public class Shift
    {
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}
