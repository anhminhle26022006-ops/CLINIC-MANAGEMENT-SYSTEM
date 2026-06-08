using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class Department_RecepBUS
    {
        private readonly DepartmentDAL dal = new();

        public List<DepartmentDTO> GetAll()
        {
            return dal.GetAll();
        }
    }
}