using System;
using System.Collections.Generic;
using System.Linq;
using CMS.Core.Constants;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class TechnicianRequestDAL : ITechnicianRequestDAL
    {
        private const string LabSource = "LabRequests";
        private const string ImagingSource = "ImagingRequests";

        public List<TechnicianRequestDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildRequests(context)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public List<TechnicianRequestDTO> GetByStatus(string status)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildRequests(context)
                .Where(r => r.Status == status)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public List<TechnicianRequestDTO> Search(string term, string status)
        {
            using ClinicDbContext context = new ClinicDbContext();
            IEnumerable<TechnicianRequestDTO> query = BuildRequests(context);

            if (!string.IsNullOrWhiteSpace(status) && status != "Tất cả trạng thái")
            {
                query = query.Where(r => r.Status == status);
            }

            if (!string.IsNullOrWhiteSpace(term))
            {
                string value = term.Trim();
                query = query.Where(r =>
                    Contains(r.PatientName, value)
                    || Contains(r.PatientCode, value)
                    || Contains(r.ServiceType, value)
                    || Contains(r.DoctorName, value));
            }

            return query
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public List<TechnicianRequestDTO> GetByPatient(int patientId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildRequests(context)
                .Where(r => r.PatientID == patientId)
                .OrderByDescending(r => r.RequestDate)
                .ToList();
        }

        public bool UpdateStatus(int requestId, string status)
        {
            using ClinicDbContext context = new ClinicDbContext();
            RequestKey key = DecodeRequestKey(requestId);

            if (key.SourceTable == ImagingSource)
            {
                ImagingRequest request = context.ImagingRequests.FirstOrDefault(r => r.ImagingRequestID == key.SourceID);
                if (request == null)
                {
                    return false;
                }

                request.Status = status;
                return context.SaveChanges() > 0;
            }

            LabRequest labRequest = context.LabRequests.FirstOrDefault(r => r.LabID == key.SourceID);
            if (labRequest == null)
            {
                return false;
            }

            labRequest.Status = status;
            return context.SaveChanges() > 0;
        }

        public bool SaveImagingResult(int requestId, string resultFile, string note)
        {
            RequestKey key = DecodeRequestKey(requestId);
            return key.SourceTable == ImagingSource
                && UpsertImagingResult(key.SourceID, resultFile, null, note);
        }

        public bool SavePDFResult(int requestId, string resultPDF)
        {
            RequestKey key = DecodeRequestKey(requestId);
            return key.SourceTable == ImagingSource
                && UpsertImagingResult(key.SourceID, null, resultPDF, null);
        }

        public bool SaveLabResult(int requestId, string labValues)
        {
            RequestKey key = DecodeRequestKey(requestId);
            if (key.SourceTable != LabSource)
            {
                return false;
            }

            using ClinicDbContext context = new ClinicDbContext();
            LabResult result = context.LabResults.FirstOrDefault(r => r.LabID == key.SourceID);
            if (result == null)
            {
                context.LabResults.Add(new LabResult
                {
                    LabID = key.SourceID,
                    ResultText = labValues,
                    CompletedAt = DateTime.Now
                });
            }
            else
            {
                result.ResultText = labValues;
                result.CompletedAt = DateTime.Now;
            }

            LabRequest request = context.LabRequests.FirstOrDefault(r => r.LabID == key.SourceID);
            if (request != null)
            {
                request.Status = "Hoàn thành";
            }

            return context.SaveChanges() > 0;
        }

        public bool Add(TechnicianRequestDTO req)
        {
            using ClinicDbContext context = new ClinicDbContext();
            string requestType = string.IsNullOrWhiteSpace(req.RequestType)
                ? InferRequestType(req.ServiceType)
                : req.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = GetOrCreateImagingServiceId(context, req.ServiceType);
                context.ImagingRequests.Add(new ImagingRequest
                {
                    ImagingRequestUUID = Guid.NewGuid(),
                    DoctorID = req.RequestedByEmployeeID,
                    ImagingServiceID = serviceId,
                    BodyPart = req.RequestNote,
                    CreatedAt = req.RequestDate == default ? DateTime.Now : req.RequestDate,
                    Priority = req.Priority,
                    Status = string.IsNullOrWhiteSpace(req.Status) ? "Chờ xử lý" : req.Status
                });
                return context.SaveChanges() > 0;
            }

            context.LabRequests.Add(new LabRequest
            {
                LabRequestUUID = Guid.NewGuid(),
                DoctorID = req.RequestedByEmployeeID,
                TestType = req.ServiceType,
                Status = string.IsNullOrWhiteSpace(req.Status) ? "Chờ xử lý" : req.Status,
                CreatedAt = req.RequestDate == default ? DateTime.Now : req.RequestDate
            });
            return context.SaveChanges() > 0;
        }

        private static List<TechnicianRequestDTO> BuildRequests(ClinicDbContext context)
        {
            List<TechnicianRequestDTO> labRequests = (
                from lab in context.LabRequests.AsNoTracking()
                join encounter in context.Encounters.AsNoTracking()
                    on lab.EncounterID equals encounter.EncounterID into encounters
                from encounter in encounters.DefaultIfEmpty()
                join patient in context.Patients.AsNoTracking()
                    on encounter.PatientID equals patient.PatientID into patients
                from patient in patients.DefaultIfEmpty()
                join employee in context.Employees.AsNoTracking()
                    on lab.DoctorID equals employee.EmployeeID into employees
                from employee in employees.DefaultIfEmpty()
                join result in context.LabResults.AsNoTracking()
                    on lab.LabID equals result.LabID into results
                from result in results.DefaultIfEmpty()
                select new TechnicianRequestDTO
                {
                    RequestID = lab.LabID,
                    SourceID = lab.LabID,
                    SourceTable = LabSource,
                    RequestCode = "LAB-" + lab.LabID,
                    PatientID = encounter != null && encounter.PatientID.HasValue ? encounter.PatientID.Value : 0,
                    DoctorID = lab.DoctorID ?? 0,
                    AssignedToEmployeeID = null,
                    ServiceType = lab.TestType,
                    RequestType = ServiceRequestType.Lab,
                    RequestNote = "",
                    Priority = "",
                    RequestDate = lab.CreatedAt,
                    Status = lab.Status ?? "",
                    ResultFile = "",
                    ResultPDF = result != null ? result.FileURL : "",
                    LabValues = result != null ? result.ResultText : "",
                    PatientName = patient != null ? patient.FullName : "",
                    PatientCode = patient != null ? patient.PatientCode : "",
                    DoctorName = employee != null ? employee.FullName : "",
                    AssignedToEmployeeName = ""
                }).ToList();

            List<TechnicianRequestDTO> imagingRequests = (
                from imaging in context.ImagingRequests.AsNoTracking()
                join encounter in context.Encounters.AsNoTracking()
                    on imaging.EncounterID equals encounter.EncounterID into encounters
                from encounter in encounters.DefaultIfEmpty()
                join patient in context.Patients.AsNoTracking()
                    on encounter.PatientID equals patient.PatientID into patients
                from patient in patients.DefaultIfEmpty()
                join employee in context.Employees.AsNoTracking()
                    on imaging.DoctorID equals employee.EmployeeID into employees
                from employee in employees.DefaultIfEmpty()
                join service in context.ImagingServices.AsNoTracking()
                    on imaging.ImagingServiceID equals service.ImagingServiceID into services
                from service in services.DefaultIfEmpty()
                join result in context.ImagingResults.AsNoTracking()
                    on imaging.ImagingRequestID equals result.ImagingRequestID into results
                from result in results.DefaultIfEmpty()
                select new TechnicianRequestDTO
                {
                    RequestID = -imaging.ImagingRequestID,
                    SourceID = imaging.ImagingRequestID,
                    SourceTable = ImagingSource,
                    RequestCode = "IMG-" + imaging.ImagingRequestID,
                    PatientID = encounter != null && encounter.PatientID.HasValue ? encounter.PatientID.Value : 0,
                    DoctorID = imaging.DoctorID ?? 0,
                    AssignedToEmployeeID = null,
                    ServiceType = service != null
                        ? (service.ServiceName ?? service.Modality ?? imaging.BodyPart ?? "Chẩn đoán hình ảnh")
                        : (imaging.BodyPart ?? "Chẩn đoán hình ảnh"),
                    RequestType = ServiceRequestType.Imaging,
                    RequestNote = result != null ? (result.TechnicianNote ?? imaging.BodyPart ?? "") : (imaging.BodyPart ?? ""),
                    Priority = imaging.Priority ?? "",
                    RequestDate = imaging.CreatedAt,
                    Status = imaging.Status ?? "",
                    ResultFile = result != null ? result.ImageURL : "",
                    ResultPDF = result != null ? result.PDFURL : "",
                    LabValues = result != null ? result.ResultText : "",
                    PatientName = patient != null ? patient.FullName : "",
                    PatientCode = patient != null ? patient.PatientCode : "",
                    DoctorName = employee != null ? employee.FullName : "",
                    AssignedToEmployeeName = ""
                }).ToList();

            return labRequests.Concat(imagingRequests).ToList();
        }

        private static bool UpsertImagingResult(int imagingRequestId, string imageUrl, string pdfUrl, string note)
        {
            using ClinicDbContext context = new ClinicDbContext();
            ImagingResult result = context.ImagingResults.FirstOrDefault(r => r.ImagingRequestID == imagingRequestId);

            if (result == null)
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
            else
            {
                if (imageUrl != null)
                {
                    result.ImageURL = imageUrl;
                }

                if (pdfUrl != null)
                {
                    result.PDFURL = pdfUrl;
                }

                if (note != null)
                {
                    result.TechnicianNote = note;
                }

                result.CompletedAt = DateTime.Now;
            }

            ImagingRequest request = context.ImagingRequests.FirstOrDefault(r => r.ImagingRequestID == imagingRequestId);
            if (request != null)
            {
                request.Status = "Hoàn thành";
            }

            return context.SaveChanges() > 0;
        }

        private static int GetOrCreateImagingServiceId(ClinicDbContext context, string serviceName)
        {
            serviceName = string.IsNullOrWhiteSpace(serviceName) ? "Chẩn đoán hình ảnh" : serviceName.Trim();
            ImagingService existing = context.ImagingServices.FirstOrDefault(s => s.ServiceName == serviceName);
            if (existing != null)
            {
                return existing.ImagingServiceID;
            }

            ImagingService service = new ImagingService
            {
                ServiceName = serviceName,
                Modality = InferModality(serviceName),
                Price = 0,
                IsActive = true
            };
            context.ImagingServices.Add(service);
            context.SaveChanges();
            return service.ImagingServiceID;
        }

        private static bool Contains(string source, string value)
        {
            return (source ?? "").IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static RequestKey DecodeRequestKey(int requestId)
        {
            return requestId < 0
                ? new RequestKey(ImagingSource, Math.Abs(requestId))
                : new RequestKey(LabSource, requestId);
        }

        private static string InferRequestType(string serviceType)
        {
            string value = (serviceType ?? "").ToLowerInvariant();
            if (value.Contains("mri") || value.Contains("x-quang") || value.Contains("siêu âm") || value.Contains("sieu am"))
            {
                return ServiceRequestType.Imaging;
            }

            if (value.Contains("xét nghiệm") || value.Contains("xet nghiem") || value.Contains("ecg") || value.Contains("điện tâm đồ"))
            {
                return ServiceRequestType.Lab;
            }

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
