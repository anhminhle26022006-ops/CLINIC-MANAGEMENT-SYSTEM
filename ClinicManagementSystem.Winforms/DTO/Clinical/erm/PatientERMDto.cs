namespace DTO.Clinical.erm
{
    public class PatientERMDto
    {
        public Guid PatientUUID { get; set; }

        public string PatientCode { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }

        public string BloodType { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }

        public string InsuranceNumber { get; set; }

        public string EmergencyContact { get; set; }

        public string Allergy { get; set; }

        public List<EncounterHistoryDto> Encounters { get; set; }

        public List<PrescriptionHistoryDto> Prescriptions { get; set; }

        public List<LabHistoryDto> LabResults { get; set; }

        public List<ImagingHistoryDto> ImagingResults { get; set; }

        public List<InvoiceHistoryDto> Invoices { get; set; }

        public List<FollowUpHistoryDto> FollowUps { get; set; }
    }
}