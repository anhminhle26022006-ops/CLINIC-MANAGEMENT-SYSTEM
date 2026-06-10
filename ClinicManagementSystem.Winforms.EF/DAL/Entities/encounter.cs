using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Encounter
    {
        [Key]
        public int EncounterID { get; set; }
        public Guid EncounterUUID { get; set; }
        public int? AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        public Patient Patient { get; set; }
        public Employee Doctor { get; set; }
        public Appointment Appointment { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public ICollection<VitalSign> VitalSigns { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<LabRequest> LabRequests { get; set; }
        public ICollection<ImagingRequest> ImagingRequests { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<FollowUp> FollowUps { get; set; }
    }
}