using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class WorkAssignment
    {
        public int AssignmentId { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoleId { get; set; }
        public int? DepartmentId { get; set; }
        public int? RoomId { get; set; }
        public int? EncounterId { get; set; }
        public DateOnly? WorkDate { get; set; }
        public int? ShiftId { get; set; }
        public string AssignmentType { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime? CompletedAt { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
        public virtual Department Department { get; set; }
        public virtual Room Room { get; set; }
        public virtual Encounter Encounter { get; set; }
    }
}