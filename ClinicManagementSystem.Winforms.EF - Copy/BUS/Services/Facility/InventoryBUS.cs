using DTO;
using DAL;

namespace BUS
{
    public class InventoryBUS
    {
        private MedicineDAL medicineDAL =
            new MedicineDAL();

        public List<MedicineDTO> GetAllMedicines()
        {
            return medicineDAL.GetAllMedicines();
        }

        public bool AddMedicine(
            MedicineDTO medicine)
        {
            ValidateMedicine(medicine);

            return medicineDAL.InsertMedicine(
                medicine);
        }

        public bool UpdateMedicine(MedicineDTO medicine)
        {
            if (medicine == null || medicine.MedicineID <= 0)
            {
                return false;
            }

            ValidateMedicine(medicine);
            return medicineDAL.UpdateMedicine(medicine);
        }

        public bool AdjustStock(int medicineId, int quantityDelta)
        {
            if (medicineId <= 0 || quantityDelta == 0)
            {
                return false;
            }

            int currentStock = medicineDAL.GetStock(medicineId);
            if (currentStock + quantityDelta < 0)
            {
                throw new Exception("Số lượng tồn kho không đủ để xuất.");
            }

            return medicineDAL.AdjustStock(medicineId, quantityDelta);
        }

        private void ValidateMedicine(
            MedicineDTO medicine)
        {
            if (string.IsNullOrWhiteSpace(
                medicine.Name))
            {
                throw new Exception(
                    "Medicine name required.");
            }

            if (medicine.Stock < 0)
            {
                throw new Exception(
                    "Stock cannot be negative.");
            }

            if (medicine.Price <= 0)
            {
                throw new Exception(
                    "Price invalid.");
            }

            if (medicine.ExpiryDate <
                DateTime.Today)
            {
                throw new Exception(
                    "Medicine expired.");
            }
        }

        public bool DeleteMedicine(int id)
        {
            return medicineDAL.DeleteMedicine(id);
        }
    }
}
