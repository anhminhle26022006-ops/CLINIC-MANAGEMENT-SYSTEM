using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories;
using BUS.Interfaces;
using DTO;

namespace BUS.Services
{
    public class EmployeeBUS : IEmployeeBUS
    {
        private readonly EmployeeDAL _dal = new EmployeeDAL();

        public List<EmployeeDTO> GetAll()
        {
            return _dal.GetAll();
        }

        public EmployeeDTO GetById(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("EmployeeID không hợp lệ.");
            return _dal.GetById(employeeId);
        }

        public bool Add(EmployeeDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Thông tin nhân viên không được null.");
            if (string.IsNullOrWhiteSpace(employee.FullName))
                throw new ArgumentException("Họ tên không được để trống.");
            if (employee.RoleID <= 0)
                throw new ArgumentException("Vui lòng chọn chức vụ.");
            if (string.IsNullOrWhiteSpace(employee.Phone))
                throw new ArgumentException("Số điện thoại không được để trống.");
            return _dal.Add(employee);
        }

        public bool Update(EmployeeDTO employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Thông tin nhân viên không được null.");
            if (string.IsNullOrWhiteSpace(employee.FullName))
                throw new ArgumentException("Họ tên không được để trống.");
            return _dal.Update(employee);
        }

        public bool Delete(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("EmployeeID không hợp lệ.");
            return _dal.Delete(employeeId);
        }

        public List<EmployeeDTO> Search(string keyword, string roleName)
        {
            var all = _dal.GetAll();
            return all.Where(e =>
            {
                bool matchKeyword = string.IsNullOrEmpty(keyword)
                    || e.FullName.ToLower().Contains(keyword.ToLower())
                    || e.EmployeeCode.ToLower().Contains(keyword.ToLower());
                bool matchRole = string.IsNullOrEmpty(roleName) || e.RoleName == roleName;
                return matchKeyword && matchRole;
            }).ToList();
        }
    }
}