using CMS.Core.Constants;
using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces.Clinical;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class ServiceRequestDAL : IServiceRequestDAL
    {
        public async Task<List<ServiceRequestDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            var labs = await GetLabRequests(context);
            var imaging = await GetImagingRequests(context);
            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestedAt)
                .ToList();
        }

        public async Task<List<ServiceRequestDTO>> GetByStatus(string status)
        {
            using var context = DbContextProvider.CreateContext();
            var labs = await GetLabRequests(context, status: status);
            var imaging = await GetImagingRequests(context, status: status);
            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestedAt)
                .ToList();
        }

        public async Task<List<ServiceRequestDTO>> GetByRequester(int employeeId)
        {
            using var context = DbContextProvider.CreateContext();
            var labs = await GetLabRequests(context, employeeId: employeeId);
            var imaging = await GetImagingRequests(context, employeeId: employeeId);
            return labs.Concat(imaging)
                .OrderByDescending(r => r.RequestedAt)
                .ToList();
        }

        public async Task<bool> Add(ServiceRequestDTO request)
        {
            using var context = DbContextProvider.CreateContext();

            string requestType = string.IsNullOrWhiteSpace(request.RequestType)
                ? InferRequestType(request.ServiceType)
                : request.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = await GetOrCreateImagingServiceId(context, request.ServiceType);
                context.ImagingRequests.Add(new ImagingRequest
                {
                    EncounterID = null,
                    DoctorID = request.RequestedByEmployeeID,
                    ImagingServiceID = serviceId,
                    BodyPart = request.RequestNote,
                    CreatedAt = request.RequestedAt == default ? DateTime.Now : request.RequestedAt,
                    Priority = request.Priority,
                    Status = string.IsNullOrWhiteSpace(request.Status) ? "Chờ xử lý" : request.Status
                });
            }
            else
            {
                context.LabRequests.Add(new LabRequest
                {
                    EncounterID = null,
                    DoctorID = request.RequestedByEmployeeID,
                    TestType = request.ServiceType,
                    Status = string.IsNullOrWhiteSpace(request.Status) ? "Chờ xử lý" : request.Status,
                    CreatedAt = request.RequestedAt == default ? DateTime.Now : request.RequestedAt
                });
            }

            return await context.SaveChangesAsync() > 0;
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

        // ── Helpers ────────────────────────────────────────────────

        private static async Task<List<ServiceRequestDTO>> GetLabRequests(
            AppDbContext context,
            string status = null,
            int? employeeId = null)
        {
            var query = context.LabRequests.AsQueryable();

            if (status != null)
                query = query.Where(lr => lr.Status == status);
            if (employeeId != null)
                query = query.Where(lr => lr.DoctorID == employeeId);

            return await query.Select(lr => new ServiceRequestDTO
            {
                RequestID = lr.LabID,
                SourceID = lr.LabID,
                SourceTable = "LabRequests",
                RequestCode = "LAB-" + lr.LabID,
                PatientID = lr.Encounter != null ? lr.Encounter.PatientID : 0,
                PatientName = lr.Encounter != null ? lr.Encounter.Patient.FullName ?? "" : "",
                PatientCode = lr.Encounter != null ? lr.Encounter.Patient.PatientCode ?? "" : "",
                RequestedByEmployeeID = lr.DoctorID,
                RequestedByEmployeeName = lr.Doctor.FullName ?? "",
                AssignedToEmployeeID = null,
                AssignedToEmployeeName = "",
                ServiceType = lr.TestType ?? "",
                RequestType = "Lab",
                RequestNote = "",
                Priority = "",
                RequestedAt = lr.CreatedAt,
                Status = lr.Status ?? "",
                ResultFile = "",
                ResultPDF = lr.LabResult != null ? lr.LabResult.FileURL ?? "" : "",
                LabValues = lr.LabResult != null ? lr.LabResult.ResultText ?? "" : ""
            }).ToListAsync();
        }

        private static async Task<List<ServiceRequestDTO>> GetImagingRequests(
            AppDbContext context,
            string status = null,
            int? employeeId = null)
        {
            var query = context.ImagingRequests.AsQueryable();

            if (status != null)
                query = query.Where(ir => ir.Status == status);
            if (employeeId != null)
                query = query.Where(ir => ir.DoctorID == employeeId);

            return await query.Select(ir => new ServiceRequestDTO
            {
                RequestID = -ir.ImagingRequestID,
                SourceID = ir.ImagingRequestID,
                SourceTable = "ImagingRequests",
                RequestCode = "IMG-" + ir.ImagingRequestID,
                PatientID = ir.Encounter != null ? ir.Encounter.PatientID : 0,
                PatientName = ir.Encounter != null ? ir.Encounter.Patient.FullName ?? "" : "",
                PatientCode = ir.Encounter != null ? ir.Encounter.Patient.PatientCode ?? "" : "",
                RequestedByEmployeeID = ir.DoctorID,
                RequestedByEmployeeName = ir.Doctor.FullName ?? "",
                AssignedToEmployeeID = null,
                AssignedToEmployeeName = "",
                ServiceType = ir.ImagingService.ServiceName ?? ir.ImagingService.Modality ?? ir.BodyPart ?? "Chẩn đoán hình ảnh",
                RequestType = "Imaging",
                RequestNote = ir.ImagingResult != null ? ir.ImagingResult.TechnicianNote ?? ir.BodyPart ?? "" : ir.BodyPart ?? "",
                Priority = ir.Priority ?? "",
                RequestedAt = ir.CreatedAt,
                Status = ir.Status ?? "",
                ResultFile = ir.ImagingResult != null ? ir.ImagingResult.ImageURL ?? "" : "",
                ResultPDF = ir.ImagingResult != null ? ir.ImagingResult.PDFURL ?? "" : "",
                LabValues = ir.ImagingResult != null ? ir.ImagingResult.ResultText ?? "" : ""
            }).ToListAsync();
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