using System.Collections.Generic;
using CMS.Core.Constants;
using DAL.Interfaces;
using DAL.Models;
using DTO;

namespace DAL.Repositories
{
    public class TechnicianShiftDAL : ITechnicianShiftDAL
    {
        private readonly EmployeeShiftDAL _employeeShiftDal;
        private readonly EmployeeDAL _employeeDal;
        private readonly WorkShiftDAL _workShiftDal;

        public TechnicianShiftDAL(CMSDbContext context)
        {
            _employeeShiftDal = new EmployeeShiftDAL(context);
            _employeeDal = new EmployeeDAL(context);
            _workShiftDal = new WorkShiftDAL(context);
        }

        public List<TechnicianShiftDTO> GetAll()
        {
            var list = new List<TechnicianShiftDTO>();
            if (!_employeeShiftDal.SupportsEmployeeShiftSchema())
                return list;

            // Sửa: thay Role.Technician bằng chuỗi "Technician"
            foreach (var employeeShift in _employeeShiftDal.GetByRole("Technician"))
            {
                list.Add(new TechnicianShiftDTO
                {
                    ShiftID = employeeShift.ShiftID,
                    EmployeeShiftID = employeeShift.EmployeeShiftID,
                    EmployeeID = employeeShift.EmployeeID,
                    ShiftDate = employeeShift.WorkDate,
                    ShiftName = employeeShift.ShiftName,
                    StartTime = employeeShift.StartTime,
                    EndTime = employeeShift.EndTime,
                    RoomID = employeeShift.RoomID,
                    Room = !string.IsNullOrWhiteSpace(employeeShift.RoomCode) ? employeeShift.RoomCode : "-",
                    DepartmentID = employeeShift.DepartmentID,
                    Department = employeeShift.DepartmentName,
                    Status = string.IsNullOrWhiteSpace(employeeShift.Status) ? ShiftStatus.Approved : employeeShift.Status,
                    EmployeeName = employeeShift.EmployeeName,
                    RoleName = employeeShift.RoleName,
                    TechnicianName = employeeShift.EmployeeName
                });
            }

            return list;
        }

        public bool Add(TechnicianShiftDTO shift)
        {
            if (!_employeeShiftDal.SupportsEmployeeShiftSchema())
                return false;

            int employeeId = shift.EmployeeID;
            if (employeeId <= 0)
            {
                var employee = _employeeDal.FindByName(
                    !string.IsNullOrWhiteSpace(shift.EmployeeName)
                        ? shift.EmployeeName
                        : shift.TechnicianName);
                employeeId = employee?.EmployeeID ?? 0;
            }

            if (employeeId <= 0)
                return false;

            int shiftId = shift.ShiftID > 0
                ? shift.ShiftID
                : _workShiftDal.GetOrCreateShiftId(shift.ShiftName);

            if (shiftId <= 0)
                return false;

            return _employeeShiftDal.Add(new EmployeeShiftDTO
            {
                EmployeeID = employeeId,
                ShiftID = shiftId,
                WorkDate = shift.ShiftDate.Date,
                DepartmentID = shift.DepartmentID,
                DepartmentName = shift.Department,
                RoomID = shift.RoomID,
                RoomCode = shift.Room,
                Status = ShiftStatus.Approved
            });
        }

        public int GetCount() => GetAll().Count;
    }
}