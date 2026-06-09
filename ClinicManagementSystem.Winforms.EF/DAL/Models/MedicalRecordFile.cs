using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MedicalRecordFile
{
    public int FileId { get; set; }

    public int RecordId { get; set; }

    public string FileType { get; set; }

    public string FileUrl { get; set; }

    public DateTime? UploadedAt { get; set; }

    public virtual MedicalRecord Record { get; set; }
}
