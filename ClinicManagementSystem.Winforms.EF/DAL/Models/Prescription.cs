using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? EncounterId { get; set; }

    public int? DoctorId { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid PrescriptionUuid { get; set; }

    public virtual ICollection<Dispense> Dispenses { get; set; } = new List<Dispense>();

    public virtual Employee Doctor { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();
}
