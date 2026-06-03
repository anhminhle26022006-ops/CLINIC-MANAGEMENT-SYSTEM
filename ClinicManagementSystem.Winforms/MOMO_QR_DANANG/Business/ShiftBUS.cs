using System;
using System.Collections.Generic;
using MOMO_QR_DANANG.DataAccess;
using MOMO_QR_DANANG.Models;

namespace MOMO_QR_DANANG.Business
{
    public class ShiftBUS
    {
        private readonly ShiftDAL dal = new ShiftDAL();

        public List<ShiftDTO> GetList()
        {
            return dal.GetAll();
        }

        public bool RegisterShift(ShiftDTO shift)
        {
            if (shift == null) return false;
            if (shift.ShiftDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("Không thể đăng ký ca làm việc trong quá khứ.");
            }
            if (string.IsNullOrWhiteSpace(shift.Room) || string.IsNullOrWhiteSpace(shift.Department))
            {
                throw new ArgumentException("Phòng khám và chuyên khoa không được để trống.");
            }

            shift.Status = "Đã đăng ký";
            return dal.Add(shift);
        }

        public int GetShiftCount()
        {
            return dal.GetCount();
        }
    }
}

