using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Shift
{
    public int ShiftId { get; set; }

    public string Name { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; } = new List<EmployeeShift>();
}
