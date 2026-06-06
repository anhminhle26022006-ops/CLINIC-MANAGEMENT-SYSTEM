using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Controllers
{
    internal class CreateAppointmentController
    {
        private readonly PatientBUS patientBUS = new();
        private readonly DepartmentBUS departmentBUS = new();
        private readonly EmployeeBUS employeeBUS = new();
        private readonly RoomBUS roomBUS = new();
        private readonly AppointmentBUS appointmentBUS = new();
        private readonly DoctorScheduleBUS doctorScheduleBUS = new();

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
                    Status = "Scheduled"
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
                    RoomDTO room =
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
                            .CountAppointmentsByDoctor(
                                doctor.EmployeeID);

                    if (!working)
                    {
                        status = "Ngoài ca";
                    }
                    else if (currentPatients >= maxPatients)
                    {
                        status = "Đã đầy";
                    }
                    else
                    {
                        status = "Đang trực";
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