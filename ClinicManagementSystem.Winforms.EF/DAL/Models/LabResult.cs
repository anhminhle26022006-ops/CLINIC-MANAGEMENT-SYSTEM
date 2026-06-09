using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class LabResult
{
    public int ResultId { get; set; }

    public int? LabId { get; set; }

    public string ResultText { get; set; }

    public string FileUrl { get; set; }

    public DateTime? CompletedAt { get; set; }

    public virtual LabRequest Lab { get; set; }
}
