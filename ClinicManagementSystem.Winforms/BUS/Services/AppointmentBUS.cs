using System.Data;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class AppointmentBUS
    {
        private readonly AppointmentDAL dal = new();

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

        public DataTable GetAppointmentsToday()
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

        public DataTable SearchAppointmentsToday(
    string keyword,
    string department,
    string status)
        {
            return dal.SearchAppointmentsToday(
                keyword,
                department,
                status);
        }
    }
}