using System;
using System.Collections.Generic;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class RequestBUS
    {
        private readonly RequestDAL dal = new RequestDAL();

        public List<RequestDTO> GetList()
        {
            return dal.GetAll();
        }

        public List<RequestDTO> FilterList(string term, string status)
        {
            return dal.Search(term, status);
        }

        public List<RequestDTO> GetRequestsByPatient(int patientId)
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

        public bool CreateRequest(RequestDTO req)
        {
            if (req == null) return false;
            if (string.IsNullOrWhiteSpace(req.RequestCode) || req.PatientID <= 0 || req.DoctorID <= 0 || string.IsNullOrWhiteSpace(req.ServiceType))
            {
                return false;
            }
            return dal.Add(req);
        }
    }
}

