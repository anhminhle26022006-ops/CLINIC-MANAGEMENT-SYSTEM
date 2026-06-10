using CMS.Core.Constants;
using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces.Technician;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Technician
{
    public class TechnicianRequestDAL : ITechnicianRequestDAL
    {
        public async Task<List<TechnicianRequestDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            var labs = await GetLabRequests(context);
            var imaging = await GetImagingRequests(context);
            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public async Task<List<TechnicianRequestDTO>> GetByStatus(string status)
        {
            using var context = DbContextProvider.CreateContext();
            var labs = await GetLabRequests(context, status: status);
            var imaging = await GetImagingRequests(context, status: status);
            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public async Task<List<TechnicianRequestDTO>> Search(string term, string status)
        {
            using var context = DbContextProvider.CreateContext();
            bool hasStatus = !string.IsNullOrWhiteSpace(status) && status != "Tất cả trạng thái";
            bool hasTerm = !string.IsNullOrWhiteSpace(term);

            var labs = await GetLabRequests(context,
                status: hasStatus ? status : null,
                term: hasTerm ? term : null);
            var imaging = await GetImagingRequests(context,
                status: hasStatus ? status : null,
                term: hasTerm ? term : null);

            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public async Task<List<TechnicianRequestDTO>> GetByPatient(int patientId)
        {
            using var context = DbContextProvider.CreateContext();
            var labs = await GetLabRequests(context, patientId: patientId);
            var imaging = await GetImagingRequests(context, patientId: patientId);
            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public async Task<bool> UpdateStatus(int requestId, string status)
        {
            using var context = DbContextProvider.CreateContext();
            var key = DecodeRequestKey(requestId);

            if (key.SourceTable == "ImagingRequests")
            {
                var entity = await context.ImagingRequests
                    .FirstOrDefaultAsync(r => r.ImagingRequestID == key.SourceID);
                if (entity == null) return false;
                entity.Status = status;
            }
            else
            {
                var entity = await context.LabRequests
                    .FirstOrDefaultAsync(r => r.LabID == key.SourceID);
                if (entity == null) return false;
                entity.Status = status;
            }

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveImagingResult(int requestId, string resultFile, string note)
        {
            var key = DecodeRequestKey(requestId);
            if (key.SourceTable != "ImagingRequests") return false;
            return await UpsertImagingResult(key.SourceID, resultFile, null, note);
        }

        public async Task<bool> SavePDFResult(int requestId, string resultPDF)
        {
            var key = DecodeRequestKey(requestId);
            if (key.SourceTable != "ImagingRequests") return false;
            return await UpsertImagingResult(key.SourceID, null, resultPDF, null);
        }

        public async Task<bool> SaveLabResult(int requestId, string labValues)
        {
            var key = DecodeRequestKey(requestId);
            if (key.SourceTable != "LabRequests") return false;

            using var context = DbContextProvider.CreateContext();
            var existing = await context.LabResults
                .FirstOrDefaultAsync(r => r.LabID == key.SourceID);

            if (existing != null)
            {
                existing.ResultText = labValues;
                existing.CompletedAt = DateTime.Now;
            }
            else
            {
                context.LabResults.Add(new LabResult
                {
                    LabID = key.SourceID,
                    ResultText = labValues,
                    CompletedAt = DateTime.Now
                });
            }

            bool saved = await context.SaveChangesAsync() > 0;
            if (!saved) return false;

            await UpdateStatus(requestId, "Hoàn thành");
            return true;
        }

        public async Task<bool> Add(TechnicianRequestDTO req)
        {
            using var context = DbContextProvider.CreateContext();
            string requestType = string.IsNullOrWhiteSpace(req.RequestType)
                ? InferRequestType(req.ServiceType)
                : req.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = await GetOrCreateImagingServiceId(context, req.ServiceType);
                context.ImagingRequests.Add(new ImagingRequest
                {
                    EncounterID = null,
                    DoctorID = req.RequestedByEmployeeID,
                    ImagingServiceID = serviceId,
                    BodyPart = req.RequestNote,
                    CreatedAt = req.RequestDate == default ? DateTime.Now : req.RequestDate,
                    Priority = req.Priority,
                    Status = string.IsNullOrWhiteSpace(req.Status) ? "Chờ xử lý" : req.Status
                });
            }
            else
            {
                context.LabRequests.Add(new LabRequest
                {
                    EncounterID = null,
                    DoctorID = req.RequestedByEmployeeID,
                    TestType = req.ServiceType,
                    Status = string.IsNullOrWhiteSpace(req.Status) ? "Chờ xử lý" : req.Status,
                    CreatedAt = req.RequestDate == default ? DateTime.Now : req.RequestDate
                });
            }

            return await context.SaveChangesAsync() > 0;
        }

        // ── Helpers ────────────────────────────────────────────────

        private static async Task<List<TechnicianRequestDTO>> GetLabRequests(
            AppDbContext context,
            string status = null,
            string term = null,
            int? patientId = null)
        {
            var query = context.LabRequests.AsQueryable();

            if (status != null)
                query = query.Where(lr => lr.Status == status);
            if (patientId != null)
                query = query.Where(lr => lr.Encounter != null && lr.Encounter.PatientID == patientId);
            if (term != null)
                query = query.Where(lr =>
                    (lr.Encounter != null && lr.Encounter.Patient.FullName.Contains(term)) ||
                    (lr.Encounter != null && lr.Encounter.Patient.PatientCode.Contains(term)) ||
                    lr.TestType.Contains(term) ||
                    lr.Doctor.FullName.Contains(term));

            return await query
                .Select(lr => new TechnicianRequestDTO
                {
                    RequestID = lr.LabID,
                    SourceID = lr.LabID,
                    SourceTable = "LabRequests",
                    RequestCode = "LAB-" + lr.LabID,
                    PatientID = lr.Encounter != null ? lr.Encounter.PatientID : 0,
                    PatientName = lr.Encounter != null ? lr.Encounter.Patient.FullName ?? "" : "",
                    PatientCode = lr.Encounter != null ? lr.Encounter.Patient.PatientCode ?? "" : "",
                    DoctorID = lr.DoctorID,
                    DoctorName = lr.Doctor.FullName ?? "",
                    AssignedToEmployeeID = null,
                    AssignedToEmployeeName = "",
                    ServiceType = lr.TestType ?? "",
                    RequestType = "Lab",
                    RequestNote = "",
                    Priority = "",
                    RequestDate = lr.CreatedAt,
                    Status = lr.Status ?? "",
                    ResultFile = "",
                    ResultPDF = lr.LabResult != null ? lr.LabResult.FileURL ?? "" : "",
                    LabValues = lr.LabResult != null ? lr.LabResult.ResultText ?? "" : ""
                })
                .ToListAsync();
        }

        private static async Task<List<TechnicianRequestDTO>> GetImagingRequests(
            AppDbContext context,
            string status = null,
            string term = null,
            int? patientId = null)
        {
            var query = context.ImagingRequests.AsQueryable();

            if (status != null)
                query = query.Where(ir => ir.Status == status);
            if (patientId != null)
                query = query.Where(ir => ir.Encounter != null && ir.Encounter.PatientID == patientId);
            if (term != null)
                query = query.Where(ir =>
                    (ir.Encounter != null && ir.Encounter.Patient.FullName.Contains(term)) ||
                    (ir.Encounter != null && ir.Encounter.Patient.PatientCode.Contains(term)) ||
                    ir.ImagingService.ServiceName.Contains(term) ||
                    ir.Doctor.FullName.Contains(term));

            return await query
                .Select(ir => new TechnicianRequestDTO
                {
                    RequestID = -ir.ImagingRequestID,
                    SourceID = ir.ImagingRequestID,
                    SourceTable = "ImagingRequests",
                    RequestCode = "IMG-" + ir.ImagingRequestID,
                    PatientID = ir.Encounter != null ? ir.Encounter.PatientID : 0,
                    PatientName = ir.Encounter != null ? ir.Encounter.Patient.FullName ?? "" : "",
                    PatientCode = ir.Encounter != null ? ir.Encounter.Patient.PatientCode ?? "" : "",
                    DoctorID = ir.DoctorID,
                    DoctorName = ir.Doctor.FullName ?? "",
                    AssignedToEmployeeID = null,
                    AssignedToEmployeeName = "",
                    ServiceType = ir.ImagingService.ServiceName ?? ir.ImagingService.Modality ?? ir.BodyPart ?? "Chẩn đoán hình ảnh",
                    RequestType = "Imaging",
                    RequestNote = ir.ImagingResult != null ? ir.ImagingResult.TechnicianNote ?? ir.BodyPart ?? "" : ir.BodyPart ?? "",
                    Priority = ir.Priority ?? "",
                    RequestDate = ir.CreatedAt,
                    Status = ir.Status ?? "",
                    ResultFile = ir.ImagingResult != null ? ir.ImagingResult.ImageURL ?? "" : "",
                    ResultPDF = ir.ImagingResult != null ? ir.ImagingResult.PDFURL ?? "" : "",
                    LabValues = ir.ImagingResult != null ? ir.ImagingResult.ResultText ?? "" : ""
                })
                .ToListAsync();
        }

        private static async Task<bool> UpsertImagingResult(
            int imagingRequestId, string imageUrl, string pdfUrl, string note)
        {
            using var context = DbContextProvider.CreateContext();
            var existing = await context.ImagingResults
                .FirstOrDefaultAsync(r => r.ImagingRequestID == imagingRequestId);

            if (existing != null)
            {
                if (imageUrl != null) existing.ImageURL = imageUrl;
                if (pdfUrl != null) existing.PDFURL = pdfUrl;
                if (note != null) existing.TechnicianNote = note;
                existing.CompletedAt = DateTime.Now;
            }
            else
            {
                context.ImagingResults.Add(new ImagingResult
                {
                    ImagingRequestID = imagingRequestId,
                    ImageURL = imageUrl,
                    PDFURL = pdfUrl,
                    TechnicianNote = note,
                    CompletedAt = DateTime.Now
                });
            }

            bool saved = await context.SaveChangesAsync() > 0;
            if (!saved) return false;

            var request = await context.ImagingRequests
                .FirstOrDefaultAsync(r => r.ImagingRequestID == imagingRequestId);
            if (request != null)
            {
                request.Status = "Hoàn thành";
                await context.SaveChangesAsync();
            }

            return true;
        }

        private static async Task<int> GetOrCreateImagingServiceId(AppDbContext context, string serviceName)
        {
            var existing = await context.ImagingServices
                .FirstOrDefaultAsync(s => s.ServiceName == serviceName);
            if (existing != null) return existing.ImagingServiceID;

            var newService = new ImagingService
            {
                ServiceName = serviceName,
                Modality = InferModality(serviceName),
                Price = 0,
                IsActive = true
            };
            context.ImagingServices.Add(newService);
            await context.SaveChangesAsync();
            return newService.ImagingServiceID;
        }

        private static RequestKey DecodeRequestKey(int requestId) =>
            requestId < 0
                ? new RequestKey("ImagingRequests", Math.Abs(requestId))
                : new RequestKey("LabRequests", requestId);

        private static string InferRequestType(string serviceType)
        {
            string value = (serviceType ?? "").ToLowerInvariant();
            if (value.Contains("mri") || value.Contains("x-quang") ||
                value.Contains("siêu âm") || value.Contains("sieu am"))
                return ServiceRequestType.Imaging;
            if (value.Contains("xét nghiệm") || value.Contains("xet nghiem") ||
                value.Contains("ecg") || value.Contains("điện tâm đồ"))
                return ServiceRequestType.Lab;
            return ServiceRequestType.Other;
        }

        private static string InferModality(string serviceType)
        {
            string value = (serviceType ?? "").ToLowerInvariant();
            if (value.Contains("mri")) return "MRI";
            if (value.Contains("x-quang") || value.Contains("xray") || value.Contains("x-ray")) return "X-Ray";
            if (value.Contains("siêu âm") || value.Contains("sieu am")) return "Ultrasound";
            return "Imaging";
        }

        private readonly struct RequestKey
        {
            public RequestKey(string sourceTable, int sourceID)
            {
                SourceTable = sourceTable;
                SourceID = sourceID;
            }
            public string SourceTable { get; }
            public int SourceID { get; }
        }
    }
}