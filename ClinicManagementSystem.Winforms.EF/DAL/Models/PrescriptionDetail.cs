using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PrescriptionDetail
{
    public int DetailId { get; set; }

    public int? PrescriptionId { get; set; }

    public int? MedicineId { get; set; }

    public int? Quantity { get; set; }

    public string Dosage { get; set; }

    public string Frequency { get; set; }

    public string Instruction { get; set; }

    public virtual Medicine Medicine { get; set; }

    public virtual Prescription Prescription { get; set; }
}
