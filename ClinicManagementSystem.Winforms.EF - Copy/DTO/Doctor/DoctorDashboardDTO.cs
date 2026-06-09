namespace DTO.Doctor
{
    public class DoctorDashboardDTO
    {
        public int TodayAppointments { get; set; }
        public int WaitingCount { get; set; }
        public int ExaminingCount { get; set; }
        public int CompletedCount { get; set; }
        public int PendingLabRequests { get; set; }
        public int PendingImagingRequests { get; set; }
        public int PendingPrescriptions { get; set; }
        public int OpenAssignments { get; set; }
    }
}
