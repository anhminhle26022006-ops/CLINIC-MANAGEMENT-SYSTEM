using DTO;
using DAL;

namespace BUS
{
    public class InventoryBUS
    {
        private MedicineDAL medicineDAL = new MedicineDAL();

        public List<MedicineDTO> GetAllMedicines()
        {
            return medicineDAL.GetAllMedicines();
        }

        public bool AddMedicine(MedicineDTO medicine)
        {
            ValidateMedicine(medicine);

            return medicineDAL.InsertMedicine(medicine);
        }

        public bool UpdateMedicine(MedicineDTO medicine)
        {
            ValidateMedicine(medicine);

            return medicineDAL.UpdateMedicine(medicine);
        }

        public bool DeleteMedicine(Guid medicineId)
        {
            return medicineDAL.SoftDeleteMedicine(medicineId);
        }

        private void ValidateMedicine(MedicineDTO medicine)
        {
            if (string.IsNullOrWhiteSpace(medicine.MedicineName))
            {
                throw new Exception("Medicine name is required.");
            }

            if (medicine.StockQuantity < 0)
            {
                throw new Exception("Stock cannot be negative.");
            }

            if (medicine.Price <= 0)
            {
                throw new Exception("Price must be greater than 0.");
            }

            if (medicine.ExpiredDate < DateTime.Today)
            {
                throw new Exception("Medicine is expired.");
            }
        }
    }
}
