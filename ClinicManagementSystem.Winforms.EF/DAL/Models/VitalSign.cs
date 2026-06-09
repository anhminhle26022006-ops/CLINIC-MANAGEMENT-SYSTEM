using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class VitalSign
{
    public int VitalId { get; set; }

    public int? EncounterId { get; set; }

    public decimal? Temperature { get; set; }

    public string BloodPressure { get; set; }

    public int? HeartRate { get; set; }

    public int? Spo2 { get; set; }

    public decimal? Weight { get; set; }

    public string Notes { get; set; }

    public decimal? Height { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Encounter Encounter { get; set; }
}
