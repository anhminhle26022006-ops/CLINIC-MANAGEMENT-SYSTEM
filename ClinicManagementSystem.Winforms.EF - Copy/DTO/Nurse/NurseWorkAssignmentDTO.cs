using System;

namespace DTO
{
    public class NurseWorkAssignmentDTO
    {
        public int AssignmentID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string RoleName { get; set; }
        public DateTime WorkDate { get; set; }
        public int? ShiftID { get; set; }
        public string ShiftName { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? RoomID { get; set; }
        public string RoomCode { get; set; }
        public int? EncounterID { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string AssignmentType { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
