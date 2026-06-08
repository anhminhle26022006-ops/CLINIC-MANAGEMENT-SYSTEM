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
    public class ServiceRequestDAL : IServiceRequestDAL
    {
        private const string LabSource = "LabRequests";
        private const string ImagingSource = "ImagingRequests";

        public List<ServiceRequestDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildRequests(context)
                .OrderByDescending(r => r.RequestedAt)
                .ToList();
        }

        public List<ServiceRequestDTO> GetByStatus(string status)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildRequests(context)
                .Where(r => r.Status == status)
                .OrderByDescending(r => r.RequestedAt)
                .ToList();
        }

        public List<ServiceRequestDTO> GetByRequester(int employeeId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return BuildRequests(context)
                .Where(r => r.RequestedByEmployeeID == employeeId)
                .OrderByDescending(r => r.RequestedAt)
                .ToList();
        }

        public bool Add(ServiceRequestDTO request)
        {
            using ClinicDbContext context = new ClinicDbContext();
            string requestType = string.IsNullOrWhiteSpace(request.RequestType)
                ? InferRequestType(request.ServiceType)
                : request.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = GetOrCreateImagingServiceId(context, request.ServiceType);
                context.ImagingRequests.Add(new ImagingRequest
                {
                    ImagingRequestUUID = Guid.NewGuid(),
                    DoctorID = request.RequestedByEmployeeID,
                    ImagingServiceID = serviceId,
                    BodyPart = request.RequestNote,
                    CreatedAt = request.RequestedAt == default ? DateTime.Now : request.RequestedAt,
                    Priority = request.Priority,
                    Status = string.IsNullOrWhiteSpace(request.Status) ? "Chờ xử lý" : request.Status
                });
                return context.SaveChanges() > 0;
            }

            context.LabRequests.Add(new LabRequest
            {
                LabRequestUUID = Guid.NewGuid(),
                DoctorID = request.RequestedByEmployeeID,
                TestType = request.ServiceType,
                Status = string.IsNullOrWhiteSpace(request.Status) ? "Chờ xử lý" : request.Status,
                CreatedAt = request.RequestedAt == default ? DateTime.Now : request.RequestedAt
            });
            return context.SaveChanges() > 0;
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

        private static List<ServiceRequestDTO> BuildRequests(ClinicDbContext context)
        {
            List<ServiceRequestDTO> labRequests = (
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
                select new ServiceRequestDTO
                {
                    RequestID = lab.LabID,
                    SourceID = lab.LabID,
                    SourceTable = LabSource,
                    RequestCode = "LAB-" + lab.LabID,
                    PatientID = encounter != null && encounter.PatientID.HasValue ? encounter.PatientID.Value : 0,
                    PatientName = patient != null ? patient.FullName : "",
                    PatientCode = patient != null ? patient.PatientCode : "",
                    RequestedByEmployeeID = lab.DoctorID ?? 0,
                    RequestedByEmployeeName = employee != null ? employee.FullName : "",
                    AssignedToEmployeeID = null,
                    AssignedToEmployeeName = "",
                    ServiceType = lab.TestType,
                    RequestType = ServiceRequestType.Lab,
                    RequestNote = "",
                    Priority = "",
                    RequestedAt = lab.CreatedAt,
                    Status = lab.Status ?? "",
                    ResultFile = "",
                    ResultPDF = result != null ? result.FileURL : "",
                    LabValues = result != null ? result.ResultText : ""
                }).ToList();

            List<ServiceRequestDTO> imagingRequests = (
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
                select new ServiceRequestDTO
                {
                    RequestID = -imaging.ImagingRequestID,
                    SourceID = imaging.ImagingRequestID,
                    SourceTable = ImagingSource,
                    RequestCode = "IMG-" + imaging.ImagingRequestID,
                    PatientID = encounter != null && encounter.PatientID.HasValue ? encounter.PatientID.Value : 0,
                    PatientName = patient != null ? patient.FullName : "",
                    PatientCode = patient != null ? patient.PatientCode : "",
                    RequestedByEmployeeID = imaging.DoctorID ?? 0,
                    RequestedByEmployeeName = employee != null ? employee.FullName : "",
                    AssignedToEmployeeID = null,
                    AssignedToEmployeeName = "",
                    ServiceType = service != null
                        ? (service.ServiceName ?? service.Modality ?? imaging.BodyPart ?? "Chẩn đoán hình ảnh")
                        : (imaging.BodyPart ?? "Chẩn đoán hình ảnh"),
                    RequestType = ServiceRequestType.Imaging,
                    RequestNote = result != null ? (result.TechnicianNote ?? imaging.BodyPart ?? "") : (imaging.BodyPart ?? ""),
                    Priority = imaging.Priority ?? "",
                    RequestedAt = imaging.CreatedAt,
                    Status = imaging.Status ?? "",
                    ResultFile = result != null ? result.ImageURL : "",
                    ResultPDF = result != null ? result.PDFURL : "",
                    LabValues = result != null ? result.ResultText : ""
                }).ToList();

            return labRequests.Concat(imagingRequests).ToList();
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
