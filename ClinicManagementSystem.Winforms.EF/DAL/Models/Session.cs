using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Session
{
    public int SessionId { get; set; }

    public int? UserId { get; set; }

    public string Token { get; set; }

    public DateTime? ExpiredAt { get; set; }

    public virtual User User { get; set; }
}
