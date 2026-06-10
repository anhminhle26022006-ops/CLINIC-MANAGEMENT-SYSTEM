using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Models;
using DTO;
using DTO.Doctor;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Doctor
{
    public class DoctorWorkspaceDAL
    {
        private readonly CMSDbContext _context;

        public DoctorWorkspaceDAL(CMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // ==================== Core Methods ====================

        public int ResolveDoctorId(UserDTO user)
        {
            if (user?.EmployeeID > 0)
                return user.EmployeeID;

            if (user?.UserID > 0)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.UserId == user.UserID);
                if (employee != null)
                    return employee.EmployeeId;
            }

            var fallback = _context.Employees
                .Include(e => e.Role)
                .FirstOrDefault(e => e.Role != null && e.Role.RoleName == "Doctor");
            return fallback?.EmployeeId ?? 0;
        }

        public DoctorDashboardDTO GetDashboard(int doctorId, DateTime date)
        {
            EnsureDemoData(doctorId, date);

            DateTime start = date.Date;
            DateTime end = start.AddDays(1);
            DateOnly startDateOnly = DateOnly.FromDateTime(start);

            var appointmentsToday = _context.Appointments
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate >= start && a.AppointmentDate < end)
                .ToList();

            var waitingStatuses = new[] { "Waiting", "Chờ tiếp nhận", "Chờ khám" };
            var examiningStatuses = new[] { "Examining", "Đang khám", "InProgress" };
            var completedStatuses = new[] { "Completed", "Hoàn thành" };

            int pendingLab = _context.LabRequests
                .Count(lr => lr.DoctorId == doctorId && lr.Status != "Completed" && lr.Status != "Hoàn thành");
            int pendingImaging = _context.ImagingRequests
                .Count(ir => ir.DoctorId == doctorId && ir.Status != "Completed" && ir.Status != "Hoàn thành");
            int pendingPrescriptions = _context.Prescriptions
                .Count(p => p.DoctorId == doctorId && p.Status != "Completed" && p.Status != "Đã cấp phát");

            int openAssignments = _context.Set<WorkAssignment>()
                .Count(wa => wa.EmployeeId == doctorId
                    && wa.WorkDate == startDateOnly
                    && (wa.Status == "Open" || wa.Status == "InProgress" || wa.Status == "Đang làm"));

            return new DoctorDashboardDTO
            {
                TodayAppointments = appointmentsToday.Count,
                WaitingCount = appointmentsToday.Count(a => waitingStatuses.Contains(a.Status)),
                ExaminingCount = appointmentsToday.Count(a => examiningStatuses.Contains(a.Status)),
                CompletedCount = appointmentsToday.Count(a => completedStatuses.Contains(a.Status)),
                PendingLabRequests = pendingLab,
                PendingImagingRequests = pendingImaging,
                PendingPrescriptions = pendingPrescriptions,
                OpenAssignments = openAssignments
            };
        }

        public List<DoctorAppointmentDTO> GetAppointments(int doctorId, DateTime date)
        {
            EnsureDemoData(doctorId, date);
            DateTime start = date.Date;
            DateTime end = start.AddDays(1);

            var appointments = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Department)
                .Include(a => a.Room)
                .Include(a => a.Encounters)
                .Where(a => a.DoctorId == doctorId && a.AppointmentDate >= start && a.AppointmentDate < end)
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.AppointmentId)
                .ToList();

            var result = new List<DoctorAppointmentDTO>();

            foreach (var a in appointments)
            {
                var encounter = a.Encounters.FirstOrDefault();
                PatientQueue queue = null;
                VitalSign vital = null;

                if (encounter != null)
                {
                    queue = _context.PatientQueues
                        .Where(q => q.EncounterId == encounter.EncounterId)
                        .OrderByDescending(q => q.QueueId)
                        .FirstOrDefault();
                    vital = _context.VitalSigns
                        .Where(v => v.EncounterId == encounter.EncounterId)
                        .OrderByDescending(v => v.CreatedAt)
                        .ThenByDescending(v => v.VitalId)
                        .FirstOrDefault();
                }

                result.Add(MapToDoctorAppointmentDTO(a, a.Patient, a.Department, a.Room, encounter, queue, vital));
            }

            return result;
        }

        public DoctorAppointmentDTO GetAppointmentByAppointmentId(int doctorId, int appointmentId)
        {
            var appointment = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Department)
                .Include(a => a.Room)
                .Include(a => a.Encounters)
                .FirstOrDefault(a => a.AppointmentId == appointmentId && (doctorId == 0 || a.DoctorId == doctorId));

            if (appointment == null) return null;

            var encounter = appointment.Encounters.FirstOrDefault();
            PatientQueue queue = null;
            VitalSign vital = null;

            if (encounter != null)
            {
                queue = _context.PatientQueues
                    .Where(q => q.EncounterId == encounter.EncounterId)
                    .OrderByDescending(q => q.QueueId)
                    .FirstOrDefault();
                vital = _context.VitalSigns
                    .Where(v => v.EncounterId == encounter.EncounterId)
                    .OrderByDescending(v => v.CreatedAt)
                    .ThenByDescending(v => v.VitalId)
                    .FirstOrDefault();
            }

            return MapToDoctorAppointmentDTO(appointment, appointment.Patient, appointment.Department, appointment.Room, encounter, queue, vital);
        }

        public DoctorAppointmentDTO GetAppointmentByEncounterId(int doctorId, int encounterId)
        {
            var encounter = _context.Encounters
                .Include(e => e.Appointment)
                .FirstOrDefault(e => e.EncounterId == encounterId && (doctorId == 0 || e.DoctorId == doctorId));

            if (encounter?.Appointment == null) return null;
            return GetAppointmentByAppointmentId(doctorId, encounter.Appointment.AppointmentId);
        }

        public DoctorMedicalRecordSaveDTO GetMedicalRecord(int encounterId)
        {
            var record = _context.MedicalRecords
                .Where(m => m.EncounterId == encounterId)
                .OrderByDescending(m => m.CreatedAt)
                .ThenByDescending(m => m.RecordId)
                .FirstOrDefault();

            if (record == null) return null;

            return new DoctorMedicalRecordSaveDTO
            {
                EncounterID = encounterId,
                ChiefComplaint = record.ChiefComplaint ?? "",
                Symptoms = record.Symptoms ?? "",
                Diagnosis = record.Diagnosis ?? "",
                ICDCode = record.Icdcode ?? "",
                Conclusion = record.Conclusion ?? "",
                Notes = record.Notes ?? ""
            };
        }

        public List<DoctorHistoryDTO> GetHistory(int patientId, int currentEncounterId)
        {
            var encounters = _context.Encounters
                .Include(e => e.MedicalRecords)
                .Include(e => e.Doctor)
                .Where(e => e.PatientId == patientId && e.EncounterId != currentEncounterId)
                .OrderByDescending(e => e.StartTime)
                .Take(20)
                .ToList();

            var history = new List<DoctorHistoryDTO>();

            foreach (var en in encounters)
            {
                var latestRecord = en.MedicalRecords.OrderByDescending(m => m.CreatedAt).FirstOrDefault();
                string diagnosis = latestRecord?.Diagnosis ?? "";

                var prescriptionSummary = string.Join(", ",
                    _context.Prescriptions
                        .Where(p => p.EncounterId == en.EncounterId)
                        .SelectMany(p => p.PrescriptionDetails)
                        .Select(pd => pd.Medicine.Name)
                        .ToList());

                history.Add(new DoctorHistoryDTO
                {
                    EncounterID = en.EncounterId,
                    Date = en.StartTime ?? latestRecord?.CreatedAt ?? DateTime.MinValue,
                    Diagnosis = diagnosis,
                    DoctorName = en.Doctor?.FullName ?? "",
                    Status = en.Status ?? "",
                    PrescriptionSummary = prescriptionSummary
                });
            }

            return history;
        }

        public List<DoctorLabResultDTO> GetLabResults(int encounterId)
        {
            var requests = _context.LabRequests
                .Include(lr => lr.LabResults)
                .Where(lr => lr.EncounterId == encounterId)
                .OrderByDescending(lr => lr.CreatedAt)
                .ThenByDescending(lr => lr.LabId)
                .ToList();

            var result = new List<DoctorLabResultDTO>();
            foreach (var lr in requests)
            {
                var lastResult = lr.LabResults.OrderByDescending(r => r.CompletedAt).FirstOrDefault();
                result.Add(new DoctorLabResultDTO
                {
                    LabID = lr.LabId,
                    TestType = lr.TestType ?? "",
                    Status = lr.Status ?? "",
                    ResultText = lastResult?.ResultText ?? "",
                    FileURL = lastResult?.FileUrl ?? "",
                    CompletedAt = lastResult?.CompletedAt
                });
            }

            return result;
        }

        public List<DoctorImagingResultDTO> GetImagingResults(int encounterId)
        {
            var requests = _context.ImagingRequests
                .Include(ir => ir.ImagingService)
                .Include(ir => ir.ImagingResults)
                .Where(ir => ir.EncounterId == encounterId)
                .OrderByDescending(ir => ir.CreatedAt)
                .ThenByDescending(ir => ir.ImagingRequestId)
                .ToList();

            var result = new List<DoctorImagingResultDTO>();
            foreach (var ir in requests)
            {
                var lastResult = ir.ImagingResults.OrderByDescending(r => r.CompletedAt).FirstOrDefault();
                result.Add(new DoctorImagingResultDTO
                {
                    ImagingRequestID = ir.ImagingRequestId,
                    ServiceName = ir.ImagingService?.ServiceName ?? ir.ImagingService?.Modality ?? "Imaging",
                    BodyPart = ir.BodyPart ?? "",
                    Status = ir.Status ?? "",
                    ResultText = lastResult?.ResultText ?? "",
                    ImageURL = lastResult?.ImageUrl ?? "",
                    PDFURL = lastResult?.Pdfurl ?? "",
                    TechnicianNote = lastResult?.TechnicianNote ?? "",
                    CompletedAt = lastResult?.CompletedAt
                });
            }

            return result;
        }

        public List<MedicineDTO> GetMedicines()
        {
            return _context.Medicines
                .Where(m => (m.Stock ?? 0) > 0)
                .OrderBy(m => m.Name)
                .Select(m => new MedicineDTO
                {
                    MedicineID = m.MedicineId,
                    Name = m.Name ?? "",
                    Unit = m.Unit ?? "",
                    Price = m.Price ?? 0,
                    Stock = m.Stock ?? 0,
                    BatchNumber = m.BatchNumber ?? "",
                    ExpiryDate = m.ExpiryDate.HasValue
                        ? m.ExpiryDate.Value.ToDateTime(TimeOnly.MinValue)
                        : DateTime.MinValue
                })
                .ToList();
        }

        public List<PrescriptionDTO> GetDoctorPrescriptions(int doctorId)
        {
            var prescriptions = _context.Prescriptions
                .Include(p => p.Encounter).ThenInclude(e => e.Patient)
                .Include(p => p.Doctor)
                .Include(p => p.PrescriptionDetails).ThenInclude(d => d.Medicine)
                .Where(p => doctorId == 0 || p.DoctorId == doctorId)
                .OrderByDescending(p => p.CreatedAt)
                .ThenByDescending(p => p.PrescriptionId)
                .ToList();

            return prescriptions.Select(p =>
            {
                var record = _context.MedicalRecords.FirstOrDefault(m => m.EncounterId == p.EncounterId);
                return new PrescriptionDTO
                {
                    PrescriptionID = p.PrescriptionId,
                    EncounterID = p.EncounterId ?? 0,
                    DoctorID = p.DoctorId ?? 0,
                    Status = p.Status ?? "",
                    CreatedAt = p.CreatedAt ?? DateTime.MinValue,
                    PatientName = p.Encounter?.Patient?.FullName ?? "",
                    PatientGender = p.Encounter?.Patient?.Gender ?? "",
                    PatientDOB = (p.Encounter != null && p.Encounter.Patient != null && p.Encounter.Patient.Dob.HasValue)
    ? p.Encounter.Patient.Dob.Value.ToDateTime(TimeOnly.MinValue)
    : (DateTime?)null,
                    PatientCode = p.Encounter?.Patient?.PatientCode ?? "",
                    PatientAllergies = p.Encounter?.Patient?.Allergy ?? "",
                    DoctorName = p.Doctor?.FullName ?? "",
                    Diagnosis = record?.Diagnosis ?? "",
                    DoctorNotes = record?.Notes ?? "",
                    Items = p.PrescriptionDetails.Select(d => new PrescriptionItemDTO
                    {
                        DetailID = d.DetailId,
                        PrescriptionID = d.PrescriptionId ?? 0,
                        MedicineID = d.MedicineId ?? 0,
                        Quantity = d.Quantity ?? 0,
                        Dosage = d.Dosage ?? "",
                        Frequency = d.Frequency ?? "",
                        Instruction = d.Instruction ?? "",
                        MedicineName = d.Medicine?.Name ?? "",
                        MedicineUnit = d.Medicine?.Unit ?? "",
                        BatchNumber = d.Medicine?.BatchNumber ?? "",
                        Price = d.Medicine?.Price ?? 0
                    }).ToList()
                };
            }).ToList();
        }

        public bool StartExamination(int appointmentId, int encounterId, int doctorId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                Encounter encounter = null;

                if (encounterId <= 0)
                {
                    var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                    if (appointment == null) throw new Exception("Appointment not found");

                    encounter = new Encounter
                    {
                        AppointmentId = appointmentId,
                        PatientId = appointment.PatientId,
                        DoctorId = doctorId,
                        StartTime = DateTime.Now,
                        Status = "Examining"
                    };
                    _context.Encounters.Add(encounter);
                    _context.SaveChanges();
                    encounterId = encounter.EncounterId;
                }
                else
                {
                    encounter = _context.Encounters.FirstOrDefault(e => e.EncounterId == encounterId);
                    if (encounter == null) throw new Exception("Encounter not found");

                    encounter.StartTime = encounter.StartTime ?? DateTime.Now;
                    encounter.Status = "Examining";
                }

                var appt = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appt != null) appt.Status = "Examining";

                var queue = _context.PatientQueues.FirstOrDefault(q => q.EncounterId == encounterId);
                if (queue != null)
                {
                    queue.Status = "InProgress";
                    queue.CurrentStep = "Dang kham";
                }
                else
                {
                    _context.PatientQueues.Add(new PatientQueue
                    {
                        EncounterId = encounterId,
                        Priority = "Normal",
                        Status = "InProgress",
                        CurrentStep = "Dang kham"
                    });
                }

                var waList = _context.Set<WorkAssignment>().Where(wa =>
                    wa.EncounterId == encounterId && wa.EmployeeId == doctorId &&
                    wa.AssignmentType == "Examination" && (wa.Status == "Open" || wa.Status == "InProgress"))
                    .ToList();
                foreach (var wa in waList) wa.Status = "InProgress";

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool SaveMedicalRecord(DoctorMedicalRecordSaveDTO record)
        {
            var existing = _context.MedicalRecords.FirstOrDefault(m => m.EncounterId == record.EncounterID);
            if (existing != null)
            {
                existing.ChiefComplaint = NullIfEmpty(record.ChiefComplaint);
                existing.Symptoms = NullIfEmpty(record.Symptoms);
                existing.Diagnosis = NullIfEmpty(record.Diagnosis);
                existing.Icdcode = NullIfEmpty(record.ICDCode);
                existing.Conclusion = NullIfEmpty(record.Conclusion);
                existing.Notes = NullIfEmpty(record.Notes);
            }
            else
            {
                _context.MedicalRecords.Add(new MedicalRecord
                {
                    EncounterId = record.EncounterID,
                    ChiefComplaint = NullIfEmpty(record.ChiefComplaint),
                    Symptoms = NullIfEmpty(record.Symptoms),
                    Diagnosis = NullIfEmpty(record.Diagnosis),
                    Icdcode = NullIfEmpty(record.ICDCode),
                    Conclusion = NullIfEmpty(record.Conclusion),
                    Notes = NullIfEmpty(record.Notes),
                    CreatedAt = DateTime.Now
                });
            }

            return _context.SaveChanges() > 0;
        }

        public bool CreateLabRequest(DoctorRequestSaveDTO request)
        {
            var labRequest = new LabRequest
            {
                EncounterId = request.EncounterID,
                DoctorId = request.DoctorID,
                TestType = NullIfEmpty(request.ServiceName),
                Status = "Pending",
                CreatedAt = DateTime.Now
            };
            _context.LabRequests.Add(labRequest);
            _context.SaveChanges();

            CreateTechnicianAssignment(request.EncounterID, "Lab", "Xu ly xet nghiem",
                "LabID: " + labRequest.LabId + " - " + request.ServiceName, request.Priority, "Technician");

            return labRequest.LabId > 0;
        }

        public bool CreateImagingRequest(DoctorRequestSaveDTO request)
        {
            int serviceId = GetOrCreateImagingServiceId(request.ServiceName);
            var imgRequest = new ImagingRequest
            {
                EncounterId = request.EncounterID,
                DoctorId = request.DoctorID,
                ImagingServiceId = serviceId,
                BodyPart = NullIfEmpty(request.Note),
                CreatedAt = DateTime.Now,
                Priority = NullIfEmpty(request.Priority) ?? "Normal",
                Status = "Pending"
            };
            _context.ImagingRequests.Add(imgRequest);
            _context.SaveChanges();

            CreateTechnicianAssignment(request.EncounterID, "Imaging", "Xu ly chan doan hinh anh",
                "ImagingRequestID: " + imgRequest.ImagingRequestId + " - " + request.ServiceName,
                request.Priority, "Technician");

            return imgRequest.ImagingRequestId > 0;
        }

        public int CreatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var pres = new Prescription
                {
                    EncounterId = prescription.EncounterID,
                    DoctorId = prescription.DoctorID,
                    Status = "Issued",
                    CreatedAt = DateTime.Now
                };
                _context.Prescriptions.Add(pres);
                _context.SaveChanges();

                foreach (var item in prescription.Items)
                {
                    _context.PrescriptionDetails.Add(new PrescriptionDetail
                    {
                        PrescriptionId = pres.PrescriptionId,
                        MedicineId = item.MedicineID,
                        Quantity = item.Quantity,
                        Dosage = NullIfEmpty(item.Dosage),
                        Frequency = NullIfEmpty(item.Frequency),
                        Instruction = NullIfEmpty(item.Instruction)
                    });
                }

                var pharmacist = _context.Employees
                    .Include(e => e.Role)
                    .FirstOrDefault(e => e.Role != null && e.Role.RoleName == "Pharmacist");

                if (pharmacist != null)
                {
                    _context.Set<WorkAssignment>().Add(new WorkAssignment
                    {
                        EmployeeId = pharmacist.EmployeeId,
                        RoleId = pharmacist.RoleId,
                        DepartmentId = pharmacist.DepartmentId,
                        EncounterId = prescription.EncounterID,
                        WorkDate = DateOnly.FromDateTime(DateTime.Today),
                        AssignmentType = "Pharmacy",
                        Title = "Cap phat don thuoc",
                        Priority = "Normal",
                        Status = "Open",
                        Notes = "PrescriptionID: " + pres.PrescriptionId
                    });
                }

                _context.SaveChanges();
                transaction.Commit();
                return pres.PrescriptionId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool UpdatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var pres = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == prescription.PrescriptionID);
                if (pres == null) return false;

                pres.Status = string.IsNullOrWhiteSpace(prescription.Note) ? "Issued" : prescription.Note.Trim();

                var oldDetails = _context.PrescriptionDetails.Where(d => d.PrescriptionId == prescription.PrescriptionID);
                _context.PrescriptionDetails.RemoveRange(oldDetails);

                foreach (var item in prescription.Items)
                {
                    _context.PrescriptionDetails.Add(new PrescriptionDetail
                    {
                        PrescriptionId = prescription.PrescriptionID,
                        MedicineId = item.MedicineID,
                        Quantity = item.Quantity,
                        Dosage = NullIfEmpty(item.Dosage),
                        Frequency = NullIfEmpty(item.Frequency),
                        Instruction = NullIfEmpty(item.Instruction)
                    });
                }

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool DeletePrescription(int prescriptionId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var dispenses = _context.Dispenses.Where(d => d.PrescriptionId == prescriptionId);
                _context.Dispenses.RemoveRange(dispenses);

                var details = _context.PrescriptionDetails.Where(d => d.PrescriptionId == prescriptionId);
                _context.PrescriptionDetails.RemoveRange(details);

                var pres = _context.Prescriptions.FirstOrDefault(p => p.PrescriptionId == prescriptionId);
                if (pres != null) _context.Prescriptions.Remove(pres);

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool CompleteExamination(int appointmentId, int encounterId, int doctorId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var appt = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
                if (appt != null) appt.Status = "Completed";

                var encounter = _context.Encounters.FirstOrDefault(e => e.EncounterId == encounterId);
                if (encounter != null)
                {
                    encounter.EndTime = DateTime.Now;
                    encounter.Status = "Completed";
                }

                var queue = _context.PatientQueues.FirstOrDefault(q => q.EncounterId == encounterId);
                if (queue != null)
                {
                    queue.Status = "Completed";
                    queue.CurrentStep = "Hoan thanh";
                }

                var workAssignments = _context.Set<WorkAssignment>().Where(wa =>
                    wa.EncounterId == encounterId && wa.EmployeeId == doctorId &&
                    wa.AssignmentType == "Examination").ToList();
                foreach (var wa in workAssignments)
                {
                    wa.Status = "Completed";
                    wa.CompletedAt = DateTime.Now;
                }

                _context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // ==================== Demo Data ====================

        public void EnsureDemoData(int doctorId, DateTime date)
        {
            if (doctorId <= 0) return;

            DateTime start = date.Date;
            DateTime end = start.AddDays(1);
            DateOnly startDateOnly = DateOnly.FromDateTime(start);

            var existingCount = _context.Appointments.Count(a => a.DoctorId == doctorId && a.AppointmentDate >= start && a.AppointmentDate < end);
            const int target = 14;

            if (existingCount >= target) return;

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                int departmentId = _context.Employees.Where(e => e.EmployeeId == doctorId).Select(e => e.DepartmentId).FirstOrDefault();
                if (departmentId == 0)
                    departmentId = _context.Departments.Select(d => d.DepartmentId).FirstOrDefault();

                int roomId = _context.Rooms.Where(r => r.DepartmentId == departmentId).Select(r => r.RoomId).FirstOrDefault();
                if (roomId == 0)
                    roomId = _context.Rooms.Select(r => r.RoomId).FirstOrDefault();

                var medicineIds = _context.Medicines.Where(m => (m.Stock ?? 0) > 0).Select(m => m.MedicineId).Take(5).ToList();

                string[] names = {
                    "Nguyen Van An", "Tran Thi Bich", "Le Minh Chau", "Pham Van Hung",
                    "Do Thi Kim", "Bui Quoc Huy", "Hoang Thanh Lam", "Vo Minh Quan",
                    "Dang Ngoc Mai", "Phan Gia Bao", "Truong Hai Nam", "Ly Thanh Truc",
                    "Mai Tuan Kiet", "Cao Minh Thu"
                };

                for (int i = existingCount; i < target; i++)
                {
                    string code = "GP1DEMO" + date.ToString("MMdd") + (i + 1).ToString("D2");
                    string patientName = names[i % names.Length];
                    DateTime appointmentTime = start.AddHours(8).AddMinutes(i * 20);
                    string status = i < 7 ? "Waiting" : i < 10 ? "Examining" : "Completed";

                    int patientId = EnsurePatient(code, patientName, i);

                    var appointment = new Appointment
                    {
                        PatientId = patientId,
                        DoctorId = doctorId,
                        DepartmentId = departmentId,
                        RoomId = roomId,
                        AppointmentDate = appointmentTime,
                        Status = status,
                        CreatedAt = DateTime.Now
                    };
                    _context.Appointments.Add(appointment);
                    _context.SaveChanges();

                    var encounter = new Encounter
                    {
                        AppointmentId = appointment.AppointmentId,
                        PatientId = patientId,
                        DoctorId = doctorId,
                        StartTime = status != "Waiting" ? appointmentTime : null,
                        EndTime = status == "Completed" ? appointmentTime.AddMinutes(25) : null,
                        Status = status
                    };
                    _context.Encounters.Add(encounter);
                    _context.SaveChanges();

                    _context.PatientQueues.Add(new PatientQueue
                    {
                        EncounterId = encounter.EncounterId,
                        Priority = i % 5 == 0 ? "High" : "Normal",
                        Status = status == "Waiting" ? "Waiting" : status == "Examining" ? "InProgress" : "Completed",
                        CurrentStep = status == "Waiting" ? "Cho kham" : status == "Examining" ? "Dang kham" : "Hoan thanh"
                    });

                    _context.VitalSigns.Add(new VitalSign
                    {
                        EncounterId = encounter.EncounterId,
                        Temperature = 36.4m + (i % 4) * 0.2m,
                        BloodPressure = (118 + i % 8) + "/80",
                        HeartRate = 68 + i,
                        Spo2 = 96 + i % 4,
                        Weight = 52 + i,
                        Height = 158 + i % 12,
                        Notes = "Sinh hieu demo GP1"
                    });

                    _context.MedicalRecords.Add(new MedicalRecord
                    {
                        EncounterId = encounter.EncounterId,
                        ChiefComplaint = "Dau dau, ho, met moi",
                        Symptoms = "Ho nhe, sot nhe, dau hong",
                        Diagnosis = i % 3 == 0 ? "Viem hong cap" : i % 3 == 1 ? "Cam cum mua" : "Roi loan tieu hoa nhe",
                        Icdcode = "J06.9",
                        Conclusion = "Dieu tri ngoai tru",
                        Notes = "Khong bien chung",
                        CreatedAt = DateTime.Now
                    });

                    if (i % 2 == 0)
                    {
                        var labReq = new LabRequest
                        {
                            EncounterId = encounter.EncounterId,
                            DoctorId = doctorId,
                            TestType = i % 4 == 0 ? "Cong thuc mau" : "Duong huyet",
                            Status = i % 4 == 0 ? "Completed" : "Pending",
                            CreatedAt = DateTime.Now
                        };
                        _context.LabRequests.Add(labReq);
                        _context.SaveChanges();

                        if (i % 4 == 0)
                        {
                            _context.LabResults.Add(new LabResult
                            {
                                LabId = labReq.LabId,
                                ResultText = "WBC binh thuong; RBC binh thuong; HGB 135 g/L",
                                CompletedAt = DateTime.Now
                            });
                        }
                    }

                    if (i % 3 == 0)
                    {
                        string serviceName = i % 2 == 0 ? "X-quang nguc" : "Sieu am bung";
                        int imagingServiceId = GetOrCreateImagingServiceId(serviceName);

                        var imgReq = new ImagingRequest
                        {
                            EncounterId = encounter.EncounterId,
                            DoctorId = doctorId,
                            ImagingServiceId = imagingServiceId,
                            BodyPart = i % 2 == 0 ? "Nguc" : "Bung",
                            CreatedAt = DateTime.Now,
                            Priority = i % 6 == 0 ? "High" : "Normal",
                            Status = i % 6 == 0 ? "Completed" : "Pending"
                        };
                        _context.ImagingRequests.Add(imgReq);
                        _context.SaveChanges();

                        if (i % 6 == 0)
                        {
                            _context.ImagingResults.Add(new ImagingResult
                            {
                                ImagingRequestId = imgReq.ImagingRequestId,
                                ResultText = "Khong ghi nhan bat thuong cap tinh",
                                TechnicianNote = "Anh dat chat luong demo",
                                CompletedAt = DateTime.Now
                            });
                        }
                    }

                    if (medicineIds.Count > 0 && i >= 4)
                    {
                        var pres = new Prescription
                        {
                            EncounterId = encounter.EncounterId,
                            DoctorId = doctorId,
                            Status = "Issued",
                            CreatedAt = DateTime.Now
                        };
                        _context.Prescriptions.Add(pres);
                        _context.SaveChanges();

                        int first = medicineIds[i % medicineIds.Count];
                        int second = medicineIds[(i + 1) % medicineIds.Count];

                        _context.PrescriptionDetails.AddRange(
                            new PrescriptionDetail
                            {
                                PrescriptionId = pres.PrescriptionId,
                                MedicineId = first,
                                Quantity = 10 + i,
                                Dosage = "1 vien/lần",
                                Frequency = "2 lan/ngay",
                                Instruction = "Uong sau an"
                            },
                            new PrescriptionDetail
                            {
                                PrescriptionId = pres.PrescriptionId,
                                MedicineId = second,
                                Quantity = 5 + i,
                                Dosage = "1 vien/lần",
                                Frequency = "Khi can",
                                Instruction = "Dung khi sot hoac dau"
                            }
                        );
                    }

                    _context.Set<WorkAssignment>().Add(new WorkAssignment
                    {
                        EmployeeId = doctorId,
                        RoleId = _context.Employees.Where(e => e.EmployeeId == doctorId).Select(e => e.RoleId).FirstOrDefault(),
                        DepartmentId = departmentId,
                        RoomId = roomId,
                        EncounterId = encounter.EncounterId,
                        WorkDate = startDateOnly,
                        AssignmentType = "Examination",
                        Title = "Kham va cap nhat benh an",
                        Priority = i % 5 == 0 ? "High" : "Normal",
                        Status = status == "Completed" ? "Completed" : status == "Examining" ? "InProgress" : "Open",
                        Notes = "Demo GP1"
                    });

                    _context.SaveChanges();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        // ==================== Private Helpers ====================

        private DoctorAppointmentDTO MapToDoctorAppointmentDTO(
            Appointment a, Patient p, Department d, Room r, Encounter en,
            PatientQueue queue, VitalSign vital)
        {
            var dto = new DoctorAppointmentDTO
            {
                AppointmentID = a.AppointmentId,
                EncounterID = en?.EncounterId ?? 0,
                PatientID = a.PatientId ?? 0,
                DoctorID = a.DoctorId ?? 0,
                PatientCode = p?.PatientCode ?? "",
                PatientName = p?.FullName ?? "",
                Gender = p?.Gender ?? "",
                DOB = (p != null && p.Dob.HasValue)
    ? p.Dob.Value.ToDateTime(TimeOnly.MinValue)
    : (DateTime?) null,
                Allergy = p?.Allergy ?? "",
                DepartmentName = d?.DepartmentName ?? "",
                RoomCode = r?.RoomCode ?? "",
                AppointmentDate = a.AppointmentDate ?? DateTime.MinValue,
                Status = a.Status ?? "",
                QueueStatus = queue?.Status ?? "",
                CurrentStep = queue?.CurrentStep ?? "",
                Temperature = vital?.Temperature ?? 0,
                BloodPressure = vital?.BloodPressure ?? "",
                HeartRate = vital?.HeartRate ?? 0,
                SpO2 = vital?.Spo2 ?? 0,
                Weight = vital?.Weight ?? 0,
                Height = vital?.Height ?? 0
            };

            dto.VitalSummary = BuildVitalSummary(dto);
            return dto;
        }

        private static string BuildVitalSummary(DoctorAppointmentDTO dto)
        {
            var parts = new List<string>();
            if (dto.Temperature > 0)
                parts.Add(dto.Temperature.ToString("0.0") + " C");
            if (!string.IsNullOrWhiteSpace(dto.BloodPressure))
                parts.Add(dto.BloodPressure);
            if (dto.HeartRate > 0)
                parts.Add(dto.HeartRate + " bpm");
            if (dto.SpO2 > 0)
                parts.Add("SpO2 " + dto.SpO2 + "%");
            return parts.Count == 0 ? "Chua co sinh hieu" : string.Join(" | ", parts);
        }

        private int EnsurePatient(string code, string fullName, int index)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.PatientCode == code);
            if (patient != null) return patient.PatientId;

            var newPatient = new Patient
            {
                PatientCode = code,
                FullName = fullName,
                Gender = index % 2 == 0 ? "Nam" : "Nu",
                Dob = DateOnly.FromDateTime(DateTime.Today.AddYears(-25 - index).AddDays(index * 11)),
                Phone = "0909" + (100000 + index).ToString(),
                Address = "Demo GP1",
                BloodType = index % 3 == 0 ? "A+" : index % 3 == 1 ? "O+" : "B+",
                Allergy = index % 4 == 0 ? "Hai san" : "Khong co",
                CreatedAt = DateTime.Now
            };
            _context.Patients.Add(newPatient);
            _context.SaveChanges();
            return newPatient.PatientId;
        }

        private int GetOrCreateImagingServiceId(string serviceName)
        {
            var service = _context.ImagingServices.FirstOrDefault(s => s.ServiceName == serviceName);
            if (service != null) return service.ImagingServiceId;

            string modality = InferModality(serviceName);
            var newService = new ImagingService
            {
                ServiceName = serviceName,
                Modality = modality,
                Price = 0,
                IsActive = true
            };
            _context.ImagingServices.Add(newService);
            _context.SaveChanges();
            return newService.ImagingServiceId;
        }

        private static string InferModality(string serviceName)
        {
            string value = (serviceName ?? "").ToLowerInvariant();
            if (value.Contains("ct")) return "CT";
            if (value.Contains("mri")) return "MRI";
            if (value.Contains("x-quang") || value.Contains("xray") || value.Contains("x-ray")) return "X-Ray";
            if (value.Contains("sieu am") || value.Contains("siêu âm")) return "Ultrasound";
            return "Imaging";
        }

        private void CreateTechnicianAssignment(int encounterId, string type, string title, string notes, string priority, string roleName)
        {
            var tech = _context.Employees
                .Include(e => e.Role)
                .FirstOrDefault(e => e.Role != null && e.Role.RoleName == roleName);
            if (tech == null) return;

            _context.Set<WorkAssignment>().Add(new WorkAssignment
            {
                EmployeeId = tech.EmployeeId,
                RoleId = tech.RoleId,
                DepartmentId = tech.DepartmentId,
                EncounterId = encounterId,
                WorkDate = DateOnly.FromDateTime(DateTime.Today),
                AssignmentType = type,
                Title = title,
                Priority = string.IsNullOrWhiteSpace(priority) ? "Normal" : priority,
                Status = "Open",
                Notes = notes ?? ""
            });
            _context.SaveChanges();
        }

        private static string NullIfEmpty(string value) =>
            string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}