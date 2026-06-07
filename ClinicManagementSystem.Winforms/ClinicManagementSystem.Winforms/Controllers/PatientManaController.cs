using BUS.Services;
using DTO;
using System.Collections.Generic;

namespace ClinicManagementSystem.Controllers
{
    public class PatientManaController
    {
        private readonly Patient_RecepBUS patientBUS = new();
        private readonly AppointmentBUS appointmentBUS = new();

        public List<PatientDTO> GetPatients()
        {
            return patientBUS.GetList();
        }

        public List<PatientDTO> SearchPatients(string keyword)
        {
            return patientBUS.FilterList(keyword);
        }

        public bool CreatePatient(
            PatientDTO patient,
            PatientInsuranceDTO insurance)
        {
            return patientBUS.CreatePatient(
                patient,
                insurance);
        }

        public bool UpdatePatient(PatientDTO patient)
        {
            return patientBUS.UpdatePatient(patient);
        }

        public int CountPatients()
        {
            return patientBUS.CountPatients();
        }

        public int CountNewPatients()
        {
            return appointmentBUS.CountNewPatients();
        }

        public int CountRevisitPatients()
        {
            return appointmentBUS.CountRevisitPatients();
        }

        public int CountUpcomingAppointments()
        {
            return appointmentBUS.CountUpcomingAppointments();
        }

        public string GenerateNewPatientCode()
        {
            return patientBUS.GenerateNewPatientCode();
        }
    }
}