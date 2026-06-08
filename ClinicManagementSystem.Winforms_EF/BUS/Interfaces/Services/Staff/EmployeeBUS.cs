using System;
using System.Collections.Generic;
using System.Data;
using BUS.Interfaces;
using DAL.DataContext;
using DAL.Repositories;
using DTO;
using Microsoft.Data.SqlClient;

namespace BUS.Services
{
    public class EmployeeBUS : IEmployeeBUS
    {
        private readonly EmployeeDAL _dal = new EmployeeDAL();

        public List<EmployeeDTO> GetAll() { return _dal.GetAll(); }

        public EmployeeDTO GetById(int employeeId)
        {
            if (employeeId <= 0) throw new ArgumentException("EmployeeID không hợp lệ.");
            return _dal.GetById(employeeId);
        }

        public bool Exists(int employeeId) { return _dal.Exists(employeeId); }

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return new List<EmployeeDTO>();
            return _dal.GetByRole(roleName.Trim());
        }

        public EmployeeDTO FindByName(string fullName) { return _dal.FindByName(fullName); }

        public bool Add(EmployeeDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Họ tên không được để trống.");
            if (dto.RoleID <= 0)
                throw new ArgumentException("Vui lòng chọn chức vụ.");
            if (string.IsNullOrWhiteSpace(dto.Phone))
                throw new ArgumentException("Số điện thoại không được để trống.");
            return _dal.Add(dto);
        }

        public bool Update(EmployeeDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Họ tên không được để trống.");
            return _dal.Update(dto);
        }

        public bool Delete(int employeeId)
        {
            if (employeeId <= 0) throw new ArgumentException("EmployeeID không hợp lệ.");
            return _dal.Delete(employeeId);
        }

        public List<EmployeeDTO> Search(string keyword, string roleName)
        {
            List<EmployeeDTO> all = _dal.GetAll();
            List<EmployeeDTO> result = new List<EmployeeDTO>();
            foreach (EmployeeDTO e in all)
            {
                bool matchKeyword = string.IsNullOrEmpty(keyword)
                    || (e.FullName != null && e.FullName.ToLower().Contains(keyword.ToLower()))
                    || (e.EmployeeCode != null && e.EmployeeCode.ToLower().Contains(keyword.ToLower()));
                bool matchRole = string.IsNullOrEmpty(roleName) || e.RoleName == roleName;
                if (matchKeyword && matchRole) result.Add(e);
            }
            return result;
        }

        public Dictionary<int, string> GetAvailableRoles()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT RoleID, RoleName FROM Roles ORDER BY RoleName");
                foreach (DataRow row in dt.Rows)
                    result[Convert.ToInt32(row["RoleID"])] = row["RoleName"].ToString();
            }
            catch { }
            return result;
        }
    }
}