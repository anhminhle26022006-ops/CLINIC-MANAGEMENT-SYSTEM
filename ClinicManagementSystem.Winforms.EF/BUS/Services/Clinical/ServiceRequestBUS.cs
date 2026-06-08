using System;
using System.Collections.Generic;
using BUS.Interfaces;
using CMS.Core.Constants;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class ServiceRequestBUS : IServiceRequestBUS
    {
        private readonly ServiceRequestDAL dal = new ServiceRequestDAL();
        private readonly EmployeeDAL employeeDal = new EmployeeDAL();

        public List<ServiceRequestDTO> GetAll()
        {
            return dal.GetAll();
        }

        public List<ServiceRequestDTO> GetByStatus(string status)
        {
            return string.IsNullOrWhiteSpace(status)
                ? GetAll()
                : dal.GetByStatus(status.Trim());
        }

        public List<ServiceRequestDTO> GetByRequester(int employeeId)
        {
            return employeeId <= 0 ? new List<ServiceRequestDTO>() : dal.GetByRequester(employeeId);
        }

        public bool Create(ServiceRequestDTO request)
        {
            ValidateForCreate(request);

            if (string.IsNullOrWhiteSpace(request.RequestType))
            {
                request.RequestType = InferRequestType(request.ServiceType);
            }

            if (request.RequestedAt == default)
            {
                request.RequestedAt = DateTime.Now;
            }

            if (string.IsNullOrWhiteSpace(request.Status))
            {
                request.Status = "Chờ xử lý";
            }

            return dal.Add(request);
        }

        public bool UpdateStatus(int requestId, string status)
        {
            if (requestId == 0 || string.IsNullOrWhiteSpace(status))
            {
                return false;
            }

            return dal.UpdateStatus(requestId, status.Trim());
        }

        private void ValidateForCreate(ServiceRequestDTO request)
        {
            if (request == null)
            {
                throw new ArgumentException("Yêu cầu dịch vụ không hợp lệ.");
            }

            if (string.IsNullOrWhiteSpace(request.RequestCode))
            {
                throw new ArgumentException("Mã yêu cầu không được để trống.");
            }

            if (request.PatientID <= 0)
            {
                throw new ArgumentException("Bệnh nhân không hợp lệ.");
            }

            if (request.RequestedByEmployeeID <= 0 || !employeeDal.Exists(request.RequestedByEmployeeID))
            {
                throw new ArgumentException("Người tạo yêu cầu không tồn tại trong Employees.");
            }

            if (string.IsNullOrWhiteSpace(request.ServiceType))
            {
                throw new ArgumentException("Dịch vụ yêu cầu không được để trống.");
            }
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
