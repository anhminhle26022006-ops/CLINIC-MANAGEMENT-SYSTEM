using DTO;
using DAL;

namespace BUS
{
    public class SupplierBUS
    {
        private SupplierDAL supplierDAL =
            new SupplierDAL();

        public List<SupplierDTO> GetAllSuppliers()
        {
            return supplierDAL.GetAllSuppliers();
        }

        public bool AddSupplier(SupplierDTO supplier)
        {
            ValidateSupplier(supplier);

            return supplierDAL.InsertSupplier(supplier);
        }

        public bool UpdateSupplier(SupplierDTO supplier)
        {
            ValidateSupplier(supplier);

            return supplierDAL.UpdateSupplier(supplier);
        }

        public bool DeleteSupplier(Guid supplierId)
        {
            return supplierDAL.DeleteSupplier(supplierId);
        }

        private void ValidateSupplier(SupplierDTO supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
            {
                throw new Exception(
                    "Supplier name is required."
                );
            }

            if (string.IsNullOrWhiteSpace(supplier.Phone))
            {
                throw new Exception(
                    "Phone number is required."
                );
            }

            if (!supplier.Email.Contains("@"))
            {
                throw new Exception(
                    "Invalid email."
                );
            }
        }
    }
}