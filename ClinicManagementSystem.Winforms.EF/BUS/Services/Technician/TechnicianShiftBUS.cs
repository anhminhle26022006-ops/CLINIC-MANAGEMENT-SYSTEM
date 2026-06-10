using System;
using System.Collections.Generic;
using BUS.Interfaces;
using CMS.Core.Constants;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class TechnicianShiftBUS : ITechnicianShiftBUS
    {
        private readonly TechnicianShiftDAL dal;
        private readonly EmployeeShiftBUS employeeShiftBUS = new EmployeeShiftBUS();

        public List<TechnicianShiftDTO> GetList()
        {
            return dal.GetAll();
        }

        public bool RegisterShift(TechnicianShiftDTO shift)
        {
            if (shift == null) return false;
            if (shift.ShiftDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Không thể đăng ký ca làm việc trong quá khứ.");
            }
            if (string.IsNullOrWhiteSpace(shift.Room) || string.IsNullOrWhiteSpace(shift.Department))
            {
                throw new ArgumentException("Phòng khám và chuyên khoa không được để trống.");
            }

            shift.Status = ShiftStatus.RegisteredDisplay;
            shift.EmployeeName = !string.IsNullOrWhiteSpace(shift.EmployeeName)
                ? shift.EmployeeName
                : shift.TechnicianName;

            if (employeeShiftBUS.SupportsEmployeeShiftSchema())
            {
                return employeeShiftBUS.RegisterLegacyShift(shift);
            }

            return dal.Add(shift);
        }

        public int GetShiftCount()
        {
            return dal.GetCount();
        }
    }
}
