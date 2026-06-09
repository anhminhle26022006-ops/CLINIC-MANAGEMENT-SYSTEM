namespace DTO.Doctor
{
    public class DoctorMedicalRecordSaveDTO
    {
        public int EncounterID { get; set; }
        public string ChiefComplaint { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string ICDCode { get; set; }
        public string Conclusion { get; set; }
        public string Notes { get; set; }
    }
}
