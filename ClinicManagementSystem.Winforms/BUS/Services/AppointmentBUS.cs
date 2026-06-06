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

        public int CountAppointmentsByDoctor(
    int doctorId)
        {
            return dal.CountAppointmentsByDoctor(
                doctorId);
        }
    }
}