using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? EncounterId { get; set; }

    public int? PatientId { get; set; }

    public decimal? Total { get; set; }

    public string Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid InvoiceUuid { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Patient Patient { get; set; }
}
