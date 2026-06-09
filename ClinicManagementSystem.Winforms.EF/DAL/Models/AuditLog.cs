using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string Action { get; set; }

    public string TableName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AuditLogDetail> AuditLogDetails { get; set; } = new List<AuditLogDetail>();

    public virtual User User { get; set; }
}
