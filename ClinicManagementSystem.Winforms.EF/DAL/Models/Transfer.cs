using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Transfer
{
    public int TransferId { get; set; }

    public int? EncounterId { get; set; }

    public string Reason { get; set; }

    public string Severity { get; set; }

    public string Status { get; set; }

    public Guid TransferUuid { get; set; }

    public virtual Encounter Encounter { get; set; }
}
