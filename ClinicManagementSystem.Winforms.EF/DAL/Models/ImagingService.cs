using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ImagingService
{
    public int ImagingServiceId { get; set; }

    public string ServiceCode { get; set; }

    public string ServiceName { get; set; }

    public string Modality { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ImagingRequest> ImagingRequests { get; set; } = new List<ImagingRequest>();
}
