using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class PaymentDAL
    {
        public List<PaymentWaitingDTO>
            GetWaitingPayments()
        {
            string query =
            @"
            SELECT
    pa.PaymentID,
    pa.EncounterID,
    p.PatientID,
    p.PatientCode,
    p.FullName AS PatientName,
    d.FullName AS DoctorName,
    pa.Amount,
    pa.Status
            FROM Payments pa
            INNER JOIN Encounters e
                ON pa.EncounterID = e.EncounterID
            INNER JOIN Patients p
                ON pa.PatientID = p.PatientID
            INNER JOIN Employees d
                ON e.DoctorID = d.EmployeeID
            WHERE pa.Status = 'Pending'
            ";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(query);

            List<PaymentWaitingDTO> list =
                new();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(
    new PaymentWaitingDTO
    {
        EncounterID =
            Convert.ToInt32(
                row["EncounterID"]),

        PatientID =
            Convert.ToInt32(
                row["PatientID"]),

        PatientCode =
            row["PatientCode"]?.ToString()
            ?? string.Empty,

        PatientName =
            row["PatientName"]?.ToString()
            ?? string.Empty,

        DoctorName =
            row["DoctorName"]?.ToString()
            ?? string.Empty,

        Status =
            row["Status"]?.ToString()
            ?? string.Empty,

        TotalAmount =
            Convert.ToDecimal(
                row["Amount"])
    });
            }

            return list;
        }

        public bool CreatePendingPayment(
            int encounterId,
            int patientId)
        {
            string query =
            @"
            INSERT INTO Payments
            (
                EncounterID,
                PatientID,
                Amount,
                Method,
                Status
            )
            VALUES
            (
                @EncounterID,
                @PatientID,
                0,
                '',
                'Pending'
            )
            ";

            SqlParameter[] parameters =
            {
                new("@EncounterID", encounterId),
                new("@PatientID", patientId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(
                    query,
                    parameters) > 0;
        }

        public bool UpdateAmount(
            int encounterId,
            decimal amount)
        {
            string query =
            @"
            UPDATE Payments
            SET Amount = @Amount
            WHERE EncounterID = @EncounterID
            ";

            SqlParameter[] parameters =
            {
                new("@Amount", amount),
                new("@EncounterID", encounterId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(
                    query,
                    parameters) > 0;
        }

        public bool UpdatePaymentStatus(
            int encounterId,
            string method)
        {
            string query =
            @"
            UPDATE Payments
            SET
                Status = 'Paid',
                Method = @Method,
                PaidAt = GETDATE()
            WHERE EncounterID = @EncounterID
            ";

            SqlParameter[] parameters =
            {
                new("@Method", method),
                new("@EncounterID", encounterId)
            };

            return DatabaseHelper
                .ExecuteNonQuery(
                    query,
                    parameters) > 0;
        }

        public List<PaymentDetailDTO>
            GetInvoiceDetails(
                int encounterId)
        {
            List<PaymentDetailDTO> list =
                new();

            string query =
            @"
            SELECT
    p.FullName AS PatientName,
    s.ServiceName AS Description,
    es.Quantity,
    es.UnitPrice,
    es.Quantity * es.UnitPrice AS Amount
FROM EncounterServices es
INNER JOIN Services s
    ON es.ServiceID = s.ServiceID
INNER JOIN Encounters e
    ON es.EncounterID = e.EncounterID
INNER JOIN Patients p
    ON e.PatientID = p.PatientID
WHERE es.EncounterID = @EncounterID
            ";

            SqlParameter[] parameters =
            {
                new("@EncounterID",
                    encounterId)
            };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(
    new PaymentDetailDTO
    {
        ItemType = "Service",

        PatientName =
            row["PatientName"]
            .ToString()
            ?? string.Empty,

        Description =
            row["Description"]
            .ToString()
            ?? string.Empty,

        Quantity =
            Convert.ToInt32(
                row["Quantity"]),

        UnitPrice =
            Convert.ToDecimal(
                row["UnitPrice"]),

        Amount =
            Convert.ToDecimal(
                row["Amount"])
    });
            }

            return list;
        }

        public List<Payment_RecepDTO>
            GetPaymentHistory()
        {
            List<Payment_RecepDTO> list =
                new();

            string query =
            @"
            SELECT
    p.PaymentID,
    p.EncounterID,
    p.PatientID,
    pa.FullName AS PatientName,
    p.Amount,
    p.Method,
    p.Status,
    p.PaidAt
FROM Payments p
INNER JOIN Patients pa
    ON p.PatientID = pa.PatientID
WHERE p.Status = 'Paid'
ORDER BY p.PaidAt DESC
            ";

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(
                    new Payment_RecepDTO
                    {
                        PaymentID =
                            Convert.ToInt32(
                                row["PaymentID"]),

                        EncounterID =
                            Convert.ToInt32(
                                row["EncounterID"]),

                        PatientID =
                            Convert.ToInt32(
                                row["PatientID"]),
                        PatientName =
    row["PatientName"]
    .ToString()
    ?? string.Empty,

                        Amount =
                            Convert.ToDecimal(
                                row["Amount"]),

                        Method =
                            row["Method"]
                            .ToString()
                            ?? string.Empty,

                        Status =
                            row["Status"]
                            .ToString()
                            ?? string.Empty,

                        PaidAt =
                            Convert.ToDateTime(
                                row["PaidAt"])
                    });
            }

            return list;
        }

        public List<Payment_RecepDTO>
    SearchPaymentHistory(
        string keyword)
        {
            List<Payment_RecepDTO> list =
                new();

            string query =
            @"
    SELECT
    p.PaymentID,
    p.EncounterID,
    p.PatientID,
    pa.FullName AS PatientName,
    p.Amount,
    p.Method,
    p.Status,
    p.PaidAt
FROM Payments p
INNER JOIN Patients pa
    ON p.PatientID = pa.PatientID
WHERE p.Status = 'Paid'
  AND
  (
       pa.FullName LIKE '%' + @Keyword + '%'
    OR CAST(p.PaymentID AS NVARCHAR) LIKE '%' + @Keyword + '%'
    OR CAST(p.EncounterID AS NVARCHAR) LIKE '%' + @Keyword + '%'
  )
ORDER BY p.PaidAt DESC
    ";

            SqlParameter[] parameters =
            {
        new("@Keyword", keyword)
    };

            DataTable dt =
                DatabaseHelper.ExecuteQuery(
                    query,
                    parameters);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(
                    new Payment_RecepDTO
                    {
                        PaymentID =
                            Convert.ToInt32(
                                row["PaymentID"]),

                        EncounterID =
                            Convert.ToInt32(
                                row["EncounterID"]),

                        PatientID =
                            Convert.ToInt32(
                                row["PatientID"]),

                        Amount =
                            Convert.ToDecimal(
                                row["Amount"]),

                        Method =
                            row["Method"]
                            .ToString()
                            ?? string.Empty,

                        Status =
                            row["Status"]
                            .ToString()
                            ?? string.Empty,

                        PaidAt =
                            Convert.ToDateTime(
                                row["PaidAt"])
                    });
            }

            return list;
        }
    }

}