namespace DTO
{
    public class DoctorScheduleDTO
    {
        public int ScheduleID { get; set; }

        public int DoctorID { get; set; }

        public DateTime WorkDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int RoomID { get; set; }
    }
}
