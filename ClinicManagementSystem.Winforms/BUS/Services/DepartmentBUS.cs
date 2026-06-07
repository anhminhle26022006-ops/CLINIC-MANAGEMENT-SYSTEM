using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class DepartmentBUS
    {
        private readonly DepartmentDAL dal = new();

        public List<DepartmentDTO> GetAll()
        {
            return dal.GetAll();
        }
    }
}