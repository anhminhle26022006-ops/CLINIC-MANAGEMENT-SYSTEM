using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class PaymentDAL
    {
        private static readonly string[] PendingStatuses = { "Pending", "Unpaid", "Chưa thanh toán" };

        public async Task<List<PaymentWaitingDTO>> GetWaitingPayments()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Payments
                .Where(pa => PendingStatuses.Contains(pa.Status))
                .OrderByDescending(pa => pa.PaymentID)
                .Select(pa => new PaymentWaitingDTO
                {
                    EncounterID = pa.EncounterID,
                    PatientID = pa.PatientID,
                    PatientCode = pa.Encounter.Patient.PatientCode ?? "",
                    PatientName = pa.Encounter.Patient.FullName ?? "",
                    DoctorName = pa.Encounter.Doctor.FullName ?? "",
                    Status = pa.Status ?? "",
                    TotalAmount = pa.Amount
                })
                .ToListAsync();
        }

        public async Task<bool> CreatePendingPayment(int encounterId, int patientId)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = new Payment
            {
                EncounterID = encounterId,
                PatientID = patientId,
                Amount = 0,
                Method = "",
                Status = "Pending"
            };
            context.Payments.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAmount(int encounterId, decimal amount)
        {
            using var context = DbContextProvider.CreateContext();
            var payment = await context.Payments
                .FirstOrDefaultAsync(p => p.EncounterID == encounterId);

            if (payment == null) return false;

            payment.Amount = amount;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePaymentStatus(int encounterId, string method)
        {
            using var context = DbContextProvider.CreateContext();
            var payment = await context.Payments
                .FirstOrDefaultAsync(p => p.EncounterID == encounterId);

            if (payment == null) return false;

            payment.Status = "Paid";
            payment.Method = method;
            payment.PaidAt = DateTime.Now;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<PaymentDetailDTO>> GetInvoiceDetails(int encounterId)
        {
            using var context = DbContextProvider.CreateContext();

            // Thử lấy PaymentDetails trước
            var paymentDetails = await context.Payments
                .Where(p => p.EncounterID == encounterId)
                .SelectMany(p => p.Details.Select(pd => new PaymentDetailDTO
                {
                    ItemType = pd.ItemType ?? "Payment",
                    PatientName = p.Encounter.Patient.FullName ?? "",
                    Description = pd.Description ?? "",
                    Quantity = pd.Quantity ?? 1,
                    UnitPrice = pd.UnitPrice ?? pd.Amount,
                    Amount = pd.Amount
                }))
                .ToListAsync();

            if (paymentDetails.Count > 0) return paymentDetails;

            // Fallback: EncounterServices
            var serviceDetails = await context.EncounterServices
                .Where(es => es.EncounterID == encounterId)
                .Select(es => new PaymentDetailDTO
                {
                    ItemType = "Service",
                    PatientName = es.Encounter.Patient.FullName ?? "",
                    Description = es.Service.ServiceName ?? "",
                    Quantity = es.Quantity ?? 1,
                    UnitPrice = es.UnitPrice ?? 0,
                    Amount = (es.Quantity ?? 1) * (es.UnitPrice ?? 0)
                })
                .ToListAsync();

            if (serviceDetails.Count > 0) return serviceDetails;

            // Fallback: Payment amount
            var fallback = await context.Payments
                .Where(p => p.EncounterID == encounterId && p.Amount > 0)
                .Select(p => new PaymentDetailDTO
                {
                    ItemType = "Payment",
                    PatientName = p.Encounter.Patient.FullName ?? "",
                    Description = "Chi phí khám và dịch vụ",
                    Quantity = 1,
                    UnitPrice = p.Amount,
                    Amount = p.Amount
                })
                .ToListAsync();

            return fallback;
        }

        public async Task<List<Payment_RecepDTO>> GetPaymentHistory()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Payments
                .Where(p => p.Status == "Paid")
                .OrderByDescending(p => p.PaidAt)
                .Select(p => new Payment_RecepDTO
                {
                    PaymentID = p.PaymentID,
                    EncounterID = p.EncounterID,
                    PatientID = p.PatientID,
                    PatientName = p.Encounter.Patient.FullName ?? "",
                    Amount = p.Amount,
                    Method = p.Method ?? "",
                    Status = p.Status ?? "",
                    PaidAt = p.PaidAt ?? DateTime.MinValue
                })
                .ToListAsync();
        }

        public async Task<List<Payment_RecepDTO>> SearchPaymentHistory(string keyword)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Payments
                .Where(p => p.Status == "Paid"
                         && (p.Encounter.Patient.FullName.Contains(keyword)
                          || p.PaymentID.ToString().Contains(keyword)
                          || p.EncounterID.ToString().Contains(keyword)))
                .OrderByDescending(p => p.PaidAt)
                .Select(p => new Payment_RecepDTO
                {
                    PaymentID = p.PaymentID,
                    EncounterID = p.EncounterID,
                    PatientID = p.PatientID,
                    PatientName = p.Encounter.Patient.FullName ?? "",
                    Amount = p.Amount,
                    Method = p.Method ?? "",
                    Status = p.Status ?? "",
                    PaidAt = p.PaidAt ?? DateTime.MinValue
                })
                .ToListAsync();
        }
    }
}