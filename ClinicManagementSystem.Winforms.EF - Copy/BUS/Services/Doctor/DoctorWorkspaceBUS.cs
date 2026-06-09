using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories.Doctor;
using DTO;
using DTO.Doctor;

namespace BUS.Services.Doctor
{
    public class DoctorWorkspaceBUS
    {
        private readonly DoctorWorkspaceDAL dal = new();

        public int ResolveDoctorId(UserDTO user)
        {
            return dal.ResolveDoctorId(user);
        }

        public DoctorDashboardDTO GetDashboard(int doctorId, DateTime date)
        {
            return doctorId <= 0 ? new DoctorDashboardDTO() : dal.GetDashboard(doctorId, date);
        }

        public List<DoctorAppointmentDTO> GetAppointments(int doctorId, DateTime date, string searchTerm = null)
        {
            if (doctorId <= 0)
            {
                return new List<DoctorAppointmentDTO>();
            }

            IEnumerable<DoctorAppointmentDTO> query = dal.GetAppointments(doctorId, date);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim();
                query = query.Where(item =>
                    Contains(item.PatientName, term) ||
                    Contains(item.PatientCode, term) ||
                    Contains(item.DepartmentName, term));
            }

            return query.ToList();
        }

        public DoctorAppointmentDTO GetByAppointment(int doctorId, int appointmentId)
        {
            return appointmentId <= 0 ? null : dal.GetAppointmentByAppointmentId(doctorId, appointmentId);
        }

        public DoctorAppointmentDTO GetByEncounter(int doctorId, int encounterId)
        {
            return encounterId <= 0 ? null : dal.GetAppointmentByEncounterId(doctorId, encounterId);
        }

        public DoctorMedicalRecordSaveDTO GetMedicalRecord(int encounterId)
        {
            return encounterId <= 0 ? null : dal.GetMedicalRecord(encounterId);
        }

        public List<DoctorHistoryDTO> GetHistory(int patientId, int currentEncounterId)
        {
            return patientId <= 0 ? new List<DoctorHistoryDTO>() : dal.GetHistory(patientId, currentEncounterId);
        }

        public List<DoctorLabResultDTO> GetLabResults(int encounterId)
        {
            return encounterId <= 0 ? new List<DoctorLabResultDTO>() : dal.GetLabResults(encounterId);
        }

        public List<DoctorImagingResultDTO> GetImagingResults(int encounterId)
        {
            return encounterId <= 0 ? new List<DoctorImagingResultDTO>() : dal.GetImagingResults(encounterId);
        }

        public List<MedicineDTO> GetMedicines()
        {
            return dal.GetMedicines();
        }

        public List<PrescriptionDTO> GetPrescriptions(int doctorId)
        {
            if (doctorId > 0)
            {
                dal.EnsureDemoData(doctorId, DateTime.Today);
            }

            return dal.GetDoctorPrescriptions(doctorId);
        }

        public void StartExamination(int appointmentId, int encounterId, int doctorId)
        {
            if (appointmentId <= 0)
            {
                throw new ArgumentException("Lich kham khong hop le.");
            }

            if (doctorId <= 0)
            {
                throw new ArgumentException("Khong xac dinh duoc bac si dang dang nhap.");
            }

            dal.StartExamination(appointmentId, encounterId, doctorId);
        }

        public void SaveMedicalRecord(DoctorMedicalRecordSaveDTO record)
        {
            if (record == null || record.EncounterID <= 0)
            {
                throw new ArgumentException("Chua chon benh nhan de luu benh an.");
            }

            if (string.IsNullOrWhiteSpace(record.Diagnosis))
            {
                throw new ArgumentException("Chan doan khong duoc de trong.");
            }

            dal.SaveMedicalRecord(record);
        }

        public void CreateLabRequests(IEnumerable<DoctorRequestSaveDTO> requests)
        {
            foreach (DoctorRequestSaveDTO request in NormalizeRequests(requests, "Lab"))
            {
                dal.CreateLabRequest(request);
            }
        }

        public void CreateImagingRequests(IEnumerable<DoctorRequestSaveDTO> requests)
        {
            foreach (DoctorRequestSaveDTO request in NormalizeRequests(requests, "Imaging"))
            {
                dal.CreateImagingRequest(request);
            }
        }

        public int CreatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            if (prescription == null || prescription.EncounterID <= 0 || prescription.DoctorID <= 0)
            {
                throw new ArgumentException("Thong tin toa thuoc khong hop le.");
            }

            prescription.Items = prescription.Items?
                .Where(item => item.MedicineID > 0 && item.Quantity > 0)
                .ToList() ?? new List<DoctorPrescriptionItemSaveDTO>();

            if (prescription.Items.Count == 0)
            {
                throw new ArgumentException("Toa thuoc can it nhat mot thuoc.");
            }

            return dal.CreatePrescription(prescription);
        }

        public void UpdatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            if (prescription == null || prescription.PrescriptionID <= 0)
            {
                throw new ArgumentException("Toa thuoc khong hop le.");
            }

            prescription.Items = prescription.Items?
                .Where(item => item.MedicineID > 0 && item.Quantity > 0)
                .ToList() ?? new List<DoctorPrescriptionItemSaveDTO>();

            if (prescription.Items.Count == 0)
            {
                throw new ArgumentException("Toa thuoc can it nhat mot thuoc.");
            }

            dal.UpdatePrescription(prescription);
        }

        public void DeletePrescription(int prescriptionId)
        {
            if (prescriptionId <= 0)
            {
                throw new ArgumentException("Toa thuoc khong hop le.");
            }

            dal.DeletePrescription(prescriptionId);
        }

        public void CompleteExamination(int appointmentId, int encounterId, int doctorId)
        {
            if (appointmentId <= 0 || encounterId <= 0 || doctorId <= 0)
            {
                throw new ArgumentException("Chua chon du ca kham de hoan thanh.");
            }

            dal.CompleteExamination(appointmentId, encounterId, doctorId);
        }

        public static string ToDisplayStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return "Chua cap nhat";
            }

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
            List<DoctorRequestSaveDTO> list = requests?
                .Where(item => item != null && !string.IsNullOrWhiteSpace(item.ServiceName))
                .ToList() ?? new List<DoctorRequestSaveDTO>();

            foreach (DoctorRequestSaveDTO request in list)
            {
                if (request.EncounterID <= 0 || request.DoctorID <= 0)
                {
                    throw new ArgumentException("Yeu cau " + type + " thieu encounter hoac bac si.");
                }

                request.RequestType = type;
                if (string.IsNullOrWhiteSpace(request.Priority))
                {
                    request.Priority = "Normal";
                }
            }

            return list;
        }

        private static bool Contains(string source, string term)
        {
            return (source ?? "").IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
