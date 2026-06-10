using System;
using System.Collections.Generic;
using BUS.Services;
using DAL.Models;
using DTO;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class WaitingListController
    {
        private readonly AppointmentBUS appointmentBUS;
        private readonly DoctorScheduleBUS scheduleBUS;
        private readonly Room_RecepBUS roomBUS = new();
        private readonly Department_RecepBUS departmentBUS = new();

        public WaitingListController()
        {
            var context = new CMSDbContext();

            appointmentBUS = new AppointmentBUS(context);
            scheduleBUS = new DoctorScheduleBUS(context);
        }

        public int GetWaitingCount()
        {
            return appointmentBUS
                .CountWaitingAppointmentsToday();
        }

        public int GetExaminingCount()
        {
            return appointmentBUS
                .CountExaminingAppointmentsToday();
        }

        public int GetCompletedCount()
        {
            return appointmentBUS
                .CountCompletedAppointmentsToday();
        }

        public int GetActiveRoomCount()
        {
            return scheduleBUS
                .CountActiveRoomsToday();
        }

        public int GetTotalRoomCount()
        {
            return roomBUS.CountRooms();
        }

        public List<DepartmentDTO> GetDepartments()
        {
            return departmentBUS.GetAll();
        }

        public List<DoctorQueueDTO>
    GetDoctorQueues()
        {
            var doctors =
                scheduleBUS.GetDoctorQueues();

            foreach (var doctor in doctors)
            {
                doctor.CompletedCount =
    appointmentBUS
        .CountAppointmentsByDoctorAndStatusToday(
            doctor.DoctorId,
            "Completed");

                doctor.TotalAppointments =
                    appointmentBUS
                        .CountAppointmentsByDoctorAndDate(
                            doctor.DoctorId,
                            DateTime.Today);

                doctor.WaitingCount =
                    appointmentBUS
                        .CountAppointmentsByDoctorAndStatusToday(
                            doctor.DoctorId,
                            "Waiting");

                doctor.ExaminingCount =
                    appointmentBUS
                        .CountAppointmentsByDoctorAndStatusToday(
                            doctor.DoctorId,
                            "Examining");

                doctor.CurrentPatient =
                    appointmentBUS
                        .GetCurrentPatientByDoctor(
                            doctor.DoctorId);

                doctor.CurrentPatientCode =
    appointmentBUS
        .GetCurrentPatientCodeByDoctor(
            doctor.DoctorId);

                doctor.CurrentQueueNumber =
                    appointmentBUS
                        .GetCurrentQueueNumber(
                            doctor.DoctorId);

                doctor.WaitingPatients =
                    appointmentBUS
                        .GetWaitingPatientsByDoctor(
                            doctor.DoctorId);
            }

            return doctors;
        }
    }
}