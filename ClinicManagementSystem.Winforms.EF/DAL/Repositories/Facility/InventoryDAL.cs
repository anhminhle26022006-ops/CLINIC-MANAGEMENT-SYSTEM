using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Admin
{
    public class InventoryDAL
    {
        public async Task<List<MedicineDTO>> GetAllMedicines()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Medicines
                .Select(m => new MedicineDTO
                {
                    MedicineID = m.MedicineID,
                    Name = m.Name ?? "",
                    Stock = m.Stock,
                    Price = m.Price,
                    Unit = m.Unit ?? "",
                    BatchNumber = m.BatchNumber ?? "",
                    ExpiryDate = m.ExpiryDate ?? DateTime.MinValue
                })
                .ToListAsync();
        }
    }
}