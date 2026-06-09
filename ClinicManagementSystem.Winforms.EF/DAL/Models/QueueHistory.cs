using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class QueueHistory
{
    public int HistoryId { get; set; }

    public int? QueueId { get; set; }

    public string StepName { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual PatientQueue Queue { get; set; }
}
