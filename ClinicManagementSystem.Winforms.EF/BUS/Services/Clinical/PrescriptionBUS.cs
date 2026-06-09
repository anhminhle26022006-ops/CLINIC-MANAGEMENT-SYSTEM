using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BUS
{
    public class PrescriptionBUS
    {
        private readonly PrescriptionDAL prescriptionDAL = new PrescriptionDAL();
        private readonly MedicineDAL medicineDAL = new MedicineDAL();

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
    }
}