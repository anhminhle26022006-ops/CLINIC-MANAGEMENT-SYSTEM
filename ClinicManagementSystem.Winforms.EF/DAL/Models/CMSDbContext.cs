using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class CMSDbContext : DbContext
{
    public CMSDbContext()
    {
    }
    public CMSDbContext(DbContextOptions<CMSDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=MYPC;Initial Catalog=CMS;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<AuditLogDetail> AuditLogDetails { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Dispense> Dispenses { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeShift> EmployeeShifts { get; set; }

    public virtual DbSet<Encounter> Encounters { get; set; }

    public virtual DbSet<EncounterService> EncounterServices { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<FollowUp> FollowUps { get; set; }

    public virtual DbSet<ImagingFile> ImagingFiles { get; set; }

    public virtual DbSet<ImagingRequest> ImagingRequests { get; set; }

    public virtual DbSet<ImagingResult> ImagingResults { get; set; }

    public virtual DbSet<ImagingService> ImagingServices { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<LabRequest> LabRequests { get; set; }

    public virtual DbSet<LabResult> LabResults { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<MedicalRecordFile> MedicalRecordFiles { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientIdentifier> PatientIdentifiers { get; set; }

    public virtual DbSet<PatientInsurance> PatientInsurances { get; set; }

    public virtual DbSet<PatientQueue> PatientQueues { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }

    public virtual DbSet<QueueHistory> QueueHistories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftChangeRequest> ShiftChangeRequests { get; set; }

    public virtual DbSet<Transfer> Transfers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VitalSign> VitalSigns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA275BD4516");

            entity.HasIndex(e => e.AppointmentUuid, "UQ_Appointments_UUID").IsUnique();

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.AppointmentUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("AppointmentUUID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Appointme__Depar__59FA5E80");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__59063A47");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__5812160E");

            entity.HasOne(d => d.Room).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Appointme__RoomI__5AEE82B9");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E5499A85BF986A6");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TableName).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__AuditLogs__UserI__4D5F7D71");
        });

        modelBuilder.Entity<AuditLogDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__AuditLog__135C314DFC8B1CF9");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.LogId).HasColumnName("LogID");

            entity.HasOne(d => d.Log).WithMany(p => p.AuditLogDetails)
                .HasForeignKey(d => d.LogId)
                .HasConstraintName("FK__AuditLogD__LogID__503BEA1C");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDC84435A7");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(255);
        });

        modelBuilder.Entity<Dispense>(entity =>
        {
            entity.HasKey(e => e.DispenseId).HasName("PK__Dispense__26DF670A688734F4");

            entity.ToTable("Dispense");

            entity.HasIndex(e => e.DispenseUuid, "UQ_Dispense_UUID").IsUnique();

            entity.Property(e => e.DispenseId).HasColumnName("DispenseID");
            entity.Property(e => e.DispenseUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("DispenseUUID");
            entity.Property(e => e.PharmacistId).HasColumnName("PharmacistID");
            entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pharmacist).WithMany(p => p.Dispenses)
                .HasForeignKey(d => d.PharmacistId)
                .HasConstraintName("FK__Dispense__Pharma__22751F6C");

            entity.HasOne(d => d.Prescription).WithMany(p => p.Dispenses)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("FK__Dispense__Prescr__2180FB33");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__DoctorSc__9C8A5B693F9D719B");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__DoctorSch__Docto__6E01572D");

            entity.HasOne(d => d.Room).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__DoctorSch__RoomI__6EF57B66");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1CCA70140");

            entity.HasIndex(e => e.EmployeeUuid, "UQ_Employees_UUID").IsUnique();

            entity.HasIndex(e => e.EmployeeCode, "UQ__Employee__1F6425488245C15C").IsUnique();

            entity.HasIndex(e => e.CitizenId, "UX_Employees_CitizenId_NotNull")
                .IsUnique()
                .HasFilter("([CitizenId] IS NOT NULL)");

            entity.HasIndex(e => e.Email, "UX_Employees_Email_NotNull")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CitizenId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("EmployeeUUID");
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Active");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Depar__4CA06362");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__RoleI__4BAC3F29");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Employees__UserI__4D94879B");
        });

        modelBuilder.Entity<EmployeeShift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC275AD746F7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeShifts)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeS__Emplo__44CA3770");

            entity.HasOne(d => d.Shift).WithMany(p => p.EmployeeShifts)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK__EmployeeS__Shift__45BE5BA9");
        });

        modelBuilder.Entity<Encounter>(entity =>
        {
            entity.HasKey(e => e.EncounterId).HasName("PK__Encounte__4278DD1620D3FC80");

            entity.HasIndex(e => e.EncounterUuid, "UQ_Encounters_UUID").IsUnique();

            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.EncounterUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("EncounterUUID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK__Encounter__Appoi__5EBF139D");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Encounter__Docto__60A75C0F");

            entity.HasOne(d => d.Patient).WithMany(p => p.Encounters)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Encounter__Patie__5FB337D6");
        });

        modelBuilder.Entity<EncounterService>(entity =>
        {
            entity.HasKey(e => e.EncounterServiceId).HasName("PK__Encounte__D23C725E25E96D3D");

            entity.Property(e => e.EncounterServiceId).HasColumnName("EncounterServiceID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.OrderedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Encounter).WithMany(p => p.EncounterServices)
                .HasForeignKey(d => d.EncounterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encounter__Encou__693CA210");

            entity.HasOne(d => d.OrderedByNavigation).WithMany(p => p.EncounterServices)
                .HasForeignKey(d => d.OrderedBy)
                .HasConstraintName("FK__Encounter__Order__6B24EA82");

            entity.HasOne(d => d.Service).WithMany(p => p.EncounterServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Encounter__Servi__6A30C649");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__Files__6F0F989F40B7A0E3");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.FileUrl).HasColumnName("FileURL");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Files)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__Files__Encounter__3A4CA8FD");
        });

        modelBuilder.Entity<FollowUp>(entity =>
        {
            entity.HasKey(e => e.FollowUpId).HasName("PK__FollowUp__D507D658F543F7AE");

            entity.HasIndex(e => e.FollowUpUuid, "UQ_FollowUps_UUID").IsUnique();

            entity.Property(e => e.FollowUpId).HasColumnName("FollowUpID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.FollowUpDate).HasColumnType("datetime");
            entity.Property(e => e.FollowUpUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("FollowUpUUID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Encounter).WithMany(p => p.FollowUps)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__FollowUps__Encou__3D2915A8");
        });

        modelBuilder.Entity<ImagingFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__ImagingF__6F0F989FE2BF1D60");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.FileUrl).HasColumnName("FileURL");
            entity.Property(e => e.ImagingResultId).HasColumnName("ImagingResultID");

            entity.HasOne(d => d.ImagingResult).WithMany(p => p.ImagingFiles)
                .HasForeignKey(d => d.ImagingResultId)
                .HasConstraintName("FK__ImagingFi__Imagi__14270015");
        });

        modelBuilder.Entity<ImagingRequest>(entity =>
        {
            entity.HasKey(e => e.ImagingRequestId).HasName("PK__ImagingR__E99E2177B08F1911");

            entity.HasIndex(e => e.ImagingRequestUuid, "UQ_ImagingRequests_UUID").IsUnique();

            entity.Property(e => e.ImagingRequestId).HasColumnName("ImagingRequestID");
            entity.Property(e => e.BodyPart).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.ImagingRequestUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ImagingRequestUUID");
            entity.Property(e => e.ImagingServiceId).HasColumnName("ImagingServiceID");
            entity.Property(e => e.Priority).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.ImagingRequests)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__ImagingRe__Docto__0D7A0286");

            entity.HasOne(d => d.Encounter).WithMany(p => p.ImagingRequests)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__ImagingRe__Encou__0C85DE4D");

            entity.HasOne(d => d.ImagingService).WithMany(p => p.ImagingRequests)
                .HasForeignKey(d => d.ImagingServiceId)
                .HasConstraintName("FK__ImagingRe__Imagi__0E6E26BF");
        });

        modelBuilder.Entity<ImagingResult>(entity =>
        {
            entity.HasKey(e => e.ImagingResultId).HasName("PK__ImagingR__2F81D8B8930D5C25");

            entity.Property(e => e.ImagingResultId).HasColumnName("ImagingResultID");
            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.ImagingRequestId).HasColumnName("ImagingRequestID");
            entity.Property(e => e.Pdfurl).HasColumnName("PDFURL");

            entity.HasOne(d => d.ImagingRequest).WithMany(p => p.ImagingResults)
                .HasForeignKey(d => d.ImagingRequestId)
                .HasConstraintName("FK__ImagingRe__Imagi__114A936A");
        });

        modelBuilder.Entity<ImagingService>(entity =>
        {
            entity.HasKey(e => e.ImagingServiceId).HasName("PK__ImagingS__3EC66D2EB4312789");

            entity.Property(e => e.ImagingServiceId).HasColumnName("ImagingServiceID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Modality).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName).HasMaxLength(255);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Invoices__D796AAD58BB445F0");

            entity.HasIndex(e => e.InvoiceUuid, "UQ_Invoices_UUID").IsUnique();

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.InvoiceUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("InvoiceUUID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__Invoices__Encoun__31B762FC");

            entity.HasOne(d => d.Patient).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Invoices__Patien__32AB8735");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__InvoiceD__135C314D6B2684A2");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FK__InvoiceDe__Invoi__3587F3E0");

            entity.HasOne(d => d.Service).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__InvoiceDe__Servi__367C1819");
        });

        modelBuilder.Entity<LabRequest>(entity =>
        {
            entity.HasKey(e => e.LabId).HasName("PK__LabReque__EDBD773A8534727D");

            entity.HasIndex(e => e.LabRequestUuid, "UQ_LabRequests_UUID").IsUnique();

            entity.Property(e => e.LabId).HasColumnName("LabID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.LabRequestUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LabRequestUUID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TestType).HasMaxLength(255);

            entity.HasOne(d => d.Doctor).WithMany(p => p.LabRequests)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__LabReques__Docto__02FC7413");

            entity.HasOne(d => d.Encounter).WithMany(p => p.LabRequests)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__LabReques__Encou__02084FDA");
        });

        modelBuilder.Entity<LabResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__LabResul__97690228FCE5E4BB");

            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.CompletedAt).HasColumnType("datetime");
            entity.Property(e => e.FileUrl).HasColumnName("FileURL");
            entity.Property(e => e.LabId).HasColumnName("LabID");

            entity.HasOne(d => d.Lab).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.LabId)
                .HasConstraintName("FK__LabResult__LabID__05D8E0BE");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__MedicalR__FBDF78C98E5A3814");

            entity.HasIndex(e => e.RecordUuid, "UQ_MedicalRecords_UUID").IsUnique();

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.Icdcode)
                .HasMaxLength(50)
                .HasColumnName("ICDCode");
            entity.Property(e => e.RecordUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RecordUUID");

            entity.HasOne(d => d.Encounter).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__MedicalRe__Encou__76969D2E");
        });

        modelBuilder.Entity<MedicalRecordFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__MedicalR__6F0F989FD5A1880A");

            entity.Property(e => e.FileId).HasColumnName("FileID");
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.FileUrl).HasColumnName("FileURL");
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Record).WithMany(p => p.MedicalRecordFiles)
                .HasForeignKey(d => d.RecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MedicalRe__Recor__7A672E12");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PK__Medicine__4F2128F0B3ADA1A2");

            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.BatchNumber).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32C4748F16");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.IsRead).HasDefaultValue(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__498EEC8D");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346D4DAA287");

            entity.HasIndex(e => e.PatientUuid, "UQ_Patients_UUID").IsUnique();

            entity.HasIndex(e => e.PatientCode, "UQ__Patients__B9C66DFECD6BDA9C").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.BloodType).HasMaxLength(10);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.PatientCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PatientUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PatientUUID");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PatientIdentifier>(entity =>
        {
            entity.HasKey(e => e.IdentifierId).HasName("PK__PatientI__5EB5E7961E7816BF");

            entity.HasIndex(e => new { e.SourceSystem, e.IdentifierValue }, "UQ__PatientI__A2B255384537A213").IsUnique();

            entity.Property(e => e.IdentifierId).HasColumnName("IdentifierID");
            entity.Property(e => e.IdentifierType).HasMaxLength(100);
            entity.Property(e => e.IdentifierValue).HasMaxLength(255);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.SourceSystem).HasMaxLength(100);

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientIdentifiers)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__PatientId__Patie__540C7B00");
        });

        modelBuilder.Entity<PatientInsurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PK__PatientI__74231BC42EF917BC");

            entity.ToTable("PatientInsurance");

            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.InsuranceNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Provider).HasMaxLength(255);

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientInsurances)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__PatientIn__Patie__5441852A");
        });

        modelBuilder.Entity<PatientQueue>(entity =>
        {
            entity.HasKey(e => e.QueueId).HasName("PK__PatientQ__8324E8F59DBF87ED");

            entity.HasIndex(e => e.QueueUuid, "UQ_PatientQueues_UUID").IsUnique();

            entity.Property(e => e.QueueId).HasColumnName("QueueID");
            entity.Property(e => e.CurrentStep).HasMaxLength(50);
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.Priority).HasMaxLength(50);
            entity.Property(e => e.QueueTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.QueueUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("QueueUUID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Encounter).WithMany(p => p.PatientQueues)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__PatientQu__Encou__72C60C4A");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A586043FCC3");

            entity.HasIndex(e => e.PaymentUuid, "UQ_Payments_UUID").IsUnique();

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.Method).HasMaxLength(50);
            entity.Property(e => e.PaidAt).HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PaymentUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PaymentUUID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Encounter).WithMany(p => p.Payments)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__Payments__Encoun__2B0A656D");

            entity.HasOne(d => d.Patient).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Payments__Patien__2A164134");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentDetailId).HasName("PK__PaymentD__7F4E342F36E98FD2");

            entity.Property(e => e.PaymentDetailId).HasColumnName("PaymentDetailID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemType).HasMaxLength(50);
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentDe__Payme__2DE6D218");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__401308120E172DA6");

            entity.HasIndex(e => e.PrescriptionUuid, "UQ_Prescriptions_UUID").IsUnique();

            entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.PrescriptionUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PrescriptionUUID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Prescript__Docto__1AD3FDA4");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__Prescript__Encou__19DFD96B");
        });

        modelBuilder.Entity<PrescriptionDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__Prescrip__135C314D70938B25");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.Dosage).HasMaxLength(100);
            entity.Property(e => e.Frequency).HasMaxLength(100);
            entity.Property(e => e.Instruction).HasMaxLength(500);
            entity.Property(e => e.MedicineId).HasColumnName("MedicineID");
            entity.Property(e => e.PrescriptionId).HasColumnName("PrescriptionID");

            entity.HasOne(d => d.Medicine).WithMany(p => p.PrescriptionDetails)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("FK__Prescript__Medic__1EA48E88");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionDetails)
                .HasForeignKey(d => d.PrescriptionId)
                .HasConstraintName("FK__Prescript__Presc__1DB06A4F");
        });

        modelBuilder.Entity<QueueHistory>(entity =>
        {
            entity.HasKey(e => e.HistoryId).HasName("PK__QueueHis__4D7B4ADD9F35CCFF");

            entity.ToTable("QueueHistory");

            entity.Property(e => e.HistoryId).HasColumnName("HistoryID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.QueueId).HasColumnName("QueueID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.StepName).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.QueueHistories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__QueueHist__Emplo__2645B050");

            entity.HasOne(d => d.Queue).WithMany(p => p.QueueHistories)
                .HasForeignKey(d => d.QueueId)
                .HasConstraintName("FK__QueueHist__Queue__25518C17");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A1DD415AD");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__32863919D384E941");

            entity.HasIndex(e => e.RoomCode, "UQ__Rooms__4F9D5231432A152C").IsUnique();

            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.RoomCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Rooms__Departmen__45F365D3");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB0EA12B022EA");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceName).HasMaxLength(255);

            entity.HasOne(d => d.Department).WithMany(p => p.Services)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Services__Depart__6383C8BA");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Sessions__C9F492705B20C6AA");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.ExpiredAt).HasColumnType("datetime");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sessions__UserID__403A8C7D");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Shifts__C0A838E16C77C1EB");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ShiftChangeRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__ShiftCha__33A8519A7C325FB8");

            entity.HasIndex(e => e.RequestedBy, "IX_ShiftChange_Requester");

            entity.HasIndex(e => e.Status, "IX_ShiftChange_Status");

            entity.HasIndex(e => e.TargetEmployeeId, "IX_ShiftChange_Target");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ApprovedAt).HasColumnType("datetime");
            entity.Property(e => e.ApprovedByUserId).HasColumnName("ApprovedByUserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeShiftId).HasColumnName("EmployeeShiftID");
            entity.Property(e => e.Reason).HasMaxLength(500);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TargetEmployeeId).HasColumnName("TargetEmployeeID");

            entity.HasOne(d => d.ApprovedByUser).WithMany(p => p.ShiftChangeRequests)
                .HasForeignKey(d => d.ApprovedByUserId)
                .HasConstraintName("FK_ShiftChange_Admin");

            entity.HasOne(d => d.EmployeeShift).WithMany(p => p.ShiftChangeRequests)
                .HasForeignKey(d => d.EmployeeShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftChange_EmployeeShift");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.ShiftChangeRequestRequestedByNavigations)
                .HasForeignKey(d => d.RequestedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftChange_Requester");

            entity.HasOne(d => d.TargetEmployee).WithMany(p => p.ShiftChangeRequestTargetEmployees)
                .HasForeignKey(d => d.TargetEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftChange_TargetEmployee");
        });

        modelBuilder.Entity<Transfer>(entity =>
        {
            entity.HasKey(e => e.TransferId).HasName("PK__Transfer__954901717F767DCD");

            entity.HasIndex(e => e.TransferUuid, "UQ_Transfers_UUID").IsUnique();

            entity.Property(e => e.TransferId).HasColumnName("TransferID");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.Severity).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TransferUuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TransferUUID");

            entity.HasOne(d => d.Encounter).WithMany(p => p.Transfers)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__Transfers__Encou__40058253");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC77F35ED0");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4231A710E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534C3719CE6").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__3D5E1FD2");
        });

        modelBuilder.Entity<VitalSign>(entity =>
        {
            entity.HasKey(e => e.VitalId).HasName("PK__VitalSig__725DBAAA6574DE4D");

            entity.Property(e => e.VitalId).HasColumnName("VitalID");
            entity.Property(e => e.BloodPressure)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EncounterId).HasColumnName("EncounterID");
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Spo2).HasColumnName("SPO2");
            entity.Property(e => e.Temperature).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Encounter).WithMany(p => p.VitalSigns)
                .HasForeignKey(d => d.EncounterId)
                .HasConstraintName("FK__VitalSign__Encou__7E37BEF6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
