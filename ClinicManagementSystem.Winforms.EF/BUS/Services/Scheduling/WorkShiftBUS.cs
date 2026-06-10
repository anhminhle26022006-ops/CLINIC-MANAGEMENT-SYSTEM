using BUS.Interfaces;
using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class WorkShiftBUS : IWorkShiftBUS
    {
        private readonly WorkShiftDAL dal;

        public WorkShiftBUS()
        {
            dal = new WorkShiftDAL(new CMSDbContext());
        }

        public WorkShiftBUS(CMSDbContext context)
        {
            dal = new WorkShiftDAL(context);
        }

        public List<WorkShiftDTO> GetAll()
        {
            return dal.GetAll();
        }

        public WorkShiftDTO GetById(int shiftId)
        {
            return dal.GetById(shiftId);
        }

        public int GetOrCreateShiftId(string shiftName)
        {
            if (string.IsNullOrWhiteSpace(shiftName))
            {
                throw new ArgumentException("Tên ca làm việc không được để trống.");
            }

            return dal.GetOrCreateShiftId(shiftName.Trim());
        }

        public bool Exists(int shiftId)
        {
            return dal.Exists(shiftId);
        }
    }
}