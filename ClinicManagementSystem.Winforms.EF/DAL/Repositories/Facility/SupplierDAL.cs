using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Admin
{
    public class SupplierDAL
    {
        public async Task<List<SupplierDTO>> GetAllSuppliers()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Suppliers
                .Select(s => new SupplierDTO
                {
                    SupplierID = s.SupplierID,
                    SupplierName = s.SupplierName ?? "",
                    Phone = s.Phone ?? "",
                    Email = s.Email ?? "",
                    Address = s.Address ?? ""
                })
                .ToListAsync();
        }

        public async Task<bool> InsertSupplier(SupplierDTO supplier)
        {
            using var context = DbContextProvider.CreateContext();
            context.Suppliers.Add(new Supplier
            {
                SupplierID = Guid.NewGuid(),
                SupplierName = supplier.SupplierName,
                Phone = supplier.Phone,
                Email = supplier.Email,
                Address = supplier.Address
            });
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSupplier(SupplierDTO supplier)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Suppliers
                .FirstOrDefaultAsync(s => s.SupplierID == supplier.SupplierID);

            if (entity == null) return false;

            entity.SupplierName = supplier.SupplierName;
            entity.Phone = supplier.Phone;
            entity.Email = supplier.Email;
            entity.Address = supplier.Address;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSupplier(Guid supplierId)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Suppliers
                .FirstOrDefaultAsync(s => s.SupplierID == supplierId);

            if (entity == null) return false;

            context.Suppliers.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}