using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ImagingRequest
{
    public int ImagingRequestId { get; set; }

    public int? EncounterId { get; set; }

    public int? DoctorId { get; set; }

    public int? ImagingServiceId { get; set; }

    public string BodyPart { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Priority { get; set; }

    public string Status { get; set; }

    public Guid ImagingRequestUuid { get; set; }

    public virtual Employee Doctor { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual ICollection<ImagingResult> ImagingResults { get; set; } = new List<ImagingResult>();

    public virtual ImagingService ImagingService { get; set; }
}
