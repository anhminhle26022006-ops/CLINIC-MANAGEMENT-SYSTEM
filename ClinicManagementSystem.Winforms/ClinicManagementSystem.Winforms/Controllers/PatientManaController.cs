using BUS.Services;
using DTO;
using System.Collections.Generic;

namespace ClinicManagementSystem.Controllers
{
    public class PatientManaController
    {
        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly AppointmentBUS appointmentBUS = new AppointmentBUS();

        public List<PatientDTO> GetPatients() => patientBUS.GetList();

        public List<PatientDTO> SearchPatients(string keyword) => patientBUS.FilterList(keyword);

        public bool CreatePatient(PatientDTO patient, PatientInsuranceDTO insurance)
            => patientBUS.CreatePatient(patient);

        public bool UpdatePatient(PatientDTO patient) => patientBUS.UpdatePatient(patient);

        public int CountPatients() => patientBUS.CountPatients();

        public int CountNewPatients() => appointmentBUS.CountNewPatients();

        public int CountRevisitPatients() => appointmentBUS.CountRevisitPatients();

        public int CountUpcomingAppointments() => appointmentBUS.CountUpcomingAppointments();

        public string GenerateNewPatientCode() => patientBUS.GenerateNewPatientCode();
    }
}