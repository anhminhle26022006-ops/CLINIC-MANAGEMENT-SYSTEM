using BUS.Interfaces;
using DAL.Interfaces;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUS.Services
{
    public class EmployeeBUS : IEmployeeBUS
    {
        private readonly IEmployeeDAL dal;

        public EmployeeBUS(IEmployeeDAL repo)
        {
            dal = repo;
        }

        public List<EmployeeDTO> GetAll()
        {
            return dal.GetAll();
        }

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return new List<EmployeeDTO>();

            return dal.GetByRole(roleName.Trim());
        }

        public EmployeeDTO GetById(int employeeId)
        {
            return dal.GetById(employeeId);
        }

        public EmployeeDTO FindByName(string fullName)
        {
            return dal.FindByName(fullName);
        }

        public bool Exists(int employeeId)
        {
            return dal.Exists(employeeId);
        }

        public Task<List<ApiEmployeeDTO>> GetAllAsync()
        {
            return dal.GetAllAsync();
        }

        public Task<ApiEmployeeDTO> AddAsync(ApiEmployeeDTO dto)
        {
            return dal.InsertAsync(dto);
        }

        public bool Add(EmployeeDTO employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FullName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(employee.RoleName) && employee.RoleID <= 0)
            {
                return false;
            }

            if (employee.DepartmentID <= 0)
            {
                return false;
            }

            return dal.Add(employee);
        }

        public bool UpdateBasic(EmployeeDTO employee)
        {
            if (employee == null || employee.EmployeeID <= 0 || string.IsNullOrWhiteSpace(employee.FullName))
            {
                return false;
            }

            return dal.UpdateBasic(employee);
        }

        public bool SetStatus(int id, string status)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(status))
            {
                return false;
            }

            return dal.SetStatus(id, status.Trim());
        }

        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
