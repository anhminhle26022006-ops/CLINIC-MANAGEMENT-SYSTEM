using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Controllers
{
    public class PaymentController
    {
        private readonly PaymentBUS paymentBUS =
            new();

        public List<PaymentWaitingDTO>
            GetWaitingPayments()
        {
            return paymentBUS
                .GetWaitingPayments();
        }

        public bool CreatePendingPayment(
            int encounterId,
            int patientId)
        {
            return paymentBUS
                .CreatePendingPayment(
                    encounterId,
                    patientId);
        }

        public bool UpdateAmount(
            int encounterId,
            decimal amount)
        {
            return paymentBUS
                .UpdateAmount(
                    encounterId,
                    amount);
        }

        public bool UpdatePaymentStatus(
            int encounterId,
            string method)
        {
            return paymentBUS
                .UpdatePaymentStatus(
                    encounterId,
                    method);
        }

        public List<PaymentDetailDTO>
            GetInvoiceDetails(
                int encounterId)
        {
            return paymentBUS
                .GetInvoiceDetails(
                    encounterId);
        }

        public List<Payment_RecepDTO>
            GetPaymentHistory()
        {
            return paymentBUS
                .GetPaymentHistory();
        }

        public List<Payment_RecepDTO>
    SearchPaymentHistory(
        string keyword)
        {
            return paymentBUS
                .SearchPaymentHistory(
                    keyword);
        }
    }
}