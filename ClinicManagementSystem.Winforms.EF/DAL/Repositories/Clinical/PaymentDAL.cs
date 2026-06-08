using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PaymentDAL
    {
        public List<PaymentWaitingDTO> GetWaitingPayments()
        {
            using (var context = new ClinicDbContext())
            {
                var query = from pa in context.Payments
                            join e in context.Encounters on pa.EncounterID equals e.EncounterID
                            join p in context.Patients on pa.PatientID equals p.PatientID
                            join d in context.Employees on e.DoctorID equals d.EmployeeID
                            where pa.Status == "Pending"
                            select new PaymentWaitingDTO
                            {
                                EncounterID = pa.EncounterID ?? 0,
                                PatientID = p.PatientID,
                                PatientCode = p.PatientCode ?? "",
                                PatientName = p.FullName ?? "",
                                DoctorName = d.FullName ?? "",
                                Status = pa.Status ?? "",
                                TotalAmount = pa.Amount ?? 0
                            };
                return query.AsNoTracking().ToList();
            }
        }

        public bool CreatePendingPayment(int encounterId, int patientId)
        {
            using (var context = new ClinicDbContext())
            {
                var payment = new Payment
                {
                    PaymentUUID = Guid.NewGuid(),
                    EncounterID = encounterId,
                    PatientID = patientId,
                    Amount = 0,
                    Method = "",
                    Status = "Pending",
                    CreatedAt = DateTime.Now
                };
                context.Payments.Add(payment);
                return context.SaveChanges() > 0;
            }
        }

        public bool UpdateAmount(int encounterId, decimal amount)
        {
            using (var context = new ClinicDbContext())
            {
                var payment = context.Payments.FirstOrDefault(p => p.EncounterID == encounterId);
                if (payment != null)
                {
                    payment.Amount = amount;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public bool UpdatePaymentStatus(int encounterId, string method)
        {
            using (var context = new ClinicDbContext())
            {
                var payment = context.Payments.FirstOrDefault(p => p.EncounterID == encounterId);
                if (payment != null)
                {
                    payment.Status = "Paid";
                    payment.Method = method;
                    payment.PaidAt = DateTime.Now;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        public List<PaymentDetailDTO> GetInvoiceDetails(int encounterId)
        {
            using (var context = new ClinicDbContext())
            {
                var query = from es in context.EncounterServices
                            join s in context.ClinicalServices on es.ServiceID equals s.ServiceID
                            where es.EncounterID == encounterId
                            select new PaymentDetailDTO
                            {
                                ItemType = "Service",
                                Description = s.ServiceName ?? "",
                                Quantity = es.Quantity,
                                UnitPrice = es.UnitPrice ?? 0,
                                Amount = es.Quantity * (es.UnitPrice ?? 0)
                            };
                return query.AsNoTracking().ToList();
            }
        }

        public List<Payment_RecepDTO> GetPaymentHistory()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Payments
                    .AsNoTracking()
                    .Where(p => p.Status == "Paid")
                    .OrderByDescending(p => p.PaidAt)
                    .Select(p => new Payment_RecepDTO
                    {
                        PaymentID = p.PaymentID,
                        EncounterID = p.EncounterID ?? 0,
                        PatientID = p.PatientID ?? 0,
                        Amount = p.Amount ?? 0,
                        Method = p.Method ?? "",
                        Status = p.Status ?? "",
                        PaidAt = p.PaidAt ?? DateTime.MinValue
                    })
                    .ToList();
            }
        }

        public List<Payment_RecepDTO> SearchPaymentHistory(string keyword)
        {
            using (var context = new ClinicDbContext())
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return GetPaymentHistory();

                keyword = keyword.Trim();
                
                var list = context.Payments
                    .AsNoTracking()
                    .Where(p => p.Status == "Paid")
                    .OrderByDescending(p => p.PaidAt)
                    .ToList();

                return list
                    .Where(p => p.PaymentID.ToString().Contains(keyword)
                             || (p.EncounterID?.ToString().Contains(keyword) ?? false)
                             || (p.PatientID?.ToString().Contains(keyword) ?? false))
                    .Select(p => new Payment_RecepDTO
                    {
                        PaymentID = p.PaymentID,
                        EncounterID = p.EncounterID ?? 0,
                        PatientID = p.PatientID ?? 0,
                        Amount = p.Amount ?? 0,
                        Method = p.Method ?? "",
                        Status = p.Status ?? "",
                        PaidAt = p.PaidAt ?? DateTime.MinValue
                    })
                    .ToList();
            }
        }
    }
}
