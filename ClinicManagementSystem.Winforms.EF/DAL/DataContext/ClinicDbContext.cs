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
            modelBuilder.Entity<ClinicalFile>().ToTable("Files").HasKey(e => e.FileID);
            modelBuilder.Entity<ClinicalService>().ToTable("Services").HasKey(e => e.ServiceID);
            modelBuilder.Entity<Dispense>().ToTable("Dispense").HasKey(e => e.DispenseID);
            modelBuilder.Entity<PatientInsurance>().ToTable("PatientInsurance").HasKey(e => e.InsuranceID);
            modelBuilder.Entity<QueueHistory>().ToTable("QueueHistory").HasKey(e => e.HistoryID);

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
