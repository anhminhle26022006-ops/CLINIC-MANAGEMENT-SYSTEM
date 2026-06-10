using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DTO;

namespace DAL
{
    public class MedicineDAL
    {
        private readonly CMSDbContext _context;

        public MedicineDAL(CMSDbContext context)
        {
            _context = context;
        }

        public List<MedicineDTO> GetAllMedicines()
        {
            return _context.Medicines
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
            _context.Medicines.Add(new Medicine
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

            return _context.SaveChanges() > 0;
        }

        public bool UpdateMedicine(MedicineDTO medicine)
        {
            var entity = _context.Medicines
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

            return _context.SaveChanges() > 0;
        }

        public bool UpdateStock(int medicineId, int qty)
        {
            var medicine = _context.Medicines
                .FirstOrDefault(x => x.MedicineId == medicineId);

            if (medicine == null)
                return false;

            medicine.Stock = (medicine.Stock ?? 0) - qty;

            return _context.SaveChanges() > 0;
        }

        public bool AdjustStock(int medicineId, int quantityDelta)
        {
            var medicine = _context.Medicines
                .FirstOrDefault(x => x.MedicineId == medicineId);

            if (medicine == null)
                return false;

            int newStock = (medicine.Stock ?? 0) + quantityDelta;

            if (newStock < 0)
                return false;

            medicine.Stock = newStock;

            return _context.SaveChanges() > 0;
        }

        public int GetStock(int medicineId)
        {
            return _context.Medicines
                .Where(x => x.MedicineId == medicineId)
                .Select(x => x.Stock ?? 0)
                .FirstOrDefault();
        }

        public bool DeleteMedicine(int id)
        {
            var medicine = _context.Medicines
                .FirstOrDefault(x => x.MedicineId == id);

            if (medicine == null)
                return false;

            _context.Medicines.Remove(medicine);

            return _context.SaveChanges() > 0;
        }
    }
}