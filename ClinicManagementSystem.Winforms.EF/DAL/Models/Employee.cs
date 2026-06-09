using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public Guid EmployeeUuid { get; set; }

    public string EmployeeCode { get; set; }

    public string FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string Gender { get; set; }

    public string CitizenId { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public DateOnly? HireDate { get; set; }

    public decimal? Salary { get; set; }

    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public string Status { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Department Department { get; set; }

    public virtual ICollection<Dispense> Dispenses { get; set; } = new List<Dispense>();

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; } = new List<EmployeeShift>();

    public virtual ICollection<EncounterService> EncounterServices { get; set; } = new List<EncounterService>();

    public virtual ICollection<Encounter> Encounters { get; set; } = new List<Encounter>();

    public virtual ICollection<ImagingRequest> ImagingRequests { get; set; } = new List<ImagingRequest>();

    public virtual ICollection<LabRequest> LabRequests { get; set; } = new List<LabRequest>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual ICollection<QueueHistory> QueueHistories { get; set; } = new List<QueueHistory>();

    public virtual Role Role { get; set; }

    public virtual ICollection<ShiftChangeRequest> ShiftChangeRequestRequestedByNavigations { get; set; } = new List<ShiftChangeRequest>();

    public virtual ICollection<ShiftChangeRequest> ShiftChangeRequestTargetEmployees { get; set; } = new List<ShiftChangeRequest>();

    public virtual User User { get; set; }
}
