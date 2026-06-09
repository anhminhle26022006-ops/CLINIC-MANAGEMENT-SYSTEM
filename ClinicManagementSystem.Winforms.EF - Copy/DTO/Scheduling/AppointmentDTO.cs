using System;

namespace DTO
{
    public class AppointmentDTO
    {
        public int AppointmentID { get; set; }

        public Guid AppointmentUUID { get; set; }

        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        public int DepartmentID { get; set; }

        public int RoomID { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}