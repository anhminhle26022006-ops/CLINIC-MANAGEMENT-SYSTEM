using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Dispense
{
    public int DispenseId { get; set; }

    public int? PrescriptionId { get; set; }

    public int? PharmacistId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string Status { get; set; }

    public Guid DispenseUuid { get; set; }

    public virtual Employee Pharmacist { get; set; }

    public virtual Prescription Prescription { get; set; }
}
