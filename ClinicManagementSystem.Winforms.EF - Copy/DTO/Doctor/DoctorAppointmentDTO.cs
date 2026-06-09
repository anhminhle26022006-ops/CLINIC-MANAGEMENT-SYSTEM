using System;

namespace DTO.Doctor
{
    public class DoctorAppointmentDTO
    {
        public int AppointmentID { get; set; }
        public int EncounterID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string PatientCode { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Allergy { get; set; }
        public string DepartmentName { get; set; }
        public string RoomCode { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string QueueStatus { get; set; }
        public string CurrentStep { get; set; }
        public string VitalSummary { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Temperature { get; set; }
        public string BloodPressure { get; set; }
        public int HeartRate { get; set; }
        public int SpO2 { get; set; }

        public string AgeGender
        {
            get
            {
                string age = DOB.HasValue ? CalculateAge(DOB.Value).ToString() + " tuoi" : "Chua ro tuoi";
                return string.IsNullOrWhiteSpace(Gender) ? age : age + " - " + Gender;
            }
        }

        private static int CalculateAge(DateTime dob)
        {
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return Math.Max(age, 0);
        }
    }
}
