using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class PaymentBUS
    {
        private readonly PaymentDAL paymentDAL =
            new();

        public List<PaymentWaitingDTO>
            GetWaitingPayments()
        {
            return paymentDAL
                .GetWaitingPayments();
        }

        public bool CreatePendingPayment(
            int encounterId,
            int patientId)
        {
            return paymentDAL
                .CreatePendingPayment(
                    encounterId,
                    patientId);
        }

        public bool UpdateAmount(
            int encounterId,
            decimal amount)
        {
            return paymentDAL
                .UpdateAmount(
                    encounterId,
                    amount);
        }

        public bool UpdatePaymentStatus(
            int encounterId,
            string method)
        {
            return paymentDAL
                .UpdatePaymentStatus(
                    encounterId,
                    method);
        }

        public List<PaymentDetailDTO>
            GetInvoiceDetails(
                int encounterId)
        {
            return paymentDAL
                .GetInvoiceDetails(
                    encounterId);
        }

        public List<PaymentDTO>
            GetPaymentHistory()
        {
            return paymentDAL
                .GetPaymentHistory();
        }

        public List<PaymentDTO>
    SearchPaymentHistory(
        string keyword)
        {
            return paymentDAL
                .SearchPaymentHistory(
                    keyword);
        }
    }
}