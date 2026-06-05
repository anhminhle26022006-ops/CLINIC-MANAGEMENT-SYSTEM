using DTO;
using DAL;

namespace BUS
{
    public class PrescriptionBUS
    {
        private PrescriptionDAL prescriptionDAL =
            new PrescriptionDAL();

        private MedicineDAL medicineDAL =
            new MedicineDAL();

        public List<PrescriptionDTO> GetPendingPrescriptions()
        {
            return prescriptionDAL.GetPendingPrescriptions();
        }

        public bool DispenseMedicine(
            Guid medicineId,
            int qtyDispensed
        )
        {
            int stock = medicineDAL.GetStock(medicineId);

            if (qtyDispensed > stock)
            {
                throw new Exception("Out of stock.");
            }

            return medicineDAL.UpdateStock(
                medicineId,
                qtyDispensed
            );
        }

        public bool CompletePrescription(Guid prescriptionId)
        {
            return prescriptionDAL.UpdatePrescriptionStatus(
                prescriptionId,
                "Completed"
            );
        }
    }
}