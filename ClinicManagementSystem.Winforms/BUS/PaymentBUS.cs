using DAL;

namespace BUS
{
    public class PaymentBUS
    {
        private PaymentDAL paymentDAL =
            new PaymentDAL();

        public bool ProcessCOD(
            Guid invoiceId)
        {
            return paymentDAL
                .UpdatePaymentStatus(
                    invoiceId,
                    "Paid",
                    "COD");
        }

        public bool ProcessMoMo(
            Guid invoiceId)
        {
            bool paymentSuccess = true;

            if (!paymentSuccess)
            {
                throw new Exception(
                    "MoMo payment failed.");
            }

            return paymentDAL
                .UpdatePaymentStatus(
                    invoiceId,
                    "Paid",
                    "MoMo");
        }
    }
}