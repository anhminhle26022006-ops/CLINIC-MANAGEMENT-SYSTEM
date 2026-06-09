using DAL.Models;
using DTO;

namespace DAL
{
    public class MedicineDAL
    {
        public List<MedicineDTO> GetAllMedicines()
        {
            using var db = new CMSDbContext();

            return db.Medicines
                .Select(m => new MedicineDTO
                {
                    MedicineID = m.MedicineId,
                    Name = m.Name,
                    Unit = m.Unit,
                    Price = m.Price ?? 0,
                    Stock = m.Stock ?? 0,
                    BatchNumber = m.BatchNumber ?? "",
                    ExpiryDate = m.ExpiryDate.HasValue
                        ? m.ExpiryDate.Value.ToDateTime(TimeOnly.MinValue)
                        : DateTime.MinValue
                })
                .ToList();
        }

        public bool InsertMedicine(MedicineDTO medicine)
        {
            using var db = new CMSDbContext();

            db.Medicines.Add(new Medicine
            {
                Name = medicine.Name,
                Unit = medicine.Unit,
                Price = medicine.Price,
                Stock = medicine.Stock,
                BatchNumber = medicine.BatchNumber,
                ExpiryDate = medicine.ExpiryDate == DateTime.MinValue
                    ? null
                    : DateOnly.FromDateTime(medicine.ExpiryDate)
            });

            return db.SaveChanges() > 0;
        }

        public bool UpdateMedicine(MedicineDTO medicine)
        {
            using var db = new CMSDbContext();

            var entity = db.Medicines
                .FirstOrDefault(x => x.MedicineId == medicine.MedicineID);

            if (entity == null)
                return false;

            entity.Name = medicine.Name;
            entity.Unit = medicine.Unit;
            entity.Price = medicine.Price;
            entity.Stock = medicine.Stock;
            entity.BatchNumber = medicine.BatchNumber;
            entity.ExpiryDate = medicine.ExpiryDate == DateTime.MinValue
                ? null
                : DateOnly.FromDateTime(medicine.ExpiryDate);

            return db.SaveChanges() > 0;
        }

        public bool UpdateStock(int medicineId, int qty)
        {
            using var db = new CMSDbContext();

            var medicine = db.Medicines
                .FirstOrDefault(x => x.MedicineId == medicineId);

            if (medicine == null)
                return false;

            medicine.Stock = (medicine.Stock ?? 0) - qty;

            return db.SaveChanges() > 0;
        }

        public bool AdjustStock(int medicineId, int quantityDelta)
        {
            using var db = new CMSDbContext();

            var medicine = db.Medicines
                .FirstOrDefault(x => x.MedicineId == medicineId);

            if (medicine == null)
                return false;

            int newStock = (medicine.Stock ?? 0) + quantityDelta;

            if (newStock < 0)
                return false;

            medicine.Stock = newStock;

            return db.SaveChanges() > 0;
        }

        public int GetStock(int medicineId)
        {
            using var db = new CMSDbContext();

            return db.Medicines
                .Where(x => x.MedicineId == medicineId)
                .Select(x => x.Stock ?? 0)
                .FirstOrDefault();
        }

        public bool DeleteMedicine(int id)
        {
            using var db = new CMSDbContext();

            var medicine = db.Medicines
                .FirstOrDefault(x => x.MedicineId == id);

            if (medicine == null)
                return false;

            db.Medicines.Remove(medicine);

            return db.SaveChanges() > 0;
        }
    }
}