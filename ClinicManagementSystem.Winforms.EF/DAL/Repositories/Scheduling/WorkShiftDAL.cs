using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class WorkShiftDAL : IWorkShiftDAL
    {
        public List<WorkShiftDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return context.Shifts
                .AsNoTracking()
                .OrderBy(s => s.StartTime)
                .Select(s => Map(s))
                .ToList();
        }

        public WorkShiftDTO GetById(int shiftId)
        {
            if (shiftId <= 0)
            {
                return null;
            }

            using ClinicDbContext context = new ClinicDbContext();
            Shift shift = context.Shifts
                .AsNoTracking()
                .FirstOrDefault(s => s.ShiftID == shiftId);
            return shift == null ? null : Map(shift);
        }

        public WorkShiftDTO GetByName(string shiftName)
        {
            if (string.IsNullOrWhiteSpace(shiftName))
            {
                return null;
            }

            string name = shiftName.Trim();
            using ClinicDbContext context = new ClinicDbContext();
            Shift shift = context.Shifts
                .AsNoTracking()
                .FirstOrDefault(s => s.Name == name);
            return shift == null ? null : Map(shift);
        }

        public int GetOrCreateShiftId(string shiftName)
        {
            WorkShiftDTO existing = GetByName(shiftName);
            if (existing != null)
            {
                return existing.ShiftID;
            }

            TimeSpan start;
            TimeSpan end;
            GetDefaultTime(shiftName, out start, out end);

            using ClinicDbContext context = new ClinicDbContext();
            Shift shift = new Shift
            {
                Name = shiftName.Trim(),
                StartTime = start,
                EndTime = end
            };
            context.Shifts.Add(shift);
            context.SaveChanges();
            return shift.ShiftID;
        }

        public bool Exists(int shiftId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return shiftId > 0 && context.Shifts.Any(s => s.ShiftID == shiftId);
        }

        private static void GetDefaultTime(string shiftName, out TimeSpan start, out TimeSpan end)
        {
            string normalized = (shiftName ?? "").Trim().ToLowerInvariant();
            if (normalized.Contains("chiều") || normalized.Contains("chieu"))
            {
                start = new TimeSpan(13, 0, 0);
                end = new TimeSpan(17, 0, 0);
                return;
            }

            if (normalized.Contains("tối") || normalized.Contains("toi"))
            {
                start = new TimeSpan(17, 30, 0);
                end = new TimeSpan(21, 0, 0);
                return;
            }

            start = new TimeSpan(7, 0, 0);
            end = new TimeSpan(11, 30, 0);
        }

        private static WorkShiftDTO Map(Shift shift)
        {
            return new WorkShiftDTO
            {
                ShiftID = shift.ShiftID,
                ShiftName = shift.Name,
                StartTime = shift.StartTime ?? TimeSpan.Zero,
                EndTime = shift.EndTime ?? TimeSpan.Zero
            };
        }
    }
}
