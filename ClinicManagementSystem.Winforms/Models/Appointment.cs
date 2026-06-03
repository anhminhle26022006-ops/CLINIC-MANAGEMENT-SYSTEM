using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        // Bệnh nhân
        public int PatientId { get; set; }

        // Khoa khám
        public int DepartmentId { get; set; }

        // Bác sĩ
        public int DoctorId { get; set; }

        // Ngày khám
        public DateTime AppointmentDate { get; set; }

        // Giờ khám
        public TimeSpan AppointmentTime { get; set; }

        // Lý do khám
        public string Reason { get; set; }

        // Trạng thái
        public AppointmentStatus Status { get; set; }

        // Ngày tạo lịch
        public DateTime CreatedAt { get; set; }
    }

    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }
}
