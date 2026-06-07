using System;

namespace DTO
{
    public class TechnicianShiftDTO
    {   
        public int ShiftID { get; set; }
        public int EmployeeShiftID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftName { get; set; } // Sáng, Chiều
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? RoomID { get; set; }
        public string Room { get; set; }
        public int? DepartmentID { get; set; }
        public string Department { get; set; }
        public string Status { get; set; } // Đã đăng ký, Chờ xác nhận
        public string EmployeeName { get; set; }
        public string RoleName { get; set; }
        public string TechnicianName { get; set; }
    }
}
