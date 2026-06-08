using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class AppointmentBUS
    {
        private readonly AppointmentDAL dal = new AppointmentDAL();

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
    }
}