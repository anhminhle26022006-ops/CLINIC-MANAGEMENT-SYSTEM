using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DTO;

namespace DAL
{
    public class PrescriptionDAL
    {
        public List<PrescriptionDTO> GetPendingPrescriptions()
        {
            using var db = new CMSDbContext();

            var prescriptions = db.Prescriptions
                .Where(p =>
                    p.Status != "Completed" &&
                    p.Status != "Đã cấp phát")
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            List<PrescriptionDTO> result = new();

            foreach (var prescription in prescriptions)
            {
                var record = prescription.Encounter?
                    .MedicalRecords?
                    .FirstOrDefault();

                var dto = new PrescriptionDTO
                {
                    PrescriptionID =
                        prescription.PrescriptionId,

                    EncounterID =
                        prescription.EncounterId ?? 0,

                    DoctorID =
                        prescription.DoctorId ?? 0,

                    Status =
                        prescription.Status ?? string.Empty,

                    CreatedAt =
                        prescription.CreatedAt ??
                        DateTime.MinValue,

                    PatientName =
                        prescription.Encounter?.Patient?.FullName
                        ?? string.Empty,

                    PatientGender =
                        prescription.Encounter?.Patient?.Gender
                        ?? string.Empty,

                    PatientDOB =
                        prescription.Encounter?.Patient?.Dob
                            ?.ToDateTime(TimeOnly.MinValue),

                    PatientCode =
                        prescription.Encounter?.Patient?.PatientCode
                        ?? string.Empty,

                    PatientAllergies =
                        prescription.Encounter?.Patient?.Allergy
                        ?? "Không",

                    DoctorName =
                        prescription.Doctor?.FullName
                        ?? string.Empty,

                    Diagnosis =
                        record?.Diagnosis
                        ?? "Khám sức khỏe tổng quát",

                    DoctorNotes =
                        record?.Notes
                        ?? string.Empty
                };

                dto.Items =
                    GetPrescriptionItems(
                        dto.PrescriptionID);

                result.Add(dto);
            }

            return result;
        }

        public List<PrescriptionItemDTO>
            GetPrescriptionItems(
                int prescriptionId)
        {
            using var db = new CMSDbContext();

            return db.PrescriptionDetails
                .Where(pd =>
                    pd.PrescriptionId ==
                    prescriptionId)
                .Select(pd =>
                    new PrescriptionItemDTO
                    {
                        DetailID =
                            pd.DetailId,

                        PrescriptionID =
                            pd.PrescriptionId ?? 0,

                        MedicineID =
                            pd.MedicineId ?? 0,

                        Quantity =
                            pd.Quantity ?? 0,

                        Dosage =
                            pd.Dosage ?? string.Empty,

                        Frequency =
                            pd.Frequency ?? string.Empty,

                        Instruction =
                            pd.Instruction ?? string.Empty,

                        MedicineName =
                            pd.Medicine.Name
                            ?? string.Empty,

                        MedicineUnit =
                            pd.Medicine.Unit
                            ?? string.Empty,

                        BatchNumber =
                            pd.Medicine.BatchNumber
                            ?? string.Empty,

                        Price =
                            pd.Medicine.Price ?? 0
                    })
                .ToList();
        }

        public bool UpdatePrescriptionStatus(
            int prescriptionId,
            string status)
        {
            using var db = new CMSDbContext();

            var prescription =
                db.Prescriptions
                  .FirstOrDefault(p =>
                      p.PrescriptionId ==
                      prescriptionId);

            if (prescription == null)
                return false;

            prescription.Status = status;

            return db.SaveChanges() > 0;
        }
    }
}