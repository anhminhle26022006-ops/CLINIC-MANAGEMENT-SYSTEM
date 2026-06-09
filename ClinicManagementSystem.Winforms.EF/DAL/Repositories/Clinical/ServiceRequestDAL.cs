using System;
using System.Collections.Generic;
using System.Data;
using CMS.Core.Constants;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class ServiceRequestDAL : IServiceRequestDAL
    {
        private const string LabSource = "LabRequests";
        private const string ImagingSource = "ImagingRequests";

        public List<ServiceRequestDTO> GetAll()
        {
            return Map(DatabaseHelper.ExecuteQuery(GetBaseSelect() + " ORDER BY RequestedAt DESC"));
        }

        public List<ServiceRequestDTO> GetByStatus(string status)
        {
            string query = GetBaseSelect() + " WHERE Status = @Status ORDER BY RequestedAt DESC";
            return Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@Status", status)
            }));
        }

        public List<ServiceRequestDTO> GetByRequester(int employeeId)
        {
            string query = GetBaseSelect() + " WHERE RequestedByEmployeeID = @EmployeeID ORDER BY RequestedAt DESC";
            return Map(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@EmployeeID", employeeId)
            }));
        }

        public bool Add(ServiceRequestDTO request)
        {
            string requestType = string.IsNullOrWhiteSpace(request.RequestType)
                ? InferRequestType(request.ServiceType)
                : request.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = GetOrCreateImagingServiceId(request.ServiceType);
                string query = @"
                    INSERT INTO ImagingRequests (EncounterID, DoctorID, ImagingServiceID, BodyPart, CreatedAt, Priority, Status)
                    VALUES (NULL, @DoctorID, @ImagingServiceID, @BodyPart, @CreatedAt, @Priority, @Status)";
                return DatabaseHelper.ExecuteNonQuery(query, new[]
                {
                    new SqlParameter("@DoctorID", request.RequestedByEmployeeID),
                    new SqlParameter("@ImagingServiceID", serviceId),
                    new SqlParameter("@BodyPart", (object)request.RequestNote ?? DBNull.Value),
                    new SqlParameter("@CreatedAt", request.RequestedAt == default ? DateTime.Now : request.RequestedAt),
                    new SqlParameter("@Priority", (object)request.Priority ?? DBNull.Value),
                    new SqlParameter("@Status", string.IsNullOrWhiteSpace(request.Status) ? "Chờ xử lý" : request.Status)
                }) > 0;
            }

            string labQuery = @"
                INSERT INTO LabRequests (EncounterID, DoctorID, TestType, Status, CreatedAt)
                VALUES (NULL, @DoctorID, @TestType, @Status, @CreatedAt)";
            return DatabaseHelper.ExecuteNonQuery(labQuery, new[]
            {
                new SqlParameter("@DoctorID", request.RequestedByEmployeeID),
                new SqlParameter("@TestType", request.ServiceType),
                new SqlParameter("@Status", string.IsNullOrWhiteSpace(request.Status) ? "Chờ xử lý" : request.Status),
                new SqlParameter("@CreatedAt", request.RequestedAt == default ? DateTime.Now : request.RequestedAt)
            }) > 0;
        }

        public bool UpdateStatus(int requestId, string status)
        {
            RequestKey key = DecodeRequestKey(requestId);
            string table = key.SourceTable == ImagingSource ? "ImagingRequests" : "LabRequests";
            string idColumn = key.SourceTable == ImagingSource ? "ImagingRequestID" : "LabID";
            string query = $"UPDATE {table} SET Status = @Status WHERE {idColumn} = @SourceID";
            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@SourceID", key.SourceID)
            }) > 0;
        }

        private static string GetBaseSelect()
        {
            return @"
                SELECT *
                FROM (
                    SELECT
                        lr.LabID AS SourceID,
                        'LabRequests' AS SourceTable,
                        lr.LabID AS RequestID,
                        CONCAT('LAB-', lr.LabID) AS RequestCode,
                        en.PatientID,
                        ISNULL(p.FullName, '') AS PatientName,
                        ISNULL(p.PatientCode, '') AS PatientCode,
                        lr.DoctorID AS RequestedByEmployeeID,
                        ISNULL(e.FullName, '') AS RequestedByEmployeeName,
                        CAST(NULL AS int) AS AssignedToEmployeeID,
                        CAST('' AS nvarchar(255)) AS AssignedToEmployeeName,
                        lr.TestType AS ServiceType,
                        'Lab' AS RequestType,
                        CAST('' AS nvarchar(max)) AS RequestNote,
                        CAST('' AS nvarchar(50)) AS Priority,
                        lr.CreatedAt AS RequestedAt,
                        lr.Status,
                        CAST('' AS nvarchar(max)) AS ResultFile,
                        ISNULL(lres.FileURL, '') AS ResultPDF,
                        ISNULL(lres.ResultText, '') AS LabValues
                    FROM LabRequests lr
                    LEFT JOIN Encounters en ON lr.EncounterID = en.EncounterID
                    LEFT JOIN Patients p ON en.PatientID = p.PatientID
                    LEFT JOIN Employees e ON lr.DoctorID = e.EmployeeID
                    LEFT JOIN LabResults lres ON lr.LabID = lres.LabID

                    UNION ALL

                    SELECT
                        ir.ImagingRequestID AS SourceID,
                        'ImagingRequests' AS SourceTable,
                        -ir.ImagingRequestID AS RequestID,
                        CONCAT('IMG-', ir.ImagingRequestID) AS RequestCode,
                        en.PatientID,
                        ISNULL(p.FullName, '') AS PatientName,
                        ISNULL(p.PatientCode, '') AS PatientCode,
                        ir.DoctorID AS RequestedByEmployeeID,
                        ISNULL(e.FullName, '') AS RequestedByEmployeeName,
                        CAST(NULL AS int) AS AssignedToEmployeeID,
                        CAST('' AS nvarchar(255)) AS AssignedToEmployeeName,
                        COALESCE(s.ServiceName, s.Modality, ir.BodyPart, N'Chẩn đoán hình ảnh') AS ServiceType,
                        'Imaging' AS RequestType,
                        ISNULL(ires.TechnicianNote, ir.BodyPart) AS RequestNote,
                        ISNULL(ir.Priority, '') AS Priority,
                        ir.CreatedAt AS RequestedAt,
                        ir.Status,
                        ISNULL(ires.ImageURL, '') AS ResultFile,
                        ISNULL(ires.PDFURL, '') AS ResultPDF,
                        ISNULL(ires.ResultText, '') AS LabValues
                    FROM ImagingRequests ir
                    LEFT JOIN Encounters en ON ir.EncounterID = en.EncounterID
                    LEFT JOIN Patients p ON en.PatientID = p.PatientID
                    LEFT JOIN Employees e ON ir.DoctorID = e.EmployeeID
                    LEFT JOIN ImagingServices s ON ir.ImagingServiceID = s.ImagingServiceID
                    LEFT JOIN ImagingResults ires ON ir.ImagingRequestID = ires.ImagingRequestID
                ) requests";
        }

        private static List<ServiceRequestDTO> Map(DataTable table)
        {
            List<ServiceRequestDTO> list = new List<ServiceRequestDTO>();
            foreach (DataRow row in table.Rows)
            {
                string serviceType = row["ServiceType"].ToString();
                list.Add(new ServiceRequestDTO
                {
                    RequestID = Convert.ToInt32(row["RequestID"]),
                    SourceID = Convert.ToInt32(row["SourceID"]),
                    SourceTable = row["SourceTable"].ToString(),
                    RequestCode = row["RequestCode"].ToString(),
                    PatientID = row["PatientID"] != DBNull.Value ? Convert.ToInt32(row["PatientID"]) : 0,
                    PatientName = row["PatientName"].ToString(),
                    PatientCode = row["PatientCode"].ToString(),
                    RequestedByEmployeeID = row["RequestedByEmployeeID"] != DBNull.Value ? Convert.ToInt32(row["RequestedByEmployeeID"]) : 0,
                    RequestedByEmployeeName = row["RequestedByEmployeeName"].ToString(),
                    AssignedToEmployeeID = row["AssignedToEmployeeID"] != DBNull.Value ? Convert.ToInt32(row["AssignedToEmployeeID"]) : (int?)null,
                    AssignedToEmployeeName = row["AssignedToEmployeeName"].ToString(),
                    ServiceType = serviceType,
                    RequestType = row["RequestType"].ToString(),
                    RequestNote = row["RequestNote"] != DBNull.Value ? row["RequestNote"].ToString() : "",
                    Priority = row["Priority"] != DBNull.Value ? row["Priority"].ToString() : "",
                    RequestedAt = row["RequestedAt"] != DBNull.Value ? Convert.ToDateTime(row["RequestedAt"]) : DateTime.MinValue,
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "",
                    ResultFile = row["ResultFile"] != DBNull.Value ? row["ResultFile"].ToString() : "",
                    ResultPDF = row["ResultPDF"] != DBNull.Value ? row["ResultPDF"].ToString() : "",
                    LabValues = row["LabValues"] != DBNull.Value ? row["LabValues"].ToString() : ""
                });
            }

            return list;
        }

        private static int GetOrCreateImagingServiceId(string serviceName)
        {
            object existing = DatabaseHelper.ExecuteScalar(
                "SELECT TOP 1 ImagingServiceID FROM ImagingServices WHERE ServiceName = @ServiceName",
                new[] { new SqlParameter("@ServiceName", serviceName) });

            if (existing != null && existing != DBNull.Value)
            {
                return Convert.ToInt32(existing);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO ImagingServices (ServiceName, Modality, Price, IsActive) VALUES (@ServiceName, @Modality, 0, 1)",
                new[]
                {
                    new SqlParameter("@ServiceName", serviceName),
                    new SqlParameter("@Modality", InferModality(serviceName))
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT TOP 1 ImagingServiceID FROM ImagingServices WHERE ServiceName = @ServiceName ORDER BY ImagingServiceID DESC",
                new[] { new SqlParameter("@ServiceName", serviceName) }));
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
