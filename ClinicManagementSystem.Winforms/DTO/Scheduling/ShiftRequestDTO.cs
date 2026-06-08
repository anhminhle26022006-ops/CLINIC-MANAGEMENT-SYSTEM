using System;

namespace DTO
{
    public class ShiftRequestDTO
    {
        public int RequestID { get; set; }
        public string RequestCode { get; set; }
        public int RequesterID { get; set; }
        public string RequesterName { get; set; }
        public string RequesterRole { get; set; }
        public int? ReplacerID { get; set; }
        public string ReplacerName { get; set; }
        public string ReplacerRole { get; set; }
        public int FromShiftID { get; set; }
        public string FromShiftCode { get; set; }
        public DateTime FromShiftDate { get; set; }
        public TimeSpan FromShiftStart { get; set; }
        public TimeSpan FromShiftEnd { get; set; }
        public string FromDeptName { get; set; }
        public int? ToShiftID { get; set; }
        public string ToShiftCode { get; set; }
        public DateTime ToShiftDate { get; set; }
        public TimeSpan ToShiftStart { get; set; }
        public TimeSpan ToShiftEnd { get; set; }
        public string ToDeptName { get; set; }
        public string Reason { get; set; }
        public string AdminNote { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime CreatedAt { get; set; }
    }
}