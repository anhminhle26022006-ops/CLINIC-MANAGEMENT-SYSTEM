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
    }
}