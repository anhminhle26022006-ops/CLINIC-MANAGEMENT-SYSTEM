using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class LabRequest
{
    public int LabId { get; set; }

    public int? EncounterId { get; set; }

    public int? DoctorId { get; set; }

    public string TestType { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid LabRequestUuid { get; set; }

    public virtual Employee Doctor { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual ICollection<LabResult> LabResults { get; set; } = new List<LabResult>();
}
