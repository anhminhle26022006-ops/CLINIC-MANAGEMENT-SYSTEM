using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Admin
{
    public class MedicineDAL
    {
        public async Task<List<MedicineDTO>> GetAllMedicines()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Medicines
                .Select(m => new MedicineDTO
                {
                    MedicineID = m.MedicineID,
                    Name = m.Name,
                    Unit = m.Unit,
                    Price = m.Price,
                    Stock = m.Stock,
                    BatchNumber = m.BatchNumber ?? "",
                    ExpiryDate = m.ExpiryDate ?? DateTime.MinValue
                })
                .ToListAsync();
        }

        public async Task<bool> InsertMedicine(MedicineDTO medicine)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = new Medicine
            {
                Name = medicine.Name,
                Unit = medicine.Unit,
                Price = medicine.Price,
                Stock = medicine.Stock,
                BatchNumber = medicine.BatchNumber,
                ExpiryDate = medicine.ExpiryDate == DateTime.MinValue ? null : medicine.ExpiryDate
            };
            context.Medicines.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateMedicine(MedicineDTO medicine)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == medicine.MedicineID);

            if (entity == null) return false;

            entity.Name = medicine.Name;
            entity.Unit = medicine.Unit;
            entity.Price = medicine.Price;
            entity.Stock = medicine.Stock;
            entity.BatchNumber = string.IsNullOrWhiteSpace(medicine.BatchNumber) ? null : medicine.BatchNumber;
            entity.ExpiryDate = medicine.ExpiryDate == DateTime.MinValue ? null : medicine.ExpiryDate;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int medicineId, int qty)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == medicineId);

            if (entity == null) return false;

            entity.Stock -= qty;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AdjustStock(int medicineId, int quantityDelta)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == medicineId
                                       && m.Stock + quantityDelta >= 0);

            if (entity == null) return false;

            entity.Stock += quantityDelta;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetStock(int medicineId)
        {
            using var context = DbContextProvider.CreateContext();
            var medicine = await context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == medicineId);

            return medicine?.Stock ?? 0;
        }

        public async Task<bool> DeleteMedicine(int id)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID == id);

            if (entity == null) return false;

            context.Medicines.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}