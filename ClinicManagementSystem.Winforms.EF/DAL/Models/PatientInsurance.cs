using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PatientInsurance
{
    public int InsuranceId { get; set; }

    public int? PatientId { get; set; }

    public string InsuranceNumber { get; set; }

    public string Provider { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public virtual Patient Patient { get; set; }
}
