using System;

namespace DTO
{
    public class NurseMedicalRecordDTO
    {
        public int EncounterID { get; set; }
        public int PatientID { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public DateTime? StartTime { get; set; }
        public string EncounterStatus { get; set; }
        public string Diagnosis { get; set; }
        public string NursingNote { get; set; }
        public decimal? Temperature { get; set; }
        public string BloodPressure { get; set; }
        public int? HeartRate { get; set; }
        public int? Spo2 { get; set; }
        public decimal? Weight { get; set; }
        public DateTime? VitalCreatedAt { get; set; }

        public int Age
        {
            get
            {
                if (!BirthDate.HasValue)
                {
                    return 0;
                }

                int age = DateTime.Today.Year - BirthDate.Value.Year;
                if (BirthDate.Value.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
