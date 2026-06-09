using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class SupplierDAL
    {
        private static readonly List<SupplierDTO> _suppliers = new List<SupplierDTO>
        {
            new SupplierDTO 
            { 
                SupplierID = Guid.Parse("00000000-0000-0000-0000-000000000001"), 
                SupplierName = "Dược Hậu Giang", 
                Address = "Cần Thơ", 
                Phone = "02923891433",
                Email = "info@dhgpharma.com.vn"
            },
            new SupplierDTO 
            { 
                SupplierID = Guid.Parse("00000000-0000-0000-0000-000000000002"), 
                SupplierName = "Traphaco", 
                Address = "Hà Nội", 
                Phone = "02436811610",
                Email = "info@traphaco.com.vn"
            },
            new SupplierDTO 
            { 
                SupplierID = Guid.Parse("00000000-0000-0000-0000-000000000003"), 
                SupplierName = "Imexpharm", 
                Address = "Đồng Tháp", 
                Phone = "02773851941",
                Email = "imexpharm@imexpharm.com"
            }
        };

        public List<SupplierDTO> GetAllSuppliers()
        {
            return _suppliers.ToList();
        }

        public bool InsertSupplier(SupplierDTO supplier)
        {
            if (supplier.SupplierID == Guid.Empty)
            {
                supplier.SupplierID = Guid.NewGuid();
            }
            _suppliers.Add(supplier);
            return true;
        }

        public bool UpdateSupplier(SupplierDTO supplier)
        {
            var existing = _suppliers.FirstOrDefault(s => s.SupplierID == supplier.SupplierID);
            if (existing != null)
            {
                existing.SupplierName = supplier.SupplierName;
                existing.Phone = supplier.Phone;
                existing.Email = supplier.Email;
                existing.Address = supplier.Address;
                return true;
            }
            return false;
        }

        public bool DeleteSupplier(Guid supplierId)
        {
            var existing = _suppliers.FirstOrDefault(s => s.SupplierID == supplierId);
            if (existing != null)
            {
                _suppliers.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
