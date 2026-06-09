using System;

namespace DTO.Doctor
{
    public class DoctorHistoryDTO
    {
        public int EncounterID { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }
        public string DoctorName { get; set; }
        public string Status { get; set; }
        public string PrescriptionSummary { get; set; }
    }
}
