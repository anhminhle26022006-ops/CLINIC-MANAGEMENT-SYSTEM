using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class FollowUp
{
    public int FollowUpId { get; set; }

    public int? EncounterId { get; set; }

    public DateTime? FollowUpDate { get; set; }

    public string Status { get; set; }

    public Guid FollowUpUuid { get; set; }

    public virtual Encounter Encounter { get; set; }
}
