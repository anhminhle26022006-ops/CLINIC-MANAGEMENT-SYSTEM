using System.Collections.Generic;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class EmployeeBUS : IEmployeeBUS
    {
        private readonly EmployeeDAL dal = new EmployeeDAL();

        public List<EmployeeDTO> GetAll() => dal.GetAll();

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return new List<EmployeeDTO>();
            return dal.GetByRole(roleName.Trim());
        }

        public EmployeeDTO GetById(int employeeId) => dal.GetById(employeeId);

        public EmployeeDTO FindByName(string fullName) => dal.FindByName(fullName);

        public bool Exists(int employeeId) => dal.Exists(employeeId);

        public bool Add(EmployeeDTO employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FullName))
                return false;
            return dal.Add(employee);
        }

        public bool Update(EmployeeDTO employee)
        {
            if (employee == null || employee.EmployeeID <= 0)
                return false;
            return dal.Update(employee);
        }

        public bool Delete(int employeeId)
        {
            if (employeeId <= 0) return false;
            return dal.Delete(employeeId);
        }
    }
}