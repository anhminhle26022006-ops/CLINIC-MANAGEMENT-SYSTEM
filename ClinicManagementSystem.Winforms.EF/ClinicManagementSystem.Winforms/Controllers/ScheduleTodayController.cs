using System.Collections.Generic;
using BUS.Services;
using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using DTO;

namespace ClinicManagementSystem.Winforms.Controllers
{
    internal class ScheduleTodayController
    {
        private readonly AppointmentBUS appointmentBUS;

        public ScheduleTodayController()
        {
            appointmentBUS =
                new AppointmentBUS(
                    new CMSDbContext());
        }

        public int GetTotalToday()
            => appointmentBUS.CountAppointmentsToday();

        public int GetWaitingToday()
            => appointmentBUS.CountWaitingAppointmentsToday();

        public int GetReceivedToday()
            => appointmentBUS.CountReceivedAppointmentsToday();

        public int GetExaminingToday()
            => appointmentBUS.CountExaminingAppointmentsToday();

        public int GetCompletedToday()
            => appointmentBUS.CountCompletedAppointmentsToday();

        public List<AppointmentTodayDTO> GetAppointmentsToday()
            => appointmentBUS.GetAppointmentsToday();

        public bool ReceiveAppointment(int appointmentId)
            => appointmentBUS.UpdateStatus(appointmentId, "Received");

        public List<AppointmentTodayDTO> SearchAppointments(
            string keyword,
            string department,
            string status)
            => appointmentBUS.SearchAppointmentsToday(
                keyword,
                department,
                status);
    }
}