using System;

namespace Models
{
    public class DoctorSchedule
    {
        public int ScheduleID { get; set; }
        public int? DoctorID { get; set; }
        public DateTime? WorkDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? RoomID { get; set; }
    }
}
