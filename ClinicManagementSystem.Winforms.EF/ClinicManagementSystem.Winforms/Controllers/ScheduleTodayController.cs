using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Services;

namespace ClinicManagementSystem.Winforms.Controllers
{
    internal class ScheduleTodayController
    {
        private readonly AppointmentBUS appointmentBUS =
    new();

        public int GetTotalToday()
        {
            return appointmentBUS.CountAppointmentsToday();
        }

        public int GetWaitingToday()
        {
            return appointmentBUS.CountWaitingAppointmentsToday();
        }

        public int GetReceivedToday()
        {
            return appointmentBUS.CountReceivedAppointmentsToday();
        }

        public int GetExaminingToday()
        {
            return appointmentBUS.CountExaminingAppointmentsToday();
        }

        public int GetCompletedToday()
        {
            return appointmentBUS.CountCompletedAppointmentsToday();
        }

        public DataTable GetAppointmentsToday()
        {
            return appointmentBUS.GetAppointmentsToday();
        }

        public bool ReceiveAppointment(
        int appointmentId)
        {
            return appointmentBUS.UpdateStatus(
                appointmentId,
                "Received");
        }

        public DataTable SearchAppointments(
    string keyword,
    string department,
    string status)
        {
            return appointmentBUS.SearchAppointmentsToday(
                keyword,
                department,
                status);
        }
    }
}
