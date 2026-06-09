using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Medicine
{
    public int MedicineId { get; set; }

    public string Name { get; set; }

    public string Unit { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public string BatchNumber { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual ICollection<PrescriptionDetail> PrescriptionDetails { get; set; } = new List<PrescriptionDetail>();
}
