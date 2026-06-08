using System.Collections.Generic;
using CMS.Core.Constants;
using CMS.Core.Identity;
using DAL.Interfaces;
using DTO;

namespace DAL.Repositories
{
    public class TechnicianShiftDAL : ITechnicianShiftDAL
    {
        private readonly EmployeeShiftDAL employeeShiftDal = new EmployeeShiftDAL();
        private readonly EmployeeDAL employeeDal = new EmployeeDAL();
        private readonly WorkShiftDAL workShiftDal = new WorkShiftDAL();

        public List<TechnicianShiftDTO> GetAll()
        {
            List<TechnicianShiftDTO> list = new List<TechnicianShiftDTO>();
            if (!employeeShiftDal.SupportsEmployeeShiftSchema())
            {
                return list;
            }

            foreach (EmployeeShiftDTO employeeShift in employeeShiftDal.GetByRole(Role.Technician))
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
            if (!employeeShiftDal.SupportsEmployeeShiftSchema())
            {
                return false;
            }

            int employeeId = shift.EmployeeID;
            if (employeeId <= 0)
            {
                EmployeeDTO employee = employeeDal.FindByName(
                    !string.IsNullOrWhiteSpace(shift.EmployeeName)
                        ? shift.EmployeeName
                        : shift.TechnicianName);
                employeeId = employee != null ? employee.EmployeeID : 0;
            }

            if (employeeId <= 0)
            {
                return false;
            }

            int shiftId = shift.ShiftID > 0
                ? shift.ShiftID
                : workShiftDal.GetOrCreateShiftId(shift.ShiftName);

            if (shiftId <= 0)
            {
                return false;
            }

            return employeeShiftDal.Add(new EmployeeShiftDTO
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

        public int GetCount()
        {
            return GetAll().Count;
        }
    }
}
