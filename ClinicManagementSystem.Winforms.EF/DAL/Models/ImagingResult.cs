using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ImagingResult
{
    public int ImagingResultId { get; set; }

    public int? ImagingRequestId { get; set; }

    public string ResultText { get; set; }

    public string ImageUrl { get; set; }

    public string Pdfurl { get; set; }

    public string TechnicianNote { get; set; }

    public DateTime? CompletedAt { get; set; }

    public virtual ICollection<ImagingFile> ImagingFiles { get; set; } = new List<ImagingFile>();

    public virtual ImagingRequest ImagingRequest { get; set; }
}
