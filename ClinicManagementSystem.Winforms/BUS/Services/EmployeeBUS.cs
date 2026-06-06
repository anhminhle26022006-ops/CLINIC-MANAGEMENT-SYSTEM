using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class EmployeeBUS
    {
        private readonly EmployeeDAL dal = new();

        public List<EmployeeDTO> GetDoctorsByDepartment(
            int departmentId)
        {
            return dal.GetDoctorsByDepartment(
                departmentId);
        }
    }
}