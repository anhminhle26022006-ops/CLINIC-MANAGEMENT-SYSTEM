using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AuditLogDetail
{
    public int DetailId { get; set; }

    public int? LogId { get; set; }

    public string OldValue { get; set; }

    public string NewValue { get; set; }

    public virtual AuditLog Log { get; set; }
}
