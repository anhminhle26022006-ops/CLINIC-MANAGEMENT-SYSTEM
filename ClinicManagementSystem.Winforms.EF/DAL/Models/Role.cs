using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
