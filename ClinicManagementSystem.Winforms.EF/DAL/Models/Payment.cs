using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? EncounterId { get; set; }

    public decimal? Amount { get; set; }

    public string Method { get; set; }

    public string Status { get; set; }

    public DateTime? PaidAt { get; set; }

    public int? PatientId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid PaymentUuid { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual Patient Patient { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
