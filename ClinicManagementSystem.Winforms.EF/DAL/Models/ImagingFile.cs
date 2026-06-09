using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ImagingFile
{
    public int FileId { get; set; }

    public int? ImagingResultId { get; set; }

    public string FileType { get; set; }

    public string FileUrl { get; set; }

    public virtual ImagingResult ImagingResult { get; set; }
}
