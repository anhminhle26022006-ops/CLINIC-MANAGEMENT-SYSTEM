using DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public Guid PatientUUID { get; set; }
        public string PatientCode { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Allergy { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<PatientInsurance> Insurances { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Encounter> Encounters { get; set; }
    }
}