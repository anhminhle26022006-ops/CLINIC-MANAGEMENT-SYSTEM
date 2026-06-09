using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class PrescriptionDAL
    {
        public List<PrescriptionDTO> GetPendingPrescriptions()
        {
            SeedSamplePrescriptionsIfEmpty();

            using (var context = new ClinicDbContext())
            {
                var query = from p in context.Prescriptions
                            join enc in context.Encounters on p.EncounterID equals enc.EncounterID
                            join pat in context.Patients on enc.PatientID equals pat.PatientID
                            join doc in context.Employees on p.DoctorID equals doc.EmployeeID
                            join mr in context.MedicalRecords on enc.EncounterID equals mr.EncounterID into mrGroup
                            from mr in mrGroup.DefaultIfEmpty()
                            where p.Status != "Completed" && p.Status != "Đã cấp phát"
                            orderby p.CreatedAt descending
                            select new PrescriptionDTO
                            {
                                PrescriptionID = p.PrescriptionID,
                                EncounterID = p.EncounterID ?? 0,
                                DoctorID = p.DoctorID ?? 0,
                                Status = p.Status,
                                CreatedAt = p.CreatedAt,
                                PatientName = pat.FullName,
                                PatientGender = pat.Gender,
                                PatientDOB = pat.DOB,
                                PatientCode = pat.PatientCode,
                                PatientAllergies = pat.Allergy ?? "Không",
                                DoctorName = doc.FullName,
                                Diagnosis = mr != null ? mr.Diagnosis : "Khám sức khỏe tổng quát",
                                DoctorNotes = mr != null ? mr.Notes : ""
                            };

                var list = query.ToList();
                foreach (var dto in list)
                {
                    dto.Items = GetPrescriptionItems(dto.PrescriptionID);
                }
                return list;
            }
        }

        public List<PrescriptionItemDTO> GetPrescriptionItems(int prescriptionId)
        {
            using (var context = new ClinicDbContext())
            {
                var query = from pd in context.PrescriptionDetails
                            join m in context.Medicines on pd.MedicineID equals m.MedicineID
                            where pd.PrescriptionID == prescriptionId
                            select new PrescriptionItemDTO
                            {
                                DetailID = pd.DetailID,
                                PrescriptionID = pd.PrescriptionID ?? 0,
                                MedicineID = pd.MedicineID ?? 0,
                                Quantity = pd.Quantity ?? 0,
                                Dosage = pd.Dosage,
                                MedicineName = m.Name,
                                MedicineUnit = m.Unit,
                                BatchNumber = m.BatchNumber ?? "",
                                Price = m.Price ?? 0
                            };

                return query.ToList();
            }
        }

        public bool UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            using (var context = new ClinicDbContext())
            {
                var presc = context.Prescriptions.Find(prescriptionId);
                if (presc != null)
                {
                    presc.Status = status;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
        }

        private void SeedSamplePrescriptionsIfEmpty()
        {
            try
            {
                using (var context = new ClinicDbContext())
                {
                    if (context.Prescriptions.Any()) return;

                    var patient = context.Patients.OrderBy(p => p.PatientID).FirstOrDefault();
                    var doctor = context.Employees
                        .Join(context.Roles, emp => emp.RoleID, role => role.RoleID, (emp, role) => new { emp, role })
                        .Where(x => x.role.RoleName == "Doctor")
                        .Select(x => x.emp)
                        .OrderBy(emp => emp.EmployeeID)
                        .FirstOrDefault();
                    var medicine = context.Medicines.OrderBy(m => m.MedicineID).FirstOrDefault();

                    if (patient == null || doctor == null || medicine == null) return;

                    // Insert encounters
                    var enc1 = new Encounter { PatientID = patient.PatientID, DoctorID = doctor.EmployeeID, StartTime = DateTime.Now, CreatedAt = DateTime.Now, Status = "Chờ cấp thuốc" };
                    var enc2 = new Encounter { PatientID = patient.PatientID, DoctorID = doctor.EmployeeID, StartTime = DateTime.Now, CreatedAt = DateTime.Now, Status = "Chờ cấp thuốc" };
                    context.Encounters.AddRange(enc1, enc2);
                    context.SaveChanges();

                    // Insert medical records
                    var mr1 = new MedicalRecord { EncounterID = enc1.EncounterID, Diagnosis = "Viêm họng cấp", Notes = "Uống nước ấm, nghỉ ngơi đầy đủ", CreatedAt = DateTime.Now };
                    var mr2 = new MedicalRecord { EncounterID = enc2.EncounterID, Diagnosis = "Suy nhược cơ thể", Notes = "Hạn chế thức khuya, uống nhiều nước", CreatedAt = DateTime.Now };
                    context.MedicalRecords.AddRange(mr1, mr2);

                    // Insert prescriptions
                    var presc1 = new Prescription { EncounterID = enc1.EncounterID, DoctorID = doctor.EmployeeID, Status = "Chờ cấp phát", CreatedAt = DateTime.Now };
                    var presc2 = new Prescription { EncounterID = enc2.EncounterID, DoctorID = doctor.EmployeeID, Status = "Đang chuẩn bị", CreatedAt = DateTime.Now };
                    context.Prescriptions.AddRange(presc1, presc2);
                    context.SaveChanges();

                    var secondMed = context.Medicines.Where(m => m.MedicineID != medicine.MedicineID).OrderBy(m => m.MedicineID).FirstOrDefault() ?? medicine;

                    // Insert details
                    var details = new[]
                    {
                        new PrescriptionDetail { PrescriptionID = presc1.PrescriptionID, MedicineID = medicine.MedicineID, Quantity = 10, Dosage = "Ngày uống 2 lần, mỗi lần 1 viên sau ăn" },
                        new PrescriptionDetail { PrescriptionID = presc1.PrescriptionID, MedicineID = secondMed.MedicineID, Quantity = 15, Dosage = "Ngày uống 1 lần, mỗi lần 1 viên sáng" },
                        new PrescriptionDetail { PrescriptionID = presc2.PrescriptionID, MedicineID = medicine.MedicineID, Quantity = 20, Dosage = "Ngày uống 2 lần, mỗi lần 1 viên sau ăn" }
                    };
                    context.PrescriptionDetails.AddRange(details);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error seeding prescriptions: " + ex.Message);
            }
        }
    }
}
