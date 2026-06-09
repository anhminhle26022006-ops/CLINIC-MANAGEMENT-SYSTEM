using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientCode { get; set; }

    public string FullName { get; set; }

    public string Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string BloodType { get; set; }

    public string Allergy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public Guid PatientUuid { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<PatientIdentifier> PatientIdentifiers { get; set; } = new List<PatientIdentifier>();

    public virtual ICollection<PatientInsurance> PatientInsurances { get; set; } = new List<PatientInsurance>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
