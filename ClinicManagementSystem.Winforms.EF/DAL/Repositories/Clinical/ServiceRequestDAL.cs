using System;
using System.Collections.Generic;
using System.Data;
using CMS.Core.Constants;
using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class ServiceRequestDAL : IServiceRequestDAL
    {
        private readonly CMSDbContext _context;
        private const string LabSource = "LabRequests";
        private const string ImagingSource = "ImagingRequests";

        public ServiceRequestDAL(CMSDbContext context)
        {
            _context = context;
        }

        public List<ServiceRequestDTO> GetAll()
        {
            var labs = _context.LabRequests
                .Select(lr => new ServiceRequestDTO
                {
                    RequestID = lr.LabId,
                    SourceID = lr.LabId,
                    SourceTable = "LabRequests",
                    RequestCode = $"LAB-{lr.LabId}",

                    PatientID = lr.Encounter.PatientId ?? 0,
                    PatientName = lr.Encounter.Patient.FullName,
                    PatientCode = lr.Encounter.Patient.PatientCode,

                    RequestedByEmployeeID = lr.DoctorId ?? 0,
                    RequestedByEmployeeName = lr.Doctor.FullName,

                    ServiceType = lr.TestType,
                    RequestType = "Lab",

                    RequestNote = "",
                    Priority = "",

                    RequestedAt = lr.CreatedAt ?? DateTime.MinValue,
                    Status = lr.Status,

                    ResultFile = "",
                    ResultPDF = lr.LabResults
                        .Select(x => x.FileUrl)
                        .FirstOrDefault(),

                    LabValues = lr.LabResults
                        .Select(x => x.ResultText)
                        .FirstOrDefault()
                });

            var imaging = _context.ImagingRequests
                .Select(ir => new ServiceRequestDTO
                {
                    RequestID = -ir.ImagingRequestId,
                    SourceID = ir.ImagingRequestId,
                    SourceTable = "ImagingRequests",
                    RequestCode = $"IMG-{ir.ImagingRequestId}",

                    PatientID = ir.Encounter.PatientId ?? 0,
                    PatientName = ir.Encounter.Patient.FullName,
                    PatientCode = ir.Encounter.Patient.PatientCode,

                    RequestedByEmployeeID = ir.DoctorId ?? 0,
                    RequestedByEmployeeName = ir.Doctor.FullName,

                    ServiceType = ir.ImagingService.ServiceName,
                    RequestType = "Imaging",

                    RequestNote = ir.BodyPart,
                    Priority = ir.Priority,

                    RequestedAt = ir.CreatedAt ?? DateTime.MinValue,
                    Status = ir.Status,

                    ResultFile = ir.ImagingResults
                        .Select(x => x.ImageUrl)
                        .FirstOrDefault(),

                    ResultPDF = ir.ImagingResults
                        .Select(x => x.Pdfurl)
                        .FirstOrDefault(),

                    LabValues = ir.ImagingResults
                        .Select(x => x.ResultText)
                        .FirstOrDefault()
                });

            return labs
                .Union(imaging)
                .OrderByDescending(x => x.RequestedAt)
                .ToList();
        }

        public List<ServiceRequestDTO> GetByStatus(string status)
        {
            return GetAll()
                .Where(x => x.Status == status)
                .ToList();
        }

        public List<ServiceRequestDTO> GetByRequester(int employeeId)
        {
            return GetAll()
                .Where(x => x.RequestedByEmployeeID == employeeId)
                .ToList();
        }

        public bool Add(ServiceRequestDTO request)
        {
            string requestType = string.IsNullOrWhiteSpace(request.RequestType)
                ? InferRequestType(request.ServiceType)
                : request.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = GetOrCreateImagingServiceId(request.ServiceType);

                var imagingRequest = new ImagingRequest
                {
                    EncounterId = null,
                    DoctorId = request.RequestedByEmployeeID,
                    ImagingServiceId = serviceId,
                    BodyPart = request.RequestNote,
                    CreatedAt = request.RequestedAt == default
                        ? DateTime.Now
                        : request.RequestedAt,
                    Priority = request.Priority,
                    Status = string.IsNullOrWhiteSpace(request.Status)
                        ? "Chờ xử lý"
                        : request.Status,
                    ImagingRequestUuid = Guid.NewGuid()
                };

                _context.ImagingRequests.Add(imagingRequest);

                return _context.SaveChanges() > 0;
            }

            var labRequest = new LabRequest
            {
                EncounterId = null,
                DoctorId = request.RequestedByEmployeeID,
                TestType = request.ServiceType,
                Status = string.IsNullOrWhiteSpace(request.Status)
                    ? "Chờ xử lý"
                    : request.Status,
                CreatedAt = request.RequestedAt == default
                    ? DateTime.Now
                    : request.RequestedAt,
                LabRequestUuid = Guid.NewGuid()
            };

            _context.LabRequests.Add(labRequest);

            return _context.SaveChanges() > 0;
        }
        public bool UpdateStatus(int requestId, string status)
        {
            if (requestId < 0)
            {
                var imaging = _context.ImagingRequests
                    .FirstOrDefault(x => x.ImagingRequestId == Math.Abs(requestId));

                if (imaging == null)
                    return false;

                imaging.Status = status;
            }
            else
            {
                var lab = _context.LabRequests
                    .FirstOrDefault(x => x.LabId == requestId);

                if (lab == null)
                    return false;

                lab.Status = status;
            }

            return _context.SaveChanges() > 0;
        }

        private int GetOrCreateImagingServiceId(string serviceName)
        {
            var service = _context.ImagingServices
                .FirstOrDefault(x => x.ServiceName == serviceName);

            if (service != null)
                return service.ImagingServiceId;

            service = new ImagingService
            {
                ServiceName = serviceName,
                Modality = InferModality(serviceName),
                Price = 0,
                IsActive = true
            };

            _context.ImagingServices.Add(service);
            _context.SaveChanges();

            return service.ImagingServiceId;
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
