using System;

namespace Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public int? UserID { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredAt { get; set; }
    }
}
