using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ShiftChangeRequest
{
    public int RequestId { get; set; }

    public int EmployeeShiftId { get; set; }

    public int RequestedBy { get; set; }

    public int TargetEmployeeId { get; set; }

    public string Reason { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? ApprovedByUserId { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public virtual User ApprovedByUser { get; set; }

    public virtual EmployeeShift EmployeeShift { get; set; }

    public virtual Employee RequestedByNavigation { get; set; }

    public virtual Employee TargetEmployee { get; set; }
}
