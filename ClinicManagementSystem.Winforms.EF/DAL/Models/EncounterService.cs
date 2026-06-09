using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class EncounterService
{
    public int EncounterServiceId { get; set; }

    public int EncounterId { get; set; }

    public int ServiceId { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? OrderedBy { get; set; }

    public DateTime? OrderedAt { get; set; }

    public string Status { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual Employee OrderedByNavigation { get; set; }

    public virtual Service Service { get; set; }
}
