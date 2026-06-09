using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PatientIdentifier
{
    public int IdentifierId { get; set; }

    public int? PatientId { get; set; }

    public string SourceSystem { get; set; }

    public string IdentifierType { get; set; }

    public string IdentifierValue { get; set; }

    public virtual Patient Patient { get; set; }
}
