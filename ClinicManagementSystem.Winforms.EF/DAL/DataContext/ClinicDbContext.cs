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
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            string connectionString =
                ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString
                ?? ConfigurationManager.ConnectionStrings["ClinicDB"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DbConnection' or 'ClinicDB' not found in App.config.");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AuditLogs");
                entity.HasKey(e => e.LogID);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<AuditLogDetail>(entity =>
            {
                entity.ToTable("AuditLogDetails");
                entity.HasKey(e => e.DetailID);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");
                entity.HasKey(e => e.AppointmentID);
                entity.Property(e => e.AppointmentUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ClinicalFile>(entity =>
            {
                entity.ToTable("Files");
                entity.HasKey(e => e.FileID);
                entity.Property(e => e.UploadedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ClinicalService>(entity =>
            {
                entity.ToTable("Services");
                entity.HasKey(e => e.ServiceID);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments");
                entity.HasKey(e => e.DepartmentID);
            });

            modelBuilder.Entity<Dispense>(entity =>
            {
                entity.ToTable("Dispense");
                entity.HasKey(e => e.DispenseID);
                entity.Property(e => e.DispenseUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<DoctorSchedule>(entity =>
            {
                entity.ToTable("DoctorSchedules");
                entity.HasKey(e => e.ScheduleID);
                entity.Property(e => e.WorkDate).HasColumnType("date");
                entity.Property(e => e.StartTime).HasColumnType("time");
                entity.Property(e => e.EndTime).HasColumnType("time");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
                entity.HasKey(e => e.EmployeeID);
                entity.Property(e => e.EmployeeUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.HireDate).HasColumnType("date");
                entity.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<EmployeeShift>(entity =>
            {
                entity.ToTable("EmployeeShifts");
                entity.HasKey(e => e.ID);
                entity.Property(e => e.WorkDate).HasColumnType("date");
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.ToTable("Encounters");
                entity.HasKey(e => e.EncounterID);
                entity.Property(e => e.EncounterUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<EncounterService>(entity =>
            {
                entity.ToTable("EncounterServices");
                entity.HasKey(e => e.EncounterServiceID);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.OrderedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<FollowUp>(entity =>
            {
                entity.ToTable("FollowUps");
                entity.HasKey(e => e.FollowUpID);
                entity.Property(e => e.FollowUpUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ImagingFile>(entity =>
            {
                entity.ToTable("ImagingFiles");
                entity.HasKey(e => e.FileID);
            });

            modelBuilder.Entity<ImagingRequest>(entity =>
            {
                entity.ToTable("ImagingRequests");
                entity.HasKey(e => e.ImagingRequestID);
                entity.Property(e => e.ImagingRequestUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ImagingResult>(entity =>
            {
                entity.ToTable("ImagingResults");
                entity.HasKey(e => e.ImagingResultID);
            });

            modelBuilder.Entity<ImagingService>(entity =>
            {
                entity.ToTable("ImagingServices");
                entity.HasKey(e => e.ImagingServiceID);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoices");
                entity.HasKey(e => e.InvoiceID);
                entity.Property(e => e.InvoiceUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("InvoiceDetails");
                entity.HasKey(e => e.DetailID);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<LabRequest>(entity =>
            {
                entity.ToTable("LabRequests");
                entity.HasKey(e => e.LabID);
                entity.Property(e => e.LabRequestUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<LabResult>(entity =>
            {
                entity.ToTable("LabResults");
                entity.HasKey(e => e.ResultID);
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecords");
                entity.HasKey(e => e.RecordID);
                entity.Property(e => e.RecordUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<MedicalRecordFile>(entity =>
            {
                entity.ToTable("MedicalRecordFiles");
                entity.HasKey(e => e.FileID);
                entity.Property(e => e.UploadedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicines");
                entity.HasKey(e => e.MedicineID);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ExpiryDate).HasColumnType("date");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notifications");
                entity.HasKey(e => e.NotificationID);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");
                entity.HasKey(e => e.PatientID);
                entity.Property(e => e.PatientUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.DOB).HasColumnType("date");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PatientIdentifier>(entity =>
            {
                entity.ToTable("PatientIdentifiers");
                entity.HasKey(e => e.IdentifierID);
            });

            modelBuilder.Entity<PatientInsurance>(entity =>
            {
                entity.ToTable("PatientInsurance");
                entity.HasKey(e => e.InsuranceID);
                entity.Property(e => e.EffectiveDate).HasColumnType("date");
                entity.Property(e => e.ExpiryDate).HasColumnType("date");
            });

            modelBuilder.Entity<PatientQueue>(entity =>
            {
                entity.ToTable("PatientQueues");
                entity.HasKey(e => e.QueueID);
                entity.Property(e => e.QueueUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments");
                entity.HasKey(e => e.PaymentID);
                entity.Property(e => e.PaymentUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.ToTable("PaymentDetails");
                entity.HasKey(e => e.PaymentDetailID);
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.ToTable("Prescriptions");
                entity.HasKey(e => e.PrescriptionID);
                entity.Property(e => e.PrescriptionUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<PrescriptionDetail>(entity =>
            {
                entity.ToTable("PrescriptionDetails");
                entity.HasKey(e => e.DetailID);
            });

            modelBuilder.Entity<QueueHistory>(entity =>
            {
                entity.ToTable("QueueHistory");
                entity.HasKey(e => e.HistoryID);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.RoleID);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Rooms");
                entity.HasKey(e => e.RoomID);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Sessions");
                entity.HasKey(e => e.SessionID);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shifts");
                entity.HasKey(e => e.ShiftID);
                entity.Property(e => e.StartTime).HasColumnType("time");
                entity.Property(e => e.EndTime).HasColumnType("time");
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.ToTable("Transfers");
                entity.HasKey(e => e.TransferID);
                entity.Property(e => e.TransferUUID).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VitalSign>(entity =>
            {
                entity.ToTable("VitalSigns");
                entity.HasKey(e => e.VitalID);
                entity.Property(e => e.Temperature).HasColumnType("decimal(4,1)");
                entity.Property(e => e.Weight).HasColumnType("decimal(5,2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            });
        }
    }
}
