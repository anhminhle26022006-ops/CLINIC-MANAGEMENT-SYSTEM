using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class MedicineDAL
    {
        public List<MedicineDTO> GetAllMedicines()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Medicines
                    .AsNoTracking()
                    .Select(m => new MedicineDTO
                    {
                        MedicineID = m.MedicineID,
                        Name = m.Name,
                        Unit = m.Unit,
                        Price = m.Price ?? 0,
                        Stock = m.Stock ?? 0,
                        BatchNumber = m.BatchNumber ?? "",
                        ExpiryDate = m.ExpiryDate ?? DateTime.MinValue
                    })
                    .ToList();
            }
        }

        public bool InsertMedicine(MedicineDTO medicine)
        {
            using (var context = new ClinicDbContext())
            {
                var newMed = new Medicine
                {
                    Name = medicine.Name,
                    Unit = medicine.Unit,
                    Price = medicine.Price,
                    Stock = medicine.Stock,
                    BatchNumber = medicine.BatchNumber,
                    ExpiryDate = medicine.ExpiryDate == DateTime.MinValue ? (DateTime?)null : medicine.ExpiryDate
                };

                context.Medicines.Add(newMed);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateStock(int medicineId, int qty)
        {
            using (var context = new ClinicDbContext())
            {
                var med = context.Medicines.Find(medicineId);
                if (med != null)
                {
                    med.Stock = (med.Stock ?? 0) - qty;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public int GetStock(int medicineId)
        {
            using (var context = new ClinicDbContext())
            {
                var med = context.Medicines.Find(medicineId);
                return med?.Stock ?? 0;
            }
        }
    }
}
