using System;
using System.Collections.Generic;
using DAL;
using DAL.Models;
using DTO;

namespace BUS
{
    public class PrescriptionBUS
    {
        private readonly PrescriptionDAL prescriptionDAL;
        private readonly MedicineDAL medicineDAL;

        public PrescriptionBUS(CMSDbContext context)
        {
            prescriptionDAL = new PrescriptionDAL();
            medicineDAL = new MedicineDAL(context);
        }

        public List<PrescriptionDTO> GetPendingPrescriptions()
        {
            return prescriptionDAL.GetPendingPrescriptions();
        }

        public bool DispenseMedicine(int medicineId, int qtyDispensed)
        {
            int stock = medicineDAL.GetStock(medicineId);
            if (qtyDispensed > stock)
            {
                throw new InvalidOperationException("Không đủ thuốc trong kho.");
            }

            return medicineDAL.UpdateStock(medicineId, qtyDispensed);
        }

        public bool CompletePrescription(int prescriptionId)
        {
            return prescriptionDAL.UpdatePrescriptionStatus(prescriptionId, "Completed");
        }

        public void ValidateStock(List<PrescriptionItemDTO> items)
        {
            if (items == null) return;
            foreach (var item in items)
            {
                int stock = medicineDAL.GetStock(item.MedicineID);
                if (item.Quantity > stock)
                {
                    throw new InvalidOperationException($"Thuốc '{item.MedicineName}' không đủ tồn kho.\n(Yêu cầu: {item.Quantity}, Hiện có: {stock})");
                }
            }
        }
    }
}