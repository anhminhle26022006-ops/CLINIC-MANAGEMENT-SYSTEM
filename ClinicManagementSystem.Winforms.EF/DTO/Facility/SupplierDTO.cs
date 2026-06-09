using System;

namespace DTO
{
    public class SupplierDTO
    {
        public Guid SupplierID { get; set; }

        public string SupplierName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}