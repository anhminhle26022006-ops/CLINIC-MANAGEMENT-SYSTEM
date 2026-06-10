using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class WorkShiftDAL : IWorkShiftDAL
    {
        private readonly CMSDbContext _context;

        public WorkShiftDAL(CMSDbContext context)
        {
            _context = context;
        }

        public List<WorkShiftDTO> GetAll()
        {
            return _context.Shifts
                .OrderBy(s => s.StartTime)
                .Select(s => new WorkShiftDTO
                {
                    ShiftID = s.ShiftId,
                    ShiftName = s.Name ?? "",
                    StartTime = s.StartTime.HasValue ? s.StartTime.Value.ToTimeSpan() : TimeSpan.Zero,
                    EndTime = s.EndTime.HasValue ? s.EndTime.Value.ToTimeSpan() : TimeSpan.Zero
                })
                .ToList();
        }

        public WorkShiftDTO GetById(int shiftId)
        {
            if (shiftId <= 0) return null;

            var shift = _context.Shifts.Find(shiftId);
            if (shift == null) return null;

            return new WorkShiftDTO
            {
                ShiftID = shift.ShiftId,
                ShiftName = shift.Name ?? "",
                StartTime = shift.StartTime.HasValue ? shift.StartTime.Value.ToTimeSpan() : TimeSpan.Zero,
                EndTime = shift.EndTime.HasValue ? shift.EndTime.Value.ToTimeSpan() : TimeSpan.Zero
            };
        }

        public WorkShiftDTO GetByName(string shiftName)
        {
            if (string.IsNullOrWhiteSpace(shiftName)) return null;

            var shift = _context.Shifts
                .FirstOrDefault(s => s.Name != null && s.Name.Trim() == shiftName.Trim());
            if (shift == null) return null;

            return new WorkShiftDTO
            {
                ShiftID = shift.ShiftId,
                ShiftName = shift.Name ?? "",
                StartTime = shift.StartTime.HasValue ? shift.StartTime.Value.ToTimeSpan() : TimeSpan.Zero,
                EndTime = shift.EndTime.HasValue ? shift.EndTime.Value.ToTimeSpan() : TimeSpan.Zero
            };
        }

        public int GetOrCreateShiftId(string shiftName)
        {
            if (string.IsNullOrWhiteSpace(shiftName)) return 0;

            // Tìm kiếm theo tên (không phân biệt hoa thường? Có thể dùng ToLower)
            var existing = _context.Shifts
                .FirstOrDefault(s => s.Name != null && s.Name.Trim().ToLower() == shiftName.Trim().ToLower());
            if (existing != null) return existing.ShiftId;

            // Tạo mới
            GetDefaultTime(shiftName, out TimeSpan start, out TimeSpan end);
            var newShift = new Shift
            {
                Name = shiftName.Trim(),
                StartTime = TimeOnly.FromTimeSpan(start),
                EndTime = TimeOnly.FromTimeSpan(end)
            };
            _context.Shifts.Add(newShift);
            _context.SaveChanges();
            return newShift.ShiftId;
        }

        public bool Exists(int shiftId)
        {
            return _context.Shifts.Any(s => s.ShiftId == shiftId);
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

            // Mặc định ca sáng
            start = new TimeSpan(7, 0, 0);
            end = new TimeSpan(11, 30, 0);
        }
    }
}