using System;
using System.Collections.Generic;
using System.Data;
using BUS.Services;
using DAL.Models;
using DTO;

namespace ClinicManagementSystem.Winforms.Controllers
{
    internal class CreateAppointmentController
    {
        private readonly Patient_RecepBUS patientBUS = new();
        private readonly Department_RecepBUS departmentBUS = new();
        private readonly Employee_RecepBUS employeeBUS = new();
        private readonly Room_RecepBUS roomBUS = new();

        private readonly AppointmentBUS appointmentBUS;
        private readonly DoctorScheduleBUS doctorScheduleBUS;

        public CreateAppointmentController()
        {
            var context = new CMSDbContext();

            appointmentBUS = new AppointmentBUS(context);
            doctorScheduleBUS = new DoctorScheduleBUS(context);
        }

        public List<PatientDTO> GetPatients()
        {
            return patientBUS.GetList();
        }

        public List<DepartmentDTO> GetDepartments()
        {
            return departmentBUS.GetAll();
        }

        public List<EmployeeDTO> GetDoctorsByDepartment(
            int departmentId)
        {
            return employeeBUS.GetDoctorsByDepartment(
                departmentId);
        }

        public bool CreateAppointment(
    int patientId,
    int departmentId,
    int doctorId,
    DateTime appointmentDate)
        {
            int? roomId =
                doctorScheduleBUS
                    .GetRoomIdByDoctor(
                        doctorId);

            if (!roomId.HasValue)
                return false;

            AppointmentDTO appointment =
                new AppointmentDTO
                {
                    PatientID = patientId,
                    DoctorID = doctorId,
                    DepartmentID = departmentId,
                    RoomID = roomId.Value,
                    AppointmentDate = appointmentDate,
                    Status = "Waiting"
                };

            return appointmentBUS.Create(
                appointment);
        }

        public List<DoctorCardDTO> GetDoctorCards(
    int departmentId,
    DateTime selectedDate,
    TimeSpan selectedTime)
        {
            var doctors =
                employeeBUS.GetDoctorsByDepartment(
                    departmentId);

            List<DoctorCardDTO> result = new();

            foreach (var doctor in doctors)
            {
                DoctorScheduleDTO schedule =
                    doctorScheduleBUS.GetSchedule(
                        doctor.EmployeeID,
                        selectedDate);

                string roomCode = "N/A";

                string shiftName = "-";

                string status;

                int currentPatients = 0;

                int maxPatients = 20;

                if (schedule == null)
                {
                    status = "Không trực";
                }
                else
                {
                    Room_RecepDTO room =
                        roomBUS.GetById(
                            schedule.RoomID);

                    roomCode =
                        room?.RoomCode ?? "N/A";

                    shiftName =
                        $"{schedule.StartTime:hh\\:mm}" +
                        " - " +
                        $"{schedule.EndTime:hh\\:mm}";

                    bool working =
                        selectedTime >= schedule.StartTime
                        &&
                        selectedTime < schedule.EndTime;

                    currentPatients =
    appointmentBUS
        .CountAppointmentsByDoctorAndDate(
            doctor.EmployeeID,
            selectedDate);

                    DateTime slotDateTime =
    selectedDate.Date + selectedTime;

                    bool hasAppointment =
                        appointmentBUS
                            .ExistsAppointment(
                                doctor.EmployeeID,
                                slotDateTime);

                    if (!working)
                    {
                        status = "Ngoài ca";
                    }
                    else if (hasAppointment)
                    {
                        status = "Đã có lịch";
                    }
                    else
                    {
                        status = "Đang trống";
                    }
                }

                result.Add(new DoctorCardDTO
                {
                    DoctorID = doctor.EmployeeID,

                    DoctorName = doctor.FullName,

                    RoomCode = roomCode,

                    ShiftName = shiftName,

                    Status = status,

                    CurrentPatients = currentPatients,

                    MaxPatients = maxPatients
                });
            }

            return result;
        }

        
    }
}
