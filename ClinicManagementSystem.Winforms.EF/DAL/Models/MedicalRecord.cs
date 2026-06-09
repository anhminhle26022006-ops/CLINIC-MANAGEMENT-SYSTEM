using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int? EncounterId { get; set; }

    public string ChiefComplaint { get; set; }

    public string Symptoms { get; set; }

    public string Diagnosis { get; set; }

    public string Icdcode { get; set; }

    public string Conclusion { get; set; }

    public string Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid RecordUuid { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual ICollection<MedicalRecordFile> MedicalRecordFiles { get; set; } = new List<MedicalRecordFile>();
}
