using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MOMO_QR_DANANG.Models;

namespace MOMO_QR_DANANG.DataAccess
{
    public class RequestDAL
    {
        private const string BaseSelect = @"
            SELECT r.*, p.Name AS PatientName, p.PatientCode AS PatientCode, d.Name AS DoctorName 
            FROM Requests r
            INNER JOIN Patients p ON r.PatientID = p.PatientID
            INNER JOIN Doctors d ON r.DoctorID = d.DoctorID";

        public List<RequestDTO> GetAll()
        {
            string query = BaseSelect + " ORDER BY r.RequestDate DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            return MapTableToList(dt);
        }

        public List<RequestDTO> GetByStatus(string status)
        {
            string query = BaseSelect + " WHERE r.Status = @Status ORDER BY r.RequestDate DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return MapTableToList(dt);
        }

        public List<RequestDTO> Search(string term, string status)
        {
            string query = BaseSelect + " WHERE 1=1";
            List<SqlParameter> listParams = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(status) && status != "Tất cả trạng thái")
            {
                query += " AND r.Status = @Status";
                listParams.Add(new SqlParameter("@Status", status));
            }

            if (!string.IsNullOrEmpty(term))
            {
                query += " AND (p.Name LIKE @Term OR p.PatientCode LIKE @Term OR r.ServiceType LIKE @Term)";
                listParams.Add(new SqlParameter("@Term", "%" + term + "%"));
            }

            query += " ORDER BY r.RequestDate DESC";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, listParams.ToArray());
            return MapTableToList(dt);
        }

        public List<RequestDTO> GetByPatient(int patientId)
        {
            string query = BaseSelect + " WHERE r.PatientID = @PatientID ORDER BY r.RequestDate DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PatientID", patientId)
            };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return MapTableToList(dt);
        }

        public bool UpdateStatus(int requestId, string status)
        {
            string query = "UPDATE Requests SET Status = @Status WHERE RequestID = @RequestID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status),
                new SqlParameter("@RequestID", requestId)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SaveImagingResult(int requestId, string resultFile, string note)
        {
            string query = "UPDATE Requests SET ResultFile = @ResultFile, RequestNote = @RequestNote, Status = @Status WHERE RequestID = @RequestID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ResultFile", resultFile),
                new SqlParameter("@RequestNote", note),
                new SqlParameter("@Status", "Hoàn thành"),
                new SqlParameter("@RequestID", requestId)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SavePDFResult(int requestId, string resultPDF)
        {
            string query = "UPDATE Requests SET ResultPDF = @ResultPDF, Status = @Status WHERE RequestID = @RequestID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ResultPDF", resultPDF),
                new SqlParameter("@Status", "Hoàn thành"),
                new SqlParameter("@RequestID", requestId)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SaveLabResult(int requestId, string labValues)
        {
            string query = "UPDATE Requests SET LabValues = @LabValues, Status = @Status WHERE RequestID = @RequestID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LabValues", labValues),
                new SqlParameter("@Status", "Hoàn thành"),
                new SqlParameter("@RequestID", requestId)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool Add(RequestDTO req)
        {
            string query = @"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status, ResultFile, ResultPDF, LabValues)
                             VALUES (@RequestCode, @PatientID, @DoctorID, @ServiceType, @RequestNote, @Priority, @RequestDate, @Status, @ResultFile, @ResultPDF, @LabValues)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RequestCode", req.RequestCode),
                new SqlParameter("@PatientID", req.PatientID),
                new SqlParameter("@DoctorID", req.DoctorID),
                new SqlParameter("@ServiceType", req.ServiceType),
                new SqlParameter("@RequestNote", (object)req.RequestNote ?? DBNull.Value),
                new SqlParameter("@Priority", req.Priority),
                new SqlParameter("@RequestDate", req.RequestDate),
                new SqlParameter("@Status", req.Status),
                new SqlParameter("@ResultFile", (object)req.ResultFile ?? DBNull.Value),
                new SqlParameter("@ResultPDF", (object)req.ResultPDF ?? DBNull.Value),
                new SqlParameter("@LabValues", (object)req.LabValues ?? DBNull.Value)
            };
            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        private List<RequestDTO> MapTableToList(DataTable dt)
        {
            List<RequestDTO> list = new List<RequestDTO>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new RequestDTO
                {
                    RequestID = Convert.ToInt32(row["RequestID"]),
                    RequestCode = row["RequestCode"].ToString(),
                    PatientID = Convert.ToInt32(row["PatientID"]),
                    DoctorID = Convert.ToInt32(row["DoctorID"]),
                    ServiceType = row["ServiceType"].ToString(),
                    RequestNote = row["RequestNote"] != DBNull.Value ? row["RequestNote"].ToString() : "",
                    Priority = row["Priority"].ToString(),
                    RequestDate = Convert.ToDateTime(row["RequestDate"]),
                    Status = row["Status"].ToString(),
                    ResultFile = row["ResultFile"] != DBNull.Value ? row["ResultFile"].ToString() : "",
                    ResultPDF = row["ResultPDF"] != DBNull.Value ? row["ResultPDF"].ToString() : "",
                    LabValues = row["LabValues"] != DBNull.Value ? row["LabValues"].ToString() : "",
                    PatientName = row["PatientName"].ToString(),
                    PatientCode = row["PatientCode"].ToString(),
                    DoctorName = row["DoctorName"].ToString()
                });
            }
            return list;
        }
    }
}

