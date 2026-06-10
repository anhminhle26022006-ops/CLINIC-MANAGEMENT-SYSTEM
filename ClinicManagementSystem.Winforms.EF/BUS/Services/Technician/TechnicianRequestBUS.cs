using System;
using System.Collections.Generic;
using BUS.Interfaces;
using CMS.Core.Constants;
using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class TechnicianRequestBUS : ITechnicianRequestBUS
    {
        private readonly TechnicianRequestDAL dal;
        private readonly ServiceRequestBUS serviceRequestBUS;

        public TechnicianRequestBUS()
        {
            var context = new CMSDbContext();

            dal = new TechnicianRequestDAL(context);
            serviceRequestBUS = new ServiceRequestBUS(context);
        }


        public List<TechnicianRequestDTO> GetList()
        {
            return dal.GetAll();
        }

        public List<TechnicianRequestDTO> FilterList(string term, string status)
        {
            return dal.Search(term, status);
        }

        public List<TechnicianRequestDTO> GetRequestsByPatient(int patientId)
        {
            return dal.GetByPatient(patientId);
        }

        public bool StartProcessing(int requestId)
        {
            return dal.UpdateStatus(requestId, "Đang xử lý");
        }

        public bool SaveImagingResult(int requestId, string resultFile, string note)
        {
            if (string.IsNullOrWhiteSpace(resultFile))
            {
                throw new ArgumentException("File ảnh chẩn đoán không được để trống.");
            }
            return dal.SaveImagingResult(requestId, resultFile, note);
        }

        public bool SavePDFResult(int requestId, string resultPDF)
        {
            if (string.IsNullOrWhiteSpace(resultPDF))
            {
                throw new ArgumentException("File PDF báo cáo không được để trống.");
            }
            return dal.SavePDFResult(requestId, resultPDF);
        }

        public bool SaveLabResult(int requestId, string labValues)
        {
            if (string.IsNullOrWhiteSpace(labValues))
            {
                throw new ArgumentException("Kết quả xét nghiệm không được để trống.");
            }
            return dal.SaveLabResult(requestId, labValues);
        }

        public bool CreateRequest(TechnicianRequestDTO req)
        {
            if (req == null) return false;
            if (string.IsNullOrWhiteSpace(req.RequestCode) || req.PatientID <= 0 || req.DoctorID <= 0 || string.IsNullOrWhiteSpace(req.ServiceType))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(req.RequestType))
            {
                req.RequestType = InferRequestType(req.ServiceType);
            }
            if (req.RequestDate == default)
            {
                req.RequestDate = DateTime.Now;
            }
            if (string.IsNullOrWhiteSpace(req.Status))
            {
                req.Status = "Chờ xử lý";
            }
            return dal.Add(req);
        }

        public bool CreateServiceRequest(ServiceRequestDTO request)
        {
            return serviceRequestBUS.Create(request);
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
    }
}
