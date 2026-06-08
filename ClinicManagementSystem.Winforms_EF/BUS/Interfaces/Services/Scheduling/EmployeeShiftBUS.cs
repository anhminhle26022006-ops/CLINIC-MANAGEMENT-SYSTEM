using System;
using System.Collections.Generic;
using BUS.Interfaces;
using CMS.Core.Constants;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class EmployeeShiftBUS : IEmployeeShiftBUS
    {
        private readonly EmployeeShiftDAL dal = new EmployeeShiftDAL();
        private readonly EmployeeDAL employeeDal = new EmployeeDAL();
        private readonly WorkShiftDAL workShiftDal = new WorkShiftDAL();

        public bool SupportsEmployeeShiftSchema()
        {
            return dal.SupportsEmployeeShiftSchema();
        }

        public List<EmployeeShiftDTO> GetAll()
        {
            return dal.GetAll();
        }

        public List<EmployeeShiftDTO> GetByEmployee(int employeeId)
        {
            return employeeId <= 0 ? new List<EmployeeShiftDTO>() : dal.GetByEmployee(employeeId);
        }

        public List<EmployeeShiftDTO> GetByDate(DateTime workDate)
        {
            return dal.GetByDate(workDate.Date);
        }

        public List<EmployeeShiftDTO> GetByRole(string roleName)
        {
            return string.IsNullOrWhiteSpace(roleName)
                ? new List<EmployeeShiftDTO>()
                : dal.GetByRole(roleName.Trim());
        }

        public bool RegisterShift(EmployeeShiftDTO shift)
        {
            ValidateForRegister(shift);

            if (dal.HasConflict(shift.EmployeeID, shift.WorkDate, shift.ShiftID))
            {
                throw new InvalidOperationException("Nhân viên đã có ca làm việc này trong ngày đã chọn.");
            }

            if (string.IsNullOrWhiteSpace(shift.Status))
            {
                shift.Status = ShiftStatus.Approved;
            }

            return dal.Add(shift);
        }

        public bool RegisterLegacyShift(TechnicianShiftDTO shift)
        {
            if (shift == null)
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

            int shiftId = shift.ShiftID > 0
                ? shift.ShiftID
                : workShiftDal.GetOrCreateShiftId(shift.ShiftName);

            EmployeeShiftDTO employeeShift = new EmployeeShiftDTO
            {
                EmployeeID = employeeId,
                ShiftID = shiftId,
                WorkDate = shift.ShiftDate.Date,
                DepartmentID = shift.DepartmentID,
                DepartmentName = shift.Department,
                RoomID = shift.RoomID,
                RoomCode = shift.Room,
                Status = ShiftStatus.Approved
            };

            RegisterShift(employeeShift);
            return true;
        }

        private void ValidateForRegister(EmployeeShiftDTO shift)
        {
            if (shift == null)
            {
                throw new ArgumentException("Thông tin ca làm việc không hợp lệ.");
            }

            if (shift.WorkDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Không thể đăng ký ca làm việc trong quá khứ.");
            }

            if (shift.EmployeeID <= 0 || !employeeDal.Exists(shift.EmployeeID))
            {
                throw new ArgumentException("Nhân viên không tồn tại hoặc chưa được đồng bộ vào Employees.");
            }

            if (shift.ShiftID <= 0 || !workShiftDal.Exists(shift.ShiftID))
            {
                throw new ArgumentException("Ca làm việc không tồn tại.");
            }
        }

        public EmployeeShiftDTO GetById(int employeeShiftId)
        {
            if (employeeShiftId <= 0) return null;
            return dal.GetById(employeeShiftId);
        }

        public bool UpdateShift(EmployeeShiftDTO shift)
        {
            if (shift == null) throw new System.ArgumentNullException("shift");
            if (shift.EmployeeID <= 0) throw new System.ArgumentException("Vui lòng chọn nhân viên.");
            return dal.Update(shift);
        }

        public bool DeleteShift(int employeeShiftId)
        {
            if (employeeShiftId <= 0) throw new System.ArgumentException("ID ca trực không hợp lệ.");
            return dal.Delete(employeeShiftId);
        }


    }
}