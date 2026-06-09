using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Role Role { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<ShiftChangeRequest> ShiftChangeRequests { get; set; } = new List<ShiftChangeRequest>();
}
