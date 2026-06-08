using System;

namespace DTO
{
    public class EmployeeShiftDTO
    {
        public int EmployeeShiftID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string RoleName { get; set; }
        public int ShiftID { get; set; }
        public string ShiftName { get; set; }
        public DateTime WorkDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? RoomID { get; set; }
        public string RoomCode { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
    }
}
