using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.DataContext
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext()
        {
        }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AuditLogDetail> AuditLogDetails { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicalFile> ClinicalFiles { get; set; }
        public DbSet<ClinicalService> ClinicalServices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dispense> Dispenses { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<EncounterService> EncounterServices { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<ImagingFile> ImagingFiles { get; set; }
        public DbSet<ImagingRequest> ImagingRequests { get; set; }
        public DbSet<ImagingResult> ImagingResults { get; set; }
        public DbSet<ImagingService> ImagingServices { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<LabRequest> LabRequests { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalRecordFile> MedicalRecordFiles { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientIdentifier> PatientIdentifiers { get; set; }
        public DbSet<PatientInsurance> PatientInsurances { get; set; }
        public DbSet<PatientQueue> PatientQueues { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<QueueHistory> QueueHistories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString
                ?? ConfigurationManager.ConnectionStrings["ClinicDB"]?.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().ToTable("Appointments").HasKey(e => e.AppointmentID);
            modelBuilder.Entity<AuditLog>().ToTable("AuditLogs").HasKey(e => e.LogID);
            modelBuilder.Entity<AuditLogDetail>().ToTable("AuditLogDetails").HasKey(e => e.DetailID);
            modelBuilder.Entity<ClinicalFile>().ToTable("Files").HasKey(e => e.FileID);
            modelBuilder.Entity<ClinicalService>().ToTable("Services").HasKey(e => e.ServiceID);
            modelBuilder.Entity<Department>().ToTable("Departments").HasKey(e => e.DepartmentID);
            modelBuilder.Entity<Dispense>().ToTable("Dispense").HasKey(e => e.DispenseID);
            modelBuilder.Entity<DoctorSchedule>().ToTable("DoctorSchedules").HasKey(e => e.ScheduleID);
            modelBuilder.Entity<Employee>().ToTable("Employees").HasKey(e => e.EmployeeID);
            modelBuilder.Entity<EmployeeShift>().ToTable("EmployeeShifts").HasKey(e => e.ID);
            modelBuilder.Entity<Encounter>().ToTable("Encounters").HasKey(e => e.EncounterID);
            modelBuilder.Entity<EncounterService>().ToTable("EncounterServices").HasKey(e => e.EncounterServiceID);
            modelBuilder.Entity<FollowUp>().ToTable("FollowUps").HasKey(e => e.FollowUpID);
            modelBuilder.Entity<ImagingFile>().ToTable("ImagingFiles").HasKey(e => e.FileID);
            modelBuilder.Entity<ImagingRequest>().ToTable("ImagingRequests").HasKey(e => e.ImagingRequestID);
            modelBuilder.Entity<ImagingResult>().ToTable("ImagingResults").HasKey(e => e.ImagingResultID);
            modelBuilder.Entity<ImagingService>().ToTable("ImagingServices").HasKey(e => e.ImagingServiceID);
            modelBuilder.Entity<Invoice>().ToTable("Invoices").HasKey(e => e.InvoiceID);
            modelBuilder.Entity<InvoiceDetail>().ToTable("InvoiceDetails").HasKey(e => e.DetailID);
            modelBuilder.Entity<LabRequest>().ToTable("LabRequests").HasKey(e => e.LabID);
            modelBuilder.Entity<LabResult>().ToTable("LabResults").HasKey(e => e.ResultID);
            modelBuilder.Entity<MedicalRecord>().ToTable("MedicalRecords").HasKey(e => e.RecordID);
            modelBuilder.Entity<MedicalRecordFile>().ToTable("MedicalRecordFiles").HasKey(e => e.FileID);
            modelBuilder.Entity<Medicine>().ToTable("Medicines").HasKey(e => e.MedicineID);
            modelBuilder.Entity<Notification>().ToTable("Notifications").HasKey(e => e.NotificationID);
            modelBuilder.Entity<Patient>().ToTable("Patients").HasKey(e => e.PatientID);
            modelBuilder.Entity<PatientIdentifier>().ToTable("PatientIdentifiers").HasKey(e => e.IdentifierID);
            modelBuilder.Entity<PatientInsurance>().ToTable("PatientInsurance").HasKey(e => e.InsuranceID);
            modelBuilder.Entity<PatientQueue>().ToTable("PatientQueues").HasKey(e => e.QueueID);
            modelBuilder.Entity<Payment>().ToTable("Payments").HasKey(e => e.PaymentID);
            modelBuilder.Entity<PaymentDetail>().ToTable("PaymentDetails").HasKey(e => e.PaymentDetailID);
            modelBuilder.Entity<Prescription>().ToTable("Prescriptions").HasKey(e => e.PrescriptionID);
            modelBuilder.Entity<PrescriptionDetail>().ToTable("PrescriptionDetails").HasKey(e => e.DetailID);
            modelBuilder.Entity<QueueHistory>().ToTable("QueueHistory").HasKey(e => e.HistoryID);
            modelBuilder.Entity<Role>().ToTable("Roles").HasKey(e => e.RoleID);
            modelBuilder.Entity<Room>().ToTable("Rooms").HasKey(e => e.RoomID);
            modelBuilder.Entity<Session>().ToTable("Sessions").HasKey(e => e.SessionID);
            modelBuilder.Entity<Shift>().ToTable("Shifts").HasKey(e => e.ShiftID);
            modelBuilder.Entity<Transfer>().ToTable("Transfers").HasKey(e => e.TransferID);
            modelBuilder.Entity<User>().ToTable("Users").HasKey(e => e.UserID);
            modelBuilder.Entity<VitalSign>().ToTable("VitalSigns").HasKey(e => e.VitalID);

            // Precision mapping for EF Core
            modelBuilder.Entity<Dispense>().Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<EncounterService>().Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<ImagingService>().Property(e => e.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Invoice>().Property(e => e.Total).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Medicine>().Property(e => e.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Payment>().Property(e => e.Amount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PaymentDetail>().Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<PaymentDetail>().Property(e => e.Amount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<VitalSign>().Property(e => e.Temperature).HasColumnType("decimal(4,1)");
            modelBuilder.Entity<VitalSign>().Property(e => e.Weight).HasColumnType("decimal(5,2)");
        }
    }
}
