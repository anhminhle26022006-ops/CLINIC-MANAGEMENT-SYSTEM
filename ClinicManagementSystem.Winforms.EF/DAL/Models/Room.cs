using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomCode { get; set; }

    public int? DepartmentId { get; set; }

    public string Status { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; }

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();
}
