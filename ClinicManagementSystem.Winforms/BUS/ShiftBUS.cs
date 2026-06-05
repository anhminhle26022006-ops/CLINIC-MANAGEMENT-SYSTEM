using DTO;
using DAL;

namespace BUS
{
    public class ShiftBUS
    {
        private ShiftDAL shiftDAL = new ShiftDAL();

        public List<ShiftDTO> GetShifts()
        {
            return shiftDAL.GetAllShifts();
        }

        public bool RegisterShift(ShiftDTO shift)
        {
            ValidateShift(shift);

            return shiftDAL.InsertShift(shift);
        }

        public bool SwapShift(
            Guid shiftId,
            Guid employeeId
        )
        {
            return shiftDAL.RequestSwap(
                shiftId,
                employeeId
            );
        }

        private void ValidateShift(ShiftDTO shift)
        {
            if (shift.ShiftDate < DateTime.Today)
            {
                throw new Exception(
                    "Cannot register past shift."
                );
            }

            if (string.IsNullOrWhiteSpace(shift.ShiftType))
            {
                throw new Exception(
                    "Shift type is required."
                );
            }
        }
    }
}