using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PatientQueue
{
    public int QueueId { get; set; }

    public int? EncounterId { get; set; }

    public string Priority { get; set; }

    public string Status { get; set; }

    public string CurrentStep { get; set; }

    public int? QueueNumber { get; set; }

    public DateTime QueueTime { get; set; }

    public Guid QueueUuid { get; set; }

    public virtual Encounter Encounter { get; set; }

    public virtual ICollection<QueueHistory> QueueHistories { get; set; } = new List<QueueHistory>();
}
