using System;
using System.Collections.Generic;

namespace DTO
{
    public class PrescriptionDTO
    {
        public int PrescriptionID { get; set; }
        public int EncounterID { get; set; }
        public int DoctorID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // UI-bound properties populated via joins
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public DateTime? PatientDOB { get; set; }
        public string PatientCode { get; set; }
        public string PatientAllergies { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public string DoctorNotes { get; set; }

        public List<PrescriptionItemDTO> Items { get; set; } = new List<PrescriptionItemDTO>();
    }
}
