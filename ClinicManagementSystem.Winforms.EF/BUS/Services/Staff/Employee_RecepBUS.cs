using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class Employee_RecepBUS
    {
        private readonly Employee_RecepDAL dal = new();

        public List<EmployeeDTO> GetDoctorsByDepartment(
            int departmentId)
        {
            return dal.GetDoctorsByDepartment(
                departmentId);
        }

        public EmployeeDTO GetById(
    int employeeId)
        {
            return dal.GetById(
                employeeId);
        }
    }
}