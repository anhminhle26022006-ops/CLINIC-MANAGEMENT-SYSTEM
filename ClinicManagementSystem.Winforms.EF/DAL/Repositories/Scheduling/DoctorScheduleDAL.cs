using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DoctorScheduleDAL
    {
        public List<DoctorScheduleDTO> GetSchedules(int doctorId, DateTime date)
        {
            using (var context = new ClinicDbContext())
            {
                var day = date.Date;
                return context.DoctorSchedules
                    .AsNoTracking()
                    .Where(s => s.DoctorID == doctorId && s.WorkDate == day)
                    .Select(s => new DoctorScheduleDTO
                    {
                        ScheduleID = s.ScheduleID,
                        DoctorID = s.DoctorID ?? 0,
                        WorkDate = s.WorkDate ?? DateTime.MinValue,
                        StartTime = s.StartTime ?? TimeSpan.Zero,
                        EndTime = s.EndTime ?? TimeSpan.Zero,
                        RoomID = s.RoomID ?? 0
                    })
                    .ToList();
            }
        }

        public int? GetRoomIdByDoctor(int doctorId)
        {
            using (var context = new ClinicDbContext())
            {
                return context.DoctorSchedules
                    .AsNoTracking()
                    .Where(s => s.DoctorID == doctorId)
                    .Select(s => s.RoomID)
                    .FirstOrDefault();
            }
        }

        public DoctorScheduleDTO GetSchedule(int doctorId, DateTime workDate)
        {
            using (var context = new ClinicDbContext())
            {
                var targetDate = workDate.Date;
                var s = context.DoctorSchedules
                    .AsNoTracking()
                    .FirstOrDefault(x => x.DoctorID == doctorId && x.WorkDate == targetDate);

                if (s == null) return null;

                return new DoctorScheduleDTO
                {
                    ScheduleID = s.ScheduleID,
                    DoctorID = s.DoctorID ?? 0,
                    WorkDate = s.WorkDate ?? DateTime.MinValue,
                    StartTime = s.StartTime ?? TimeSpan.Zero,
                    EndTime = s.EndTime ?? TimeSpan.Zero,
                    RoomID = s.RoomID ?? 0
                };
            }
        }

        public int CountActiveRoomsToday()
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;
                return context.DoctorSchedules
                    .AsNoTracking()
                    .Where(s => s.WorkDate == today && s.RoomID != null)
                    .Select(s => s.RoomID)
                    .Distinct()
                    .Count();
            }
        }

        public List<DoctorQueueDTO> GetDoctorQueues()
        {
            using (var context = new ClinicDbContext())
            {
                var today = DateTime.Today;

                var doctorRoleId = context.Roles
                    .AsNoTracking()
                    .Where(r => r.RoleName == "Doctor")
                    .Select(r => r.RoleID)
                    .FirstOrDefault();

                if (doctorRoleId == 0) return new List<DoctorQueueDTO>();

                var query = from e in context.Employees
                            join d in context.Departments on e.DepartmentID equals d.DepartmentID
                            join ds in context.DoctorSchedules.Where(s => s.WorkDate == today) on e.EmployeeID equals ds.DoctorID into dsGroup
                            from ds in dsGroup.DefaultIfEmpty()
                            join r in context.Rooms on ds.RoomID equals r.RoomID into rGroup
                            from r in rGroup.DefaultIfEmpty()
                            where e.RoleID == doctorRoleId
                            select new
                            {
                                e.EmployeeID,
                                e.FullName,
                                d.DepartmentName,
                                RoomCode = r != null ? r.RoomCode : "-"
                            };

                var list = new List<DoctorQueueDTO>();
                foreach (var item in query.ToList())
                {
                    list.Add(new DoctorQueueDTO
                    {
                        DoctorId = item.EmployeeID,
                        DoctorName = item.FullName ?? "",
                        DepartmentName = item.DepartmentName ?? "",
                        RoomCode = item.RoomCode ?? "-",
                        Shift = "Cả ngày"
                    });
                }

                return list;
            }
        }
    }
}
