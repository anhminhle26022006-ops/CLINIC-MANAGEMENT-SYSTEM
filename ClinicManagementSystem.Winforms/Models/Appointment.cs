using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        public Guid AppointmentId { get; set; }

        public Guid PatientId { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid DoctorId { get; set; }

        public Guid? RoomId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string Reason { get; set; }

        public AppointmentStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public enum AppointmentStatus
    {
        Pending = 1,
        Confirmed = 2,
        Completed = 3,
        Cancelled = 4
    }
}
