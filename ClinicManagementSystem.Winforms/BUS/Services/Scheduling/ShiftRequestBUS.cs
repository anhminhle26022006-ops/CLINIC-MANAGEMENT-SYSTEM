using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class ShiftRequestBUS
    {
        private readonly ShiftRequestDAL _dal = new ShiftRequestDAL();
        private readonly EmployeeShiftBUS _shiftBus = new EmployeeShiftBUS();

        public bool TableExists() => _dal.TableExists();

        public List<ShiftRequestDTO> GetAll() => _dal.GetAll();

        public List<ShiftRequestDTO> GetPending() => _dal.GetByStatus("Pending");
        public List<ShiftRequestDTO> GetApproved() => _dal.GetByStatus("Approved");
        public List<ShiftRequestDTO> GetRejected() => _dal.GetByStatus("Rejected");

        public int CountPending() => _dal.CountByStatus("Pending");
        public int CountApproved() => _dal.CountByStatus("Approved");
        public int CountRejected() => _dal.CountByStatus("Rejected");

        public int GetTotalShifts()
        {
            var shifts = _shiftBus.GetAll();
            return shifts.Count;
        }

        public int GetTodayShifts()
        {
            var shifts = _shiftBus.GetAll();
            int count = 0;
            foreach (var s in shifts)
                if (s.WorkDate.Date == DateTime.Today) count++;
            return count;
        }

        public int GetUpcomingShifts(int days = 7)
        {
            var shifts = _shiftBus.GetAll();
            int count = 0;
            DateTime limit = DateTime.Today.AddDays(days);
            foreach (var s in shifts)
                if (s.WorkDate.Date > DateTime.Today && s.WorkDate.Date <= limit) count++;
            return count;
        }

        public bool Approve(int requestId, string approvedBy)
        {
            if (requestId <= 0) throw new ArgumentException("RequestID không hợp lệ.");
            return _dal.UpdateStatus(requestId, "Approved", approvedBy);
        }

        public bool Reject(int requestId, string approvedBy)
        {
            if (requestId <= 0) throw new ArgumentException("RequestID không hợp lệ.");
            return _dal.UpdateStatus(requestId, "Rejected", approvedBy);
        }
    }
}