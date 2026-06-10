using DAL.DataContext;
using DAL.Interfaces.Clinical;
using DTO.Clinical.erm;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DAL.DataContext;
using DAL.Interfaces.ERM;
using DAL.Models;
using DTO.Clinical.erm;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.ERM
{
    public class ErmRepository : IERMRepository
    {
        private readonly CMSDbContext _context;

        public ErmRepository(CMSDbContext context)
        {
            _context = context;
        }

        public async Task<PatientERMDto> GetPatientERM(Guid patientUUID)
        {
            // Sử dụng Eager Loading (.Include) tối ưu hóa truy vấn để tránh N+1
            var patient = await _context.Patients
                .Include(x => x.PatientInsurances)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.Doctor)
                        .ThenInclude(d => d.Department)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.MedicalRecords)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.VitalSigns)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.Prescriptions)
                        .ThenInclude(p => p.Doctor)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.Prescriptions)
                        .ThenInclude(p => p.PrescriptionDetails)
                            .ThenInclude(pd => pd.Medicine)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.LabRequests)
                        .ThenInclude(l => l.Doctor)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.LabRequests)
                        .ThenInclude(l => l.LabResults)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.ImagingRequests)
                        .ThenInclude(i => i.Doctor)
                .Include(x => x.Encounters)
                    .ThenInclude(i => i.ImagingRequests)
                        .ThenInclude(i => i.ImagingService)
                .Include(x => x.Encounters)
                    .ThenInclude(i => i.ImagingRequests)
                        .ThenInclude(i => i.ImagingResults)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.Invoices)
                        .ThenInclude(iv => iv.InvoiceDetails)
                            .ThenInclude(ivd => ivd.Service)
                .Include(x => x.Encounters)
                    .ThenInclude(e => e.FollowUps)
                .FirstOrDefaultAsync(x => x.PatientUuid == patientUUID);

            if (patient == null)
                return null;

            // Gom cụm danh sách EncounterId để nạp dữ liệu bảng Payments trong một truy vấn phụ duy nhất
            var encounterIds = patient.Encounters.Select(e => e.EncounterId).ToList();
            var payments = await _context.Payments
                .Where(p => encounterIds.Contains(p.EncounterId ?? 0))
                .ToListAsync();

            var patientDto = new PatientERMDto
            {
                PatientUUID = patient.PatientUuid,
                PatientCode = patient.PatientCode,
                FullName = patient.FullName,
                Gender = patient.Gender,

                // Xử lý chuyển đổi kiểu DateOnly từ model Patient sang DateTime
                DOB = patient.Dob?.ToDateTime(TimeOnly.MinValue) ?? DateTime.Today,

                Phone = patient.Phone,
                Address = patient.Address,
                BloodType = patient.BloodType,
                Allergy = patient.Allergy,

                InsuranceNumber = patient.PatientInsurances
                    .Select(x => x.InsuranceNumber)
                    .FirstOrDefault(),

                Email = string.Empty,
                EmergencyContact = patient.Phone,

                Encounters = new(),
                Prescriptions = new(),
                LabResults = new(),
                ImagingResults = new(),
                Invoices = new(),
                FollowUps = new()
            };

            foreach (var encounter in patient.Encounters.OrderByDescending(x => x.StartTime))
            {
                var record = encounter.MedicalRecords
                    .OrderByDescending(x => x.CreatedAt)
                    .FirstOrDefault();

                var paymentMethod = payments
                    .Where(p => p.EncounterId == encounter.EncounterId)
                    .Select(p => p.Method)
                    .FirstOrDefault();

                var dto = new EncounterHistoryDto
                {
                    EncounterId = encounter.EncounterId,
                    EncounterUUID = encounter.EncounterUuid,
                    VisitDate = encounter.StartTime ?? DateTime.Today,

                    DoctorName = encounter.Doctor?.FullName,
                    DepartmentName = encounter.Doctor?.Department?.DepartmentName,

                    Symptoms = record?.Symptoms,
                    Diagnosis = record?.Diagnosis,
                    Conclusion = record?.Conclusion,

                    // Thực hiện In-Memory Mapping từ dữ liệu đã nạp sẵn trong bộ nhớ RAM
                    VitalSigns = MapVitalSigns(encounter),
                    Prescriptions = MapPrescriptions(encounter),
                    LabResults = MapLabs(encounter),
                    ImagingResults = MapImaging(encounter, patient.FullName),
                    Invoices = MapInvoices(encounter, paymentMethod),
                    FollowUps = MapFollowUps(encounter)
                };

                patientDto.Encounters.Add(dto);

                patientDto.Prescriptions.AddRange(dto.Prescriptions);
                patientDto.LabResults.AddRange(dto.LabResults);
                patientDto.ImagingResults.AddRange(dto.ImagingResults);
                patientDto.Invoices.AddRange(dto.Invoices);
                patientDto.FollowUps.AddRange(dto.FollowUps);
            }

            return patientDto;
        }

        #region EF Core In-Memory Mappers

        private PrescriptionItemDto MapPrescriptionItem(PrescriptionDetail d)
        {
            return new PrescriptionItemDto
            {
                MedicineName = d.Medicine?.Name,
                Dosage = d.Dosage,
                Frequency = d.Frequency,
                Quantity = d.Quantity ?? 0,
                Instruction = d.Instruction
            };
        }

        private List<PrescriptionHistoryDto> MapPrescriptions(Encounter encounter)
        {
            return encounter.Prescriptions
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new PrescriptionHistoryDto
                {
                    PrescriptionUUID = x.PrescriptionUuid,
                    PrescriptionCode = $"DT-{x.PrescriptionId:D5}",
                    CreatedAt = x.CreatedAt ?? DateTime.Today,
                    DoctorName = x.Doctor?.FullName,
                    Medicines = x.PrescriptionDetails.Select(MapPrescriptionItem).ToList()
                })
                .ToList();
        }

        private List<LabHistoryDto> MapLabs(Encounter encounter)
        {
            return encounter.LabRequests
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new LabHistoryDto
                {
                    LabRequestUUID = x.LabRequestUuid,
                    TestType = x.TestType,
                    CreatedAt = x.CreatedAt ?? DateTime.Today,
                    DoctorName = x.Doctor?.FullName,
                    Status = x.Status,

                    FileUrl = x.LabResults
                        .Select(r => r.FileUrl)
                        .FirstOrDefault(),

                    ResultItems = new List<LabResultItemDto>()
                })
                .ToList();
        }

        private List<ImagingHistoryDto> MapImaging(
    Encounter encounter,
    string patientName)
        {
            return encounter.ImagingRequests
                .OrderByDescending(x => x.CreatedAt)
                .Select(x =>
                {
                    var result = x.ImagingResults.FirstOrDefault();

                    return new ImagingHistoryDto
                    {
                        ImagingRequestUUID = x.ImagingRequestUuid,

                        Modality = x.ImagingService != null
                            ? x.ImagingService.ServiceName
                            : string.Empty,

                        BodyPart = x.BodyPart,

                        DoctorName = x.Doctor != null
                            ? x.Doctor.FullName
                            : string.Empty,

                        PatientName = patientName,

                        CreatedAt = x.CreatedAt ?? DateTime.Today,

                        Conclusion = result != null
                            ? result.ResultText
                            : string.Empty,

                        ImageUrl = result != null
                            ? result.ImageUrl
                            : string.Empty,

                        PdfUrl = result != null
                            ? result.Pdfurl
                            : string.Empty
                    };
                })
                .ToList();
        }

        private List<InvoiceHistoryDto> MapInvoices(
    Encounter encounter,
    string paymentMethod)
        {
            return encounter.Invoices
                .OrderByDescending(x => x.CreatedAt)
                .Select(x => new InvoiceHistoryDto
                {
                    InvoiceUUID = x.InvoiceUuid,

                    InvoiceDate = x.CreatedAt ?? DateTime.Today,

                    TotalAmount = x.Total ?? 0,

                    Status = x.Status,

                    PaymentMethod = paymentMethod,

                    Services = new List<ServiceItemDto>()
                })
                .ToList();
        }

        private List<FollowUpHistoryDto> MapFollowUps(
    Encounter encounter)
        {
            return encounter.FollowUps
                .OrderByDescending(x => x.FollowUpDate)
                .Select(x => new FollowUpHistoryDto
                {
                    FollowUpUUID = x.FollowUpUuid,
                    FollowUpDate = x.FollowUpDate ?? DateTime.Today,
                    Status = x.Status
                })
                .ToList();
        }

        private VitalSignDto MapVitalSigns(Encounter encounter)
        {
            var vital = encounter.VitalSigns
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();

            if (vital == null)
                return null;

            return new VitalSignDto
            {
                BloodPressure = vital.BloodPressure,
                Temperature = vital.Temperature ?? 0,
                HeartRate = vital.HeartRate ?? 0,
                Height = vital.Height ?? 0,
                Weight = vital.Weight ?? 0
            };
        }
        #endregion
    }
}