using DAL.Entities;
using Microsoft.EntityFrameworkCore;

// Dùng alias để tránh xung đột với DAL.Models
using Appointment = DAL.Entities.Appointment;
using Department = DAL.Entities.Department;
using Employee = DAL.Entities.Employee;
using EmployeeShift = DAL.Entities.EmployeeShift;
using Encounter = DAL.Entities.Encounter;
using FollowUp = DAL.Entities.FollowUp;
using ImagingRequest = DAL.Entities.ImagingRequest;
using ImagingResult = DAL.Entities.ImagingResult;
using ImagingService = DAL.Entities.ImagingService;
using Invoice = DAL.Entities.Invoice;
using InvoiceDetail = DAL.Entities.InvoiceDetail;
using LabRequest = DAL.Entities.LabRequest;
using LabResult = DAL.Entities.LabResult;
using MedicalRecord = DAL.Entities.MedicalRecord;
using Medicine = DAL.Entities.Medicine;
using Patient = DAL.Entities.Patient;
using PatientInsurance = DAL.Entities.PatientInsurance;
using PatientQueue = DAL.Entities.PatientQueue;
using Payment = DAL.Entities.Payment;
using Prescription = DAL.Entities.Prescription;
using PrescriptionDetail = DAL.Entities.PrescriptionDetail;
using Role = DAL.Entities.Role;
using Room = DAL.Entities.Room;
using Service = DAL.Entities.Service;
using Session = DAL.Entities.Session;
using Shift = DAL.Entities.Shift;
using User = DAL.Entities.User;
using VitalSign = DAL.Entities.VitalSign;
using WorkAssignment = DAL.Entities.WorkAssignment;

namespace DAL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientInsurance> PatientInsurances { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }
        public DbSet<LabRequest> LabRequests { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<ImagingService> ImagingServices { get; set; }
        public DbSet<ImagingRequest> ImagingRequests { get; set; }
        public DbSet<ImagingResult> ImagingResults { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDetail> PrescriptionDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeShift> EmployeeShifts { get; set; }
        public DbSet<PatientQueue> PatientQueues { get; set; }
        public DbSet<WorkAssignment> WorkAssignments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}