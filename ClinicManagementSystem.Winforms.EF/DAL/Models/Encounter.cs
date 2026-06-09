using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Encounter
{
    public int EncounterId { get; set; }

    public int? AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string Status { get; set; }

    public Guid EncounterUuid { get; set; }

    public virtual Appointment Appointment { get; set; }

    public virtual Employee Doctor { get; set; }

    public virtual ICollection<EncounterService> EncounterServices { get; set; } = new List<EncounterService>();

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<FollowUp> FollowUps { get; set; } = new List<FollowUp>();

    public virtual ICollection<ImagingRequest> ImagingRequests { get; set; } = new List<ImagingRequest>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<LabRequest> LabRequests { get; set; } = new List<LabRequest>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual Patient Patient { get; set; }

    public virtual ICollection<PatientQueue> PatientQueues { get; set; } = new List<PatientQueue>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();

    public virtual ICollection<VitalSign> VitalSigns { get; set; } = new List<VitalSign>();
}
