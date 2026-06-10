using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AppointmentDAL
    {
        private readonly CMSDbContext _context;

        public AppointmentDAL(CMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int CountNewPatients()
        {
            var firstAppointments = _context.Appointments
                .Where(a => a.AppointmentDate.HasValue)
                .GroupBy(a => a.PatientId)
                .Select(g => new
                {
                    PatientId = g.Key,
                    FirstAppointment = g.Min(a => a.AppointmentDate)
                });
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            return firstAppointments.Count(f => f.FirstAppointment.Value.Month == currentMonth &&
                                                  f.FirstAppointment.Value.Year == currentYear);
        }

        public int CountRevisitPatients()
        {
            return _context.Appointments
                .Where(a => a.PatientId.HasValue)
                .GroupBy(a => a.PatientId)
                .Count(g => g.Count() > 1);
        }

        public int CountUpcomingAppointments()
        {
            return _context.Appointments
                .Count(a => a.AppointmentDate >= DateTime.Now && a.Status != "Cancelled");
        }

        public int CountAppointmentsToday()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return _context.Appointments
                .Count(a => a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today);
        }

        public bool Create(AppointmentDTO appointment)
        {
            var entity = new Appointment
            {
                PatientId = appointment.PatientID,
                DoctorId = appointment.DoctorID,
                DepartmentId = appointment.DepartmentID,
                RoomId = appointment.RoomID,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                CreatedAt = DateTime.Now
            };
            _context.Appointments.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public int CountAppointmentsByDoctorAndDate(int doctorId, DateTime date)
        {
            var targetDate = DateOnly.FromDateTime(date.Date);
            return _context.Appointments
                .Count(a => a.DoctorId == doctorId &&
                            a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == targetDate);
        }

        public bool ExistsAppointment(int doctorId, DateTime appointmentDate)
        {
            return _context.Appointments
                .Any(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDate);
        }

        public int CountAppointmentsByStatusToday(string status)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return _context.Appointments
                .Count(a => a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today &&
                            a.Status == status);
        }

        public List<AppointmentTodayDTO> GetAppointmentsToday()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var query = _context.Appointments
                .Where(a => a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Department)
                .Include(a => a.Room)
                .OrderBy(a => a.AppointmentDate)
                .Select(a => new AppointmentTodayDTO
                {
                    AppointmentID = a.AppointmentId,
                    TimeText = a.AppointmentDate.HasValue ? a.AppointmentDate.Value.ToString("HH:mm") : "",
                    PatientName = a.Patient != null ? a.Patient.FullName : "",
                    DoctorName = a.Doctor != null ? a.Doctor.FullName : "",
                    DepartmentName = a.Department != null ? a.Department.DepartmentName : "",
                    RoomCode = a.Room != null ? a.Room.RoomCode : "",
                    Status = a.Status ?? ""
                })
                .ToList();
            return query;
        }

        public bool UpdateStatus(int appointmentId, string status)
        {
            var app = _context.Appointments.Find(appointmentId);
            if (app == null) return false;
            app.Status = status;
            return _context.SaveChanges() > 0;
        }

        public List<AppointmentTodayDTO> SearchAppointmentsToday(string keyword, string department, string status)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var query = _context.Appointments
                .Where(a => a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Department)
                .Include(a => a.Room)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(a => (a.Patient != null && (a.Patient.FullName.Contains(keyword) ||
                                                                a.Patient.PatientCode.Contains(keyword) ||
                                                                a.Patient.Phone.Contains(keyword))));
            }
            if (!string.IsNullOrWhiteSpace(department))
            {
                query = query.Where(a => a.Department != null && a.Department.DepartmentName == department);
            }
            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(a => a.Status == status);
            }

            var result = query.OrderBy(a => a.AppointmentDate)
                .Select(a => new AppointmentTodayDTO
                {
                    AppointmentID = a.AppointmentId,
                    TimeText = a.AppointmentDate.HasValue ? a.AppointmentDate.Value.ToString("HH:mm") : "",
                    PatientName = a.Patient != null ? a.Patient.FullName : "",
                    DoctorName = a.Doctor != null ? a.Doctor.FullName : "",
                    DepartmentName = a.Department != null ? a.Department.DepartmentName : "",
                    RoomCode = a.Room != null ? a.Room.RoomCode : "",
                    Status = a.Status ?? ""
                })
                .ToList();
            return result;
        }

        public int CountAppointmentsByDoctorAndStatusToday(int doctorId, string status)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return _context.Appointments
                .Count(a => a.DoctorId == doctorId &&
                            a.Status == status &&
                            a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today);
        }

        public string GetCurrentPatientByDoctor(int doctorId)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var patient = _context.Appointments
                .Where(a => a.DoctorId == doctorId &&
                            a.Status == "Examining" &&
                            a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today)
                .OrderBy(a => a.AppointmentDate)
                .Select(a => a.Patient != null ? a.Patient.FullName : "")
                .FirstOrDefault();
            return patient ?? "";
        }

        public List<WaitingPatientDTO> GetWaitingPatientsByDoctor(int doctorId)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var appointments = _context.Appointments
                .Where(a => a.DoctorId == doctorId &&
                            a.Status == "Waiting" &&
                            a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today)
                .Include(a => a.Patient)
                .OrderBy(a => a.AppointmentDate)
                .ToList();

            var list = new List<WaitingPatientDTO>();
            int queueNumber = 1;
            foreach (var a in appointments)
            {
                list.Add(new WaitingPatientDTO
                {
                    QueueNumber = queueNumber++,
                    PatientName = a.Patient?.FullName ?? "",
                    PatientCode = a.Patient?.PatientCode ?? "",
                    AppointmentTime = a.AppointmentDate ?? DateTime.MinValue
                });
            }
            return list;
        }

        public int GetCurrentQueueNumber(int doctorId)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var examiningAppointment = _context.Appointments
                .FirstOrDefault(a => a.DoctorId == doctorId &&
                                     a.Status == "Examining" &&
                                     a.AppointmentDate.HasValue &&
                                     DateOnly.FromDateTime(a.AppointmentDate.Value) == today);
            if (examiningAppointment == null) return 0;

            var orderedAppointments = _context.Appointments
                .Where(a => a.DoctorId == doctorId &&
                            a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today)
                .OrderBy(a => a.AppointmentDate)
                .ToList();

            int queueNumber = 1;
            foreach (var app in orderedAppointments)
            {
                if (app.AppointmentId == examiningAppointment.AppointmentId)
                    return queueNumber;
                queueNumber++;
            }
            return 0;
        }

        public string GetCurrentPatientCodeByDoctor(int doctorId)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var patientCode = _context.Appointments
                .Where(a => a.DoctorId == doctorId &&
                            a.Status == "Examining" &&
                            a.AppointmentDate.HasValue &&
                            DateOnly.FromDateTime(a.AppointmentDate.Value) == today)
                .OrderBy(a => a.AppointmentDate)
                .Select(a => a.Patient != null ? a.Patient.PatientCode : "")
                .FirstOrDefault();
            return patientCode ?? "";
        }
    }

    // DTO cho lịch hẹn hôm nay (nếu chưa có)
    public class AppointmentTodayDTO
    {
        public int AppointmentID { get; set; }
        public string TimeText { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string RoomCode { get; set; }
        public string Status { get; set; }
    }
}