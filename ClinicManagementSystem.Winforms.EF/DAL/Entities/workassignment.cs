namespace DAL.Entities
{
    public class WorkAssignment
    {
        public int AssignmentID { get; set; }
        public int EmployeeID { get; set; }
        public int? RoleID { get; set; }
        public int? DepartmentID { get; set; }
        public int? RoomID { get; set; }
        public int? EncounterID { get; set; }
        public DateTime WorkDate { get; set; }
        public int? ShiftID { get; set; }
        public string AssignmentType { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public Employee Employee { get; set; }
        public Encounter Encounter { get; set; }
    }
}