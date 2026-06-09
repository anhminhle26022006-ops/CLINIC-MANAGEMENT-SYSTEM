using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL.DataContext;
using DTO;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AppointmentDAL
    {
        public int CountNewPatients()
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var startOfMonth = new DateTime(today.Year, today.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1);

                var firstAppointments = context.Appointments
                    .GroupBy(a => a.PatientID)
                    .Select(g => new { PatientID = g.Key, FirstApp = g.Min(x => x.AppointmentDate) });

                return firstAppointments
                    .Count(x => x.FirstApp >= startOfMonth && x.FirstApp < endOfMonth);
            }
        }

        public int CountRevisitPatients()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Appointments
                    .GroupBy(a => a.PatientID)
                    .Count(g => g.Count() > 1);
            }
        }

        public int CountUpcomingAppointments()
        {
            using (var context = new ClinicDbContext())
            {
                var now = DateTime.Now;
                return context.Appointments
                    .Count(a => a.AppointmentDate >= now && a.Status != "Cancelled");
            }
        }

        public int CountAppointmentsToday()
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return context.Appointments
                    .Count(a => a.AppointmentDate >= today && a.AppointmentDate < tomorrow);
            }
        }

        public bool Create(AppointmentDTO appointment)
        {
            using (var context = new ClinicDbContext())
            {
                var app = new Appointment
                {
                    AppointmentUUID = Guid.NewGuid(),
                    PatientID = appointment.PatientID,
                    DoctorID = appointment.DoctorID == 0 ? (int?)null : appointment.DoctorID,
                    DepartmentID = appointment.DepartmentID,
                    RoomID = appointment.RoomID == 0 ? (int?)null : appointment.RoomID,
                    AppointmentDate = appointment.AppointmentDate,
                    Status = appointment.Status,
                    CreatedAt = DateTime.Now
                };
                context.Appointments.Add(app);
                return context.SaveChanges() > 0;
            }
        }

        public int CountAppointmentsByDoctorAndDate(int doctorId, DateTime date)
        {
            using (var context = new ClinicDbContext())
            {
                var targetDate = date.Date;
                var nextDate = targetDate.AddDays(1);
                return context.Appointments
                    .Count(a => a.DoctorID == doctorId && a.AppointmentDate >= targetDate && a.AppointmentDate < nextDate);
            }
        }

        public bool ExistsAppointment(int doctorId, DateTime appointmentDate)
        {
            using (var context = new ClinicDbContext())
            {
                return context.Appointments
                    .Any(a => a.DoctorID == doctorId && a.AppointmentDate == appointmentDate);
            }
        }

        public int CountAppointmentsByStatusToday(string status)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return context.Appointments
                    .Count(a => a.Status == status && a.AppointmentDate >= today && a.AppointmentDate < tomorrow);
            }
        }

        private DataTable ToAppointmentDataTable(IEnumerable<dynamic> items)
        {
            var dt = new DataTable();
            dt.Columns.Add("AppointmentID", typeof(int));
            dt.Columns.Add("Giờ khám", typeof(string));
            dt.Columns.Add("Bệnh nhân", typeof(string));
            dt.Columns.Add("Bác sĩ", typeof(string));
            dt.Columns.Add("Chuyên khoa", typeof(string));
            dt.Columns.Add("Phòng", typeof(string));
            dt.Columns.Add("Trạng thái", typeof(string));

            foreach (var item in items)
            {
                dt.Rows.Add(
                    item.AppointmentID,
                    item.GioKham,
                    item.PatientName,
                    item.DoctorName,
                    item.DepartmentName,
                    item.RoomCode,
                    item.Status
                );
            }

            return dt;
        }

        public DataTable GetAppointmentsToday()
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                var query = from a in context.Appointments
                            join p in context.Patients on a.PatientID equals p.PatientID
                            join e in context.Employees on a.DoctorID equals e.EmployeeID
                            join d in context.Departments on a.DepartmentID equals d.DepartmentID
                            join r in context.Rooms on a.RoomID equals r.RoomID
                            where a.AppointmentDate >= today && a.AppointmentDate < tomorrow
                            orderby a.AppointmentDate
                            select new
                            {
                                a.AppointmentID,
                                GioKham = a.AppointmentDate.HasValue ? a.AppointmentDate.Value.ToString("HH:mm") : "",
                                PatientName = p.FullName,
                                DoctorName = e.FullName,
                                DepartmentName = d.DepartmentName,
                                RoomCode = r.RoomCode,
                                a.Status
                            };

                return ToAppointmentDataTable(query.ToList());
            }
        }

        public bool UpdateStatus(int appointmentId, string status)
        {
            using (var context = new ClinicDbContext())
            {
                var app = context.Appointments.Find(appointmentId);
                if (app != null)
                {
                    app.Status = status;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public DataTable SearchAppointmentsToday(string keyword, string department, string status)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                var query = from a in context.Appointments
                            join p in context.Patients on a.PatientID equals p.PatientID
                            join e in context.Employees on a.DoctorID equals e.EmployeeID
                            join d in context.Departments on a.DepartmentID equals d.DepartmentID
                            join r in context.Rooms on a.RoomID equals r.RoomID
                            where a.AppointmentDate >= today && a.AppointmentDate < tomorrow
                            select new
                            {
                                a.AppointmentID,
                                GioKham = a.AppointmentDate.HasValue ? a.AppointmentDate.Value.ToString("HH:mm") : "",
                                PatientName = p.FullName,
                                PatientCode = p.PatientCode,
                                Phone = p.Phone,
                                DoctorName = e.FullName,
                                DepartmentName = d.DepartmentName,
                                RoomCode = r.RoomCode,
                                a.Status,
                                a.AppointmentDate
                            };

                var list = query.ToList();

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.Trim().ToLower();
                    list = list.Where(x => (x.PatientName != null && x.PatientName.ToLower().Contains(keyword))
                                        || (x.PatientCode != null && x.PatientCode.ToLower().Contains(keyword))
                                        || (x.Phone != null && x.Phone.Contains(keyword))).ToList();
                }

                if (!string.IsNullOrEmpty(department))
                {
                    list = list.Where(x => x.DepartmentName == department).ToList();
                }

                if (!string.IsNullOrEmpty(status))
                {
                    list = list.Where(x => x.Status == status).ToList();
                }

                var orderedList = list.OrderBy(x => x.AppointmentDate).Select(x => new
                {
                    x.AppointmentID,
                    x.GioKham,
                    x.PatientName,
                    x.DoctorName,
                    x.DepartmentName,
                    x.RoomCode,
                    x.Status
                });

                return ToAppointmentDataTable(orderedList);
            }
        }

        public int CountAppointmentsByDoctorAndStatusToday(int doctorId, string status)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                return context.Appointments
                    .Count(a => a.DoctorID == doctorId && a.Status == status && a.AppointmentDate >= today && a.AppointmentDate < tomorrow);
            }
        }

        public string GetCurrentPatientByDoctor(int doctorId)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                var query = from a in context.Appointments
                            join p in context.Patients on a.PatientID equals p.PatientID
                            where a.DoctorID == doctorId && a.Status == "Examining" && a.AppointmentDate >= today && a.AppointmentDate < tomorrow
                            orderby a.AppointmentDate
                            select p.FullName;

                return query.FirstOrDefault() ?? "";
            }
        }

        public List<WaitingPatientDTO> GetWaitingPatientsByDoctor(int doctorId)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                var query = from a in context.Appointments
                            join p in context.Patients on a.PatientID equals p.PatientID
                            where a.DoctorID == doctorId && a.Status == "Waiting" && a.AppointmentDate >= today && a.AppointmentDate < tomorrow
                            orderby a.AppointmentDate
                            select new
                            {
                                p.FullName,
                                p.PatientCode,
                                a.AppointmentDate
                            };

                var list = new List<WaitingPatientDTO>();
                int queueNumber = 1;
                foreach (var item in query.ToList())
                {
                    list.Add(new WaitingPatientDTO
                    {
                        QueueNumber = queueNumber++,
                        PatientName = item.FullName ?? "",
                        PatientCode = item.PatientCode ?? "",
                        AppointmentTime = item.AppointmentDate ?? DateTime.MinValue
                    });
                }
                return list;
            }
        }

        public int GetCurrentQueueNumber(int doctorId)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                var currentExamining = context.Appointments
                    .Where(a => a.DoctorID == doctorId && a.Status == "Examining" && a.AppointmentDate >= today && a.AppointmentDate < tomorrow)
                    .Select(a => a.AppointmentID)
                    .FirstOrDefault();

                if (currentExamining == 0)
                    return 0;

                var listToday = context.Appointments
                    .Where(a => a.DoctorID == doctorId && a.AppointmentDate >= today && a.AppointmentDate < tomorrow)
                    .OrderBy(a => a.AppointmentDate)
                    .Select(a => a.AppointmentID)
                    .ToList();

                int queueNumber = 1;
                foreach (var id in listToday)
                {
                    if (id == currentExamining)
                        return queueNumber;
                    queueNumber++;
                }

                return 0;
            }
        }

        public string GetCurrentPatientCodeByDoctor(int doctorId)
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);
                var query = from a in context.Appointments
                            join p in context.Patients on a.PatientID equals p.PatientID
                            where a.DoctorID == doctorId && a.Status == "Examining" && a.AppointmentDate >= today && a.AppointmentDate < tomorrow
                            orderby a.AppointmentDate
                            select p.PatientCode;

                return query.FirstOrDefault() ?? "";
            }
        }
    }
}
