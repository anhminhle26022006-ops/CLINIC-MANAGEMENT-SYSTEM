using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class DoctorSchedule
{
    public int ScheduleId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? WorkDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int? RoomId { get; set; }

    public virtual Employee Doctor { get; set; }

    public virtual Room Room { get; set; }
}
