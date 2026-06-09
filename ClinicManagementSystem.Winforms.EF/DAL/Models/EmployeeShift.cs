using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EmployeeShift
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? ShiftId { get; set; }

    public DateOnly? WorkDate { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Shift Shift { get; set; }

    public virtual ICollection<ShiftChangeRequest> ShiftChangeRequests { get; set; } = new List<ShiftChangeRequest>();
}
