using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class PrescriptionDAL
    {
        public async Task<List<PrescriptionDTO>> GetPendingPrescriptions()
        {
            await SeedSamplePrescriptionsIfEmpty();

            using var context = DbContextProvider.CreateContext();
            var list = await context.Prescriptions
                .Where(p => p.Status != "Completed" && p.Status != "Đã cấp phát")
                .OrderByDescending(p => p.CreatedAt)
                .Select(p => new PrescriptionDTO
                {
                    PrescriptionID = p.PrescriptionID,
                    EncounterID = p.EncounterID,
                    DoctorID = p.DoctorID,
                    Status = p.Status,
                    CreatedAt = p.CreatedAt,
                    PatientName = p.Encounter.Patient.FullName ?? "",
                    PatientGender = p.Encounter.Patient.Gender ?? "",
                    PatientDOB = p.Encounter.Patient.DOB,
                    PatientCode = p.Encounter.Patient.PatientCode ?? "",
                    PatientAllergies = p.Encounter.Patient.Allergy ?? "Không",
                    DoctorName = p.Encounter.Doctor.FullName ?? "",
                    Diagnosis = p.Encounter.MedicalRecord.Diagnosis ?? "Khám sức khỏe tổng quát",
                    DoctorNotes = p.Encounter.MedicalRecord.Notes ?? ""
                })
                .ToListAsync();

            foreach (var dto in list)
                dto.Items = await GetPrescriptionItems(dto.PrescriptionID);

            return list;
        }

        public async Task<List<PrescriptionItemDTO>> GetPrescriptionItems(int prescriptionId)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.PrescriptionDetails
                .Where(pd => pd.PrescriptionID == prescriptionId)
                .Select(pd => new PrescriptionItemDTO
                {
                    DetailID = pd.DetailID,
                    PrescriptionID = pd.PrescriptionID,
                    MedicineID = pd.MedicineID,
                    Quantity = pd.Quantity,
                    Dosage = pd.Dosage ?? "",
                    MedicineName = pd.Medicine.Name ?? "",
                    MedicineUnit = pd.Medicine.Unit ?? "",
                    BatchNumber = pd.Medicine.BatchNumber ?? "",
                    Price = pd.Medicine.Price
                })
                .ToListAsync();
        }

        public async Task<bool> UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Prescriptions
                .FirstOrDefaultAsync(p => p.PrescriptionID == prescriptionId);

            if (entity == null) return false;

            entity.Status = status;
            return await context.SaveChangesAsync() > 0;
        }

        private async Task SeedSamplePrescriptionsIfEmpty()
        {
            using var context = DbContextProvider.CreateContext();

            if (await context.Prescriptions.AnyAsync()) return;

            var patient = await context.Patients.FirstOrDefaultAsync();
            var doctor = await context.Employees
                .FirstOrDefaultAsync(e => e.Role.RoleName == "Doctor");
            var medicine = await context.Medicines.FirstOrDefaultAsync();

            if (patient == null || doctor == null || medicine == null) return;

            var secondMedicine = await context.Medicines
                .FirstOrDefaultAsync(m => m.MedicineID != medicine.MedicineID);
            secondMedicine ??= medicine;

            // Encounter 1
            var encounter1 = new Encounter
            {
                PatientID = patient.PatientID,
                DoctorID = doctor.EmployeeID,
                StartTime = DateTime.Now,
                Status = "Chờ cấp thuốc"
            };
            context.Encounters.Add(encounter1);
            await context.SaveChangesAsync();

            context.MedicalRecords.Add(new MedicalRecord
            {
                EncounterID = encounter1.EncounterID,
                Diagnosis = "Viêm họng cấp",
                Notes = "Uống nước ấm, nghỉ ngơi đầy đủ"
            });

            var presc1 = new Prescription
            {
                EncounterID = encounter1.EncounterID,
                DoctorID = doctor.EmployeeID,
                Status = "Chờ cấp phát",
                CreatedAt = DateTime.Now
            };
            context.Prescriptions.Add(presc1);
            await context.SaveChangesAsync();

            context.PrescriptionDetails.AddRange(
                new PrescriptionDetail
                {
                    PrescriptionID = presc1.PrescriptionID,
                    MedicineID = medicine.MedicineID,
                    Quantity = 10,
                    Dosage = "Ngày uống 2 lần, mỗi lần 1 viên sau ăn"
                },
                new PrescriptionDetail
                {
                    PrescriptionID = presc1.PrescriptionID,
                    MedicineID = secondMedicine.MedicineID,
                    Quantity = 15,
                    Dosage = "Ngày uống 1 lần, mỗi lần 1 viên sáng"
                }
            );

            // Encounter 2
            var encounter2 = new Encounter
            {
                PatientID = patient.PatientID,
                DoctorID = doctor.EmployeeID,
                StartTime = DateTime.Now,
                Status = "Chờ cấp thuốc"
            };
            context.Encounters.Add(encounter2);
            await context.SaveChangesAsync();

            context.MedicalRecords.Add(new MedicalRecord
            {
                EncounterID = encounter2.EncounterID,
                Diagnosis = "Suy nhược cơ thể",
                Notes = "Hạn chế thức khuya, uống nhiều nước"
            });

            var presc2 = new Prescription
            {
                EncounterID = encounter2.EncounterID,
                DoctorID = doctor.EmployeeID,
                Status = "Đang chuẩn bị",
                CreatedAt = DateTime.Now
            };
            context.Prescriptions.Add(presc2);
            await context.SaveChangesAsync();

            context.PrescriptionDetails.Add(new PrescriptionDetail
            {
                PrescriptionID = presc2.PrescriptionID,
                MedicineID = medicine.MedicineID,
                Quantity = 20,
                Dosage = "Ngày uống 2 lần, mỗi lần 1 viên sau ăn"
            });

            await context.SaveChangesAsync();
        }
    }
}