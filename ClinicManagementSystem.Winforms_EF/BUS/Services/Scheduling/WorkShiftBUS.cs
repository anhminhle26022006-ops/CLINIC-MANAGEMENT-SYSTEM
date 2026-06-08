using System;
using System.Collections.Generic;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class WorkShiftBUS : IWorkShiftBUS
    {
        private readonly WorkShiftDAL dal = new WorkShiftDAL();

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
