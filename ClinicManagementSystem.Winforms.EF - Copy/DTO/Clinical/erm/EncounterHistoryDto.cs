using DTO.Clinical.erm;

public class EncounterHistoryDto
{
    public Guid EncounterUUID { get; set; }
    public int EncounterId { get; set; }

    public DateTime VisitDate { get; set; }

    public string DoctorName { get; set; }
    public string DepartmentName { get; set; }

    public string Symptoms { get; set; }
    public string Diagnosis { get; set; }
    public string Conclusion { get; set; }

    public VitalSignDto VitalSigns { get; set; }

    // 🔥 ADD THESE
    public List<PrescriptionHistoryDto> Prescriptions { get; set; }
    public List<LabHistoryDto> LabResults { get; set; }
    public List<ImagingHistoryDto> ImagingResults { get; set; }
    public List<InvoiceHistoryDto> Invoices { get; set; }
    public List<FollowUpHistoryDto> FollowUps { get; set; }
}