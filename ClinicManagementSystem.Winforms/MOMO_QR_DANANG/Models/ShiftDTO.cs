using System;

namespace MOMO_QR_DANANG.Models
{
    public class ShiftDTO
    {
        public int ShiftID { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftName { get; set; } // Sáng, Chiều
        public string Room { get; set; }
        public string Department { get; set; }
        public string Status { get; set; } // Đã đăng ký, Chờ xác nhận
        public string TechnicianName { get; set; }
    }
}

