using System;

namespace MOMO_QR_DANANG.Models
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public string RequestCode { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string ServiceType { get; set; }
        public string RequestNote { get; set; }
        public string Priority { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; } // Chờ xử lý, Đang xử lý, Hoàn thành
        public string ResultFile { get; set; }
        public string ResultPDF { get; set; }
        public string LabValues { get; set; } // JSON or text values

        // Join properties for easy UI rendering
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public string DoctorName { get; set; }
    }
}

