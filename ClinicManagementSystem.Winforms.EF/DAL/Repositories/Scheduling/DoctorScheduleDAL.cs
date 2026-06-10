using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DoctorScheduleDAL
    {
        private readonly CMSDbContext _context;

        public DoctorScheduleDAL(CMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int? GetRoomIdByDoctor(int doctorId)
        {
            var schedule = _context.DoctorSchedules
                .Where(ds => ds.DoctorId == doctorId)
                .FirstOrDefault();

            return schedule?.RoomId;
        }

        public DoctorScheduleDTO GetSchedule(int doctorId, DateTime workDate)
        {
            var targetDate = DateOnly.FromDateTime(workDate.Date);
            var schedule = _context.DoctorSchedules
                .FirstOrDefault(ds => ds.DoctorId == doctorId && ds.WorkDate == targetDate);

            if (schedule == null) return null;

            return new DoctorScheduleDTO
            {
                ScheduleID = schedule.ScheduleId,
                DoctorID = schedule.DoctorId ?? 0,
                WorkDate = schedule.WorkDate?.ToDateTime(TimeOnly.MinValue) ?? DateTime.MinValue,
                StartTime = schedule.StartTime?.ToTimeSpan() ?? TimeSpan.Zero,
                EndTime = schedule.EndTime?.ToTimeSpan() ?? TimeSpan.Zero,
                RoomID = schedule.RoomId ?? 0
            };
        }

        public int CountActiveRoomsToday()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var roomCount = _context.DoctorSchedules
                .Where(ds => ds.WorkDate == today && ds.RoomId.HasValue)
                .Select(ds => ds.RoomId)
                .Distinct()
                .Count();

            return roomCount;
        }

        public List<DoctorQueueDTO> GetDoctorQueues()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var doctors = _context.Employees
                .Include(e => e.Department)
                .Where(e => e.Role.RoleName == "Doctor")
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FullName,
                    DepartmentName = e.Department != null ? e.Department.DepartmentName : "",
                    Room = _context.DoctorSchedules
                        .Where(ds => ds.DoctorId == e.EmployeeId && ds.WorkDate == today)
                        .Select(ds => ds.Room.RoomCode)
                        .FirstOrDefault()
                })
                .ToList();

            var list = new List<DoctorQueueDTO>();
            foreach (var doc in doctors)
            {
                list.Add(new DoctorQueueDTO
                {
                    DoctorId = doc.EmployeeId,
                    DoctorName = doc.FullName ?? "",
                    DepartmentName = doc.DepartmentName,
                    RoomCode = doc.Room ?? "-",
                    Shift = "Cả ngày"
                });
            }
            return list;
        }
    }
}