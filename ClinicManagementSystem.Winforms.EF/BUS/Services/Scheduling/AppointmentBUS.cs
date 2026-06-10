using System.Data;
using DAL.Models;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class AppointmentBUS
    {
        private readonly AppointmentDAL dal;

        public AppointmentBUS()
        {
            dal = new AppointmentDAL(new CMSDbContext());
        }

        public AppointmentBUS(CMSDbContext context)
        {
            dal = new AppointmentDAL(context);
        }

        public bool Create(AppointmentDTO appointment)
        {
            return dal.Create(appointment);
        }

        public int CountNewPatients()
        {
            return dal.CountNewPatients();
        }

        public int CountRevisitPatients()
        {
            return dal.CountRevisitPatients();
        }

        public int CountUpcomingAppointments()
        {
            return dal.CountUpcomingAppointments();
        }

        public int CountAppointmentsToday()
        {
            return dal.CountAppointmentsToday();
        }

        public int CountAppointmentsByDoctorAndDate(
    int doctorId,
    DateTime date)
        {
            return dal.CountAppointmentsByDoctorAndDate(
                    doctorId,
                    date);
        }

        public bool ExistsAppointment(
            int doctorId,
            DateTime appointmentDate)
        {
            return dal .ExistsAppointment(
                    doctorId,
                    appointmentDate);
        }

        public int CountWaitingAppointmentsToday()
        {
            return dal.CountAppointmentsByStatusToday(
                "Waiting");
        }

        public int CountReceivedAppointmentsToday()
        {
            return dal.CountAppointmentsByStatusToday(
                "Received");
        }

        public int CountExaminingAppointmentsToday()
        {
            return dal.CountAppointmentsByStatusToday(
                "Examining");
        }

        public int CountCompletedAppointmentsToday()
        {
            return dal.CountAppointmentsByStatusToday(
                "Completed");
        }

        public List<AppointmentTodayDTO> GetAppointmentsToday()
        {
            return dal.GetAppointmentsToday();
        }

        public bool UpdateStatus(
    int appointmentId,
    string status)
        {
            return dal.UpdateStatus(
                appointmentId,
                status);
        }

        public List<AppointmentTodayDTO> SearchAppointmentsToday(
    string keyword,
    string department,
    string status)
        {
            return dal.SearchAppointmentsToday(
                keyword,
                department,
                status);
        }

        public int CountAppointmentsByDoctorAndStatusToday(
    int doctorId,
    string status)
        {
            return dal
                .CountAppointmentsByDoctorAndStatusToday(
                    doctorId,
                    status);
        }

        public string GetCurrentPatientByDoctor(
            int doctorId)
        {
            return dal
                .GetCurrentPatientByDoctor(
                    doctorId);
        }

        public List<WaitingPatientDTO>
GetWaitingPatientsByDoctor(
    int doctorId)
        {
            return dal
                .GetWaitingPatientsByDoctor(
                    doctorId);
        }

        public int GetCurrentQueueNumber(
    int doctorId)
        {
            return dal
                .GetCurrentQueueNumber(
                    doctorId);
        }

        public string GetCurrentPatientCodeByDoctor(
    int doctorId)
        {
            return dal
                .GetCurrentPatientCodeByDoctor(
                    doctorId);
        }
    }
}