using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; }

    public decimal? Price { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department Department { get; set; }

    public virtual ICollection<EncounterService> EncounterServices { get; set; } = new List<EncounterService>();

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
