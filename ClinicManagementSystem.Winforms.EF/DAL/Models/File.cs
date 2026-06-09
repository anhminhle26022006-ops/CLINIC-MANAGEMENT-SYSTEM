using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class File
{
    public int FileId { get; set; }

    public int? EncounterId { get; set; }

    public string FileType { get; set; }

    public string FileUrl { get; set; }

    public DateTime? UploadedAt { get; set; }

    public virtual Encounter Encounter { get; set; }
}
