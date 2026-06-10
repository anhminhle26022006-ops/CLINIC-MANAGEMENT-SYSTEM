using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories.Doctor;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace BUS.Services.Doctor
{
    public class DoctorWorkspaceBUS
    {
        private readonly DoctorWorkspaceDAL _dal;

        // Constructor mặc định (dùng context mới – không khuyến khích, chỉ để tương thích)
        public DoctorWorkspaceBUS() : this(new CMSDbContext())
        {
        }

        // Constructor chính nhận context (dùng khi runtime)
        public DoctorWorkspaceBUS(CMSDbContext context)
        {
            _dal = new DoctorWorkspaceDAL(context);
        }

        public int ResolveDoctorId(UserDTO user)
        {
            return _dal.ResolveDoctorId(user);
        }

        public DoctorDashboardDTO GetDashboard(int doctorId, DateTime date)
        {
            return doctorId <= 0 ? new DoctorDashboardDTO() : _dal.GetDashboard(doctorId, date);
        }

        public List<DoctorAppointmentDTO> GetAppointments(int doctorId, DateTime date, string searchTerm = null)
        {
            if (doctorId <= 0) return new List<DoctorAppointmentDTO>();

            var query = _dal.GetAppointments(doctorId, date);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim();
                query = query.Where(item =>
                    Contains(item.PatientName, term) ||
                    Contains(item.PatientCode, term) ||
                    Contains(item.DepartmentName, term)).ToList();
            }
            return query.ToList();
        }

        public DoctorAppointmentDTO GetByAppointment(int doctorId, int appointmentId)
        {
            return appointmentId <= 0 ? null : _dal.GetAppointmentByAppointmentId(doctorId, appointmentId);
        }

        public DoctorAppointmentDTO GetByEncounter(int doctorId, int encounterId)
        {
            return encounterId <= 0 ? null : _dal.GetAppointmentByEncounterId(doctorId, encounterId);
        }

        public DoctorMedicalRecordSaveDTO GetMedicalRecord(int encounterId)
        {
            return encounterId <= 0 ? null : _dal.GetMedicalRecord(encounterId);
        }

        public List<DoctorHistoryDTO> GetHistory(int patientId, int currentEncounterId)
        {
            return patientId <= 0 ? new List<DoctorHistoryDTO>() : _dal.GetHistory(patientId, currentEncounterId);
        }

        public List<DoctorLabResultDTO> GetLabResults(int encounterId)
        {
            return encounterId <= 0 ? new List<DoctorLabResultDTO>() : _dal.GetLabResults(encounterId);
        }

        public List<DoctorImagingResultDTO> GetImagingResults(int encounterId)
        {
            return encounterId <= 0 ? new List<DoctorImagingResultDTO>() : _dal.GetImagingResults(encounterId);
        }

        public List<MedicineDTO> GetMedicines()
        {
            return _dal.GetMedicines();
        }

        public List<PrescriptionDTO> GetPrescriptions(int doctorId)
        {
            if (doctorId > 0)
                _dal.EnsureDemoData(doctorId, DateTime.Today);
            return _dal.GetDoctorPrescriptions(doctorId);
        }

        public void StartExamination(int appointmentId, int encounterId, int doctorId)
        {
            if (appointmentId <= 0)
                throw new ArgumentException("Lich kham khong hop le.");
            if (doctorId <= 0)
                throw new ArgumentException("Khong xac dinh duoc bac si dang dang nhap.");
            _dal.StartExamination(appointmentId, encounterId, doctorId);
        }

        public void SaveMedicalRecord(DoctorMedicalRecordSaveDTO record)
        {
            if (record == null || record.EncounterID <= 0)
                throw new ArgumentException("Chua chon benh nhan de luu benh an.");
            if (string.IsNullOrWhiteSpace(record.Diagnosis))
                throw new ArgumentException("Chan doan khong duoc de trong.");
            _dal.SaveMedicalRecord(record);
        }

        public void CreateLabRequests(IEnumerable<DoctorRequestSaveDTO> requests)
        {
            foreach (var request in NormalizeRequests(requests, "Lab"))
                _dal.CreateLabRequest(request);
        }

        public void CreateImagingRequests(IEnumerable<DoctorRequestSaveDTO> requests)
        {
            foreach (var request in NormalizeRequests(requests, "Imaging"))
                _dal.CreateImagingRequest(request);
        }

        public int CreatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            if (prescription == null || prescription.EncounterID <= 0 || prescription.DoctorID <= 0)
                throw new ArgumentException("Thong tin toa thuoc khong hop le.");

            prescription.Items = prescription.Items?.Where(i => i.MedicineID > 0 && i.Quantity > 0).ToList() ?? new List<DoctorPrescriptionItemSaveDTO>();
            if (prescription.Items.Count == 0)
                throw new ArgumentException("Toa thuoc can it nhat mot thuoc.");

            return _dal.CreatePrescription(prescription);
        }

        public void UpdatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            if (prescription == null || prescription.PrescriptionID <= 0)
                throw new ArgumentException("Toa thuoc khong hop le.");

            prescription.Items = prescription.Items?.Where(i => i.MedicineID > 0 && i.Quantity > 0).ToList() ?? new List<DoctorPrescriptionItemSaveDTO>();
            if (prescription.Items.Count == 0)
                throw new ArgumentException("Toa thuoc can it nhat mot thuoc.");

            _dal.UpdatePrescription(prescription);
        }

        public void DeletePrescription(int prescriptionId)
        {
            if (prescriptionId <= 0)
                throw new ArgumentException("Toa thuoc khong hop le.");
            _dal.DeletePrescription(prescriptionId);
        }

        public void CompleteExamination(int appointmentId, int encounterId, int doctorId)
        {
            if (appointmentId <= 0 || encounterId <= 0 || doctorId <= 0)
                throw new ArgumentException("Chua chon du ca kham de hoan thanh.");
            _dal.CompleteExamination(appointmentId, encounterId, doctorId);
        }

        public static string ToDisplayStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) return "Chua cap nhat";
            return status switch
            {
                "Waiting" => "Cho kham",
                "Examining" => "Dang kham",
                "InProgress" => "Dang xu ly",
                "Completed" => "Hoan thanh",
                "Cancelled" => "Da huy",
                "Pending" => "Cho xu ly",
                "Issued" => "Da ke toa",
                _ => status
            };
        }

        private static List<DoctorRequestSaveDTO> NormalizeRequests(IEnumerable<DoctorRequestSaveDTO> requests, string type)
        {
            var list = requests?.Where(r => r != null && !string.IsNullOrWhiteSpace(r.ServiceName)).ToList() ?? new List<DoctorRequestSaveDTO>();
            foreach (var req in list)
            {
                if (req.EncounterID <= 0 || req.DoctorID <= 0)
                    throw new ArgumentException($"Yeu cau {type} thieu encounter hoac bac si.");
                req.RequestType = type;
                if (string.IsNullOrWhiteSpace(req.Priority))
                    req.Priority = "Normal";
            }
            return list;
        }

        private static bool Contains(string source, string term)
        {
            return (source ?? "").IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}