using DAL;

namespace BUS
{
    public class PaymentBUS
    {
        private PaymentDAL paymentDAL = new PaymentDAL();

        public bool ProcessCOD(Guid prescriptionId)
        {
            return paymentDAL.UpdatePaymentStatus(
                prescriptionId,
                "Paid",
                "COD"
            );
        }

        public bool ProcessMoMo(Guid prescriptionId)
        {
            // mock payment success

            bool paymentSuccess = true;

            if (!paymentSuccess)
            {
                throw new Exception("MoMo payment failed.");
            }

            return paymentDAL.UpdatePaymentStatus(
                prescriptionId,
                "Paid",
                "MoMo"
            );
        }
    }
}