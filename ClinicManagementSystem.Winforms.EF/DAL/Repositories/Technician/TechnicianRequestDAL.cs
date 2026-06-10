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
    public class TechnicianRequestDAL : ITechnicianRequestDAL
    {
        private readonly CMSDbContext _context;

        public TechnicianRequestDAL(CMSDbContext context)
        {
            _context = context;
        }

        private const string LabSource = "LabRequests";
        private const string ImagingSource = "ImagingRequests";

        public List<TechnicianRequestDTO> GetAll()
        {
            return MapTableToList(DatabaseHelper.ExecuteQuery(GetBaseSelect() + " ORDER BY RequestDate DESC"));
        }

        public List<TechnicianRequestDTO> GetByStatus(string status)
        {
            string query = GetBaseSelect() + " WHERE Status = @Status ORDER BY RequestDate DESC";
            return MapTableToList(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@Status", status)
            }));
        }

        public List<TechnicianRequestDTO> Search(string term, string status)
        {
            string query = GetBaseSelect() + " WHERE 1 = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(status) && status != "Tất cả trạng thái")
            {
                query += " AND Status = @Status";
                parameters.Add(new SqlParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(term))
            {
                query += " AND (PatientName LIKE @Term OR PatientCode LIKE @Term OR ServiceType LIKE @Term OR DoctorName LIKE @Term)";
                parameters.Add(new SqlParameter("@Term", "%" + term + "%"));
            }

            query += " ORDER BY RequestDate DESC";
            return MapTableToList(DatabaseHelper.ExecuteQuery(query, parameters.ToArray()));
        }

        public List<TechnicianRequestDTO> GetByPatient(int patientId)
        {
            string query = GetBaseSelect() + " WHERE PatientID = @PatientID ORDER BY RequestDate DESC";
            return MapTableToList(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@PatientID", patientId)
            }));
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

        public bool SaveImagingResult(int requestId, string resultFile, string note)
        {
            RequestKey key = DecodeRequestKey(requestId);
            if (key.SourceTable != ImagingSource)
            {
                return false;
            }

            return UpsertImagingResult(key.SourceID, resultFile, null, note);
        }

        public bool SavePDFResult(int requestId, string resultPDF)
        {
            RequestKey key = DecodeRequestKey(requestId);
            if (key.SourceTable != ImagingSource)
            {
                return false;
            }

            return UpsertImagingResult(key.SourceID, null, resultPDF, null);
        }

        public bool SaveLabResult(int requestId, string labValues)
        {
            RequestKey key = DecodeRequestKey(requestId);
            if (key.SourceTable != LabSource)
            {
                return false;
            }

            object existing = DatabaseHelper.ExecuteScalar(
                "SELECT ResultID FROM LabResults WHERE LabID = @LabID",
                new[] { new SqlParameter("@LabID", key.SourceID) });

            int affected;
            if (existing != null && existing != DBNull.Value)
            {
                affected = DatabaseHelper.ExecuteNonQuery(
                    "UPDATE LabResults SET ResultText = @ResultText, CompletedAt = @CompletedAt WHERE LabID = @LabID",
                    new[]
                    {
                        new SqlParameter("@ResultText", labValues),
                        new SqlParameter("@CompletedAt", DateTime.Now),
                        new SqlParameter("@LabID", key.SourceID)
                    });
            }
            else
            {
                affected = DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO LabResults (LabID, ResultText, CompletedAt) VALUES (@LabID, @ResultText, @CompletedAt)",
                    new[]
                    {
                        new SqlParameter("@LabID", key.SourceID),
                        new SqlParameter("@ResultText", labValues),
                        new SqlParameter("@CompletedAt", DateTime.Now)
                    });
            }

            if (affected <= 0)
            {
                return false;
            }

            UpdateStatus(requestId, "Hoàn thành");
            return true;
        }

        public bool Add(TechnicianRequestDTO req)
        {
            string requestType = string.IsNullOrWhiteSpace(req.RequestType)
                ? InferRequestType(req.ServiceType)
                : req.RequestType;

            if (requestType == ServiceRequestType.Imaging)
            {
                int serviceId = GetOrCreateImagingServiceId(req.ServiceType);
                string query = @"
                    INSERT INTO ImagingRequests (EncounterID, DoctorID, ImagingServiceID, BodyPart, CreatedAt, Priority, Status)
                    VALUES (NULL, @DoctorID, @ImagingServiceID, @BodyPart, @CreatedAt, @Priority, @Status)";
                return DatabaseHelper.ExecuteNonQuery(query, new[]
                {
                    new SqlParameter("@DoctorID", req.RequestedByEmployeeID),
                    new SqlParameter("@ImagingServiceID", serviceId),
                    new SqlParameter("@BodyPart", (object)req.RequestNote ?? DBNull.Value),
                    new SqlParameter("@CreatedAt", req.RequestDate == default ? DateTime.Now : req.RequestDate),
                    new SqlParameter("@Priority", (object)req.Priority ?? DBNull.Value),
                    new SqlParameter("@Status", string.IsNullOrWhiteSpace(req.Status) ? "Chờ xử lý" : req.Status)
                }) > 0;
            }

            string labQuery = @"
                INSERT INTO LabRequests (EncounterID, DoctorID, TestType, Status, CreatedAt)
                VALUES (NULL, @DoctorID, @TestType, @Status, @CreatedAt)";
            return DatabaseHelper.ExecuteNonQuery(labQuery, new[]
            {
                new SqlParameter("@DoctorID", req.RequestedByEmployeeID),
                new SqlParameter("@TestType", req.ServiceType),
                new SqlParameter("@Status", string.IsNullOrWhiteSpace(req.Status) ? "Chờ xử lý" : req.Status),
                new SqlParameter("@CreatedAt", req.RequestDate == default ? DateTime.Now : req.RequestDate)
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
                        lr.DoctorID,
                        ISNULL(e.FullName, '') AS DoctorName,
                        lr.TestType AS ServiceType,
                        'Lab' AS RequestType,
                        CAST('' AS nvarchar(max)) AS RequestNote,
                        CAST('' AS nvarchar(50)) AS Priority,
                        lr.CreatedAt AS RequestDate,
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
                        ir.DoctorID,
                        ISNULL(e.FullName, '') AS DoctorName,
                        COALESCE(s.ServiceName, s.Modality, ir.BodyPart, N'Chẩn đoán hình ảnh') AS ServiceType,
                        'Imaging' AS RequestType,
                        ISNULL(ires.TechnicianNote, ir.BodyPart) AS RequestNote,
                        ISNULL(ir.Priority, '') AS Priority,
                        ir.CreatedAt AS RequestDate,
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

        private static List<TechnicianRequestDTO> MapTableToList(DataTable dt)
        {
            List<TechnicianRequestDTO> list = new List<TechnicianRequestDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TechnicianRequestDTO
                {
                    RequestID = Convert.ToInt32(row["RequestID"]),
                    SourceID = Convert.ToInt32(row["SourceID"]),
                    SourceTable = row["SourceTable"].ToString(),
                    RequestCode = row["RequestCode"].ToString(),
                    PatientID = row["PatientID"] != DBNull.Value ? Convert.ToInt32(row["PatientID"]) : 0,
                    DoctorID = row["DoctorID"] != DBNull.Value ? Convert.ToInt32(row["DoctorID"]) : 0,
                    AssignedToEmployeeID = null,
                    ServiceType = row["ServiceType"].ToString(),
                    RequestType = row["RequestType"].ToString(),
                    RequestNote = row["RequestNote"] != DBNull.Value ? row["RequestNote"].ToString() : "",
                    Priority = row["Priority"] != DBNull.Value ? row["Priority"].ToString() : "",
                    RequestDate = row["RequestDate"] != DBNull.Value ? Convert.ToDateTime(row["RequestDate"]) : DateTime.MinValue,
                    Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "",
                    ResultFile = row["ResultFile"] != DBNull.Value ? row["ResultFile"].ToString() : "",
                    ResultPDF = row["ResultPDF"] != DBNull.Value ? row["ResultPDF"].ToString() : "",
                    LabValues = row["LabValues"] != DBNull.Value ? row["LabValues"].ToString() : "",
                    PatientName = row["PatientName"].ToString(),
                    PatientCode = row["PatientCode"].ToString(),
                    DoctorName = row["DoctorName"].ToString(),
                    AssignedToEmployeeName = ""
                });
            }

            return list;
        }

        private static bool UpsertImagingResult(int imagingRequestId, string imageUrl, string pdfUrl, string note)
        {
            object existing = DatabaseHelper.ExecuteScalar(
                "SELECT ImagingResultID FROM ImagingResults WHERE ImagingRequestID = @ImagingRequestID",
                new[] { new SqlParameter("@ImagingRequestID", imagingRequestId) });

            SqlParameter imageParam = new SqlParameter("@ImageURL", (object)imageUrl ?? DBNull.Value);
            SqlParameter pdfParam = new SqlParameter("@PDFURL", (object)pdfUrl ?? DBNull.Value);
            SqlParameter noteParam = new SqlParameter("@TechnicianNote", (object)note ?? DBNull.Value);

            int affected;
            if (existing != null && existing != DBNull.Value)
            {
                string update = @"
                    UPDATE ImagingResults
                    SET ImageURL = COALESCE(@ImageURL, ImageURL),
                        PDFURL = COALESCE(@PDFURL, PDFURL),
                        TechnicianNote = COALESCE(@TechnicianNote, TechnicianNote),
                        CompletedAt = @CompletedAt
                    WHERE ImagingRequestID = @ImagingRequestID";
                affected = DatabaseHelper.ExecuteNonQuery(update, new[]
                {
                    imageParam,
                    pdfParam,
                    noteParam,
                    new SqlParameter("@CompletedAt", DateTime.Now),
                    new SqlParameter("@ImagingRequestID", imagingRequestId)
                });
            }
            else
            {
                string insert = @"
                    INSERT INTO ImagingResults (ImagingRequestID, ImageURL, PDFURL, TechnicianNote, CompletedAt)
                    VALUES (@ImagingRequestID, @ImageURL, @PDFURL, @TechnicianNote, @CompletedAt)";
                affected = DatabaseHelper.ExecuteNonQuery(insert, new[]
                {
                    new SqlParameter("@ImagingRequestID", imagingRequestId),
                    imageParam,
                    pdfParam,
                    noteParam,
                    new SqlParameter("@CompletedAt", DateTime.Now)
                });
            }

            if (affected <= 0)
            {
                return false;
            }

            DatabaseHelper.ExecuteNonQuery(
                "UPDATE ImagingRequests SET Status = @Status WHERE ImagingRequestID = @ImagingRequestID",
                new[]
                {
                    new SqlParameter("@Status", "Hoàn thành"),
                    new SqlParameter("@ImagingRequestID", imagingRequestId)
                });
            return true;
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
