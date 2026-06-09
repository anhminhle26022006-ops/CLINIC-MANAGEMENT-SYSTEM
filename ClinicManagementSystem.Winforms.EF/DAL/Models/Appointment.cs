using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? DepartmentId { get; set; }

    public int? RoomId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Status { get; set; }

    public Guid AppointmentUuid { get; set; }

    public virtual Department Department { get; set; }

    public virtual Employee Doctor { get; set; }

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual Patient Patient { get; set; }

    public virtual Room Room { get; set; }
}
