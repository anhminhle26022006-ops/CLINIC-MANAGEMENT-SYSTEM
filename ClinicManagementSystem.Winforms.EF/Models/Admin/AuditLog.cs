using System;

namespace Models
{
    public class AuditLog
    {
        public int LogID { get; set; }
        public int? UserID { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
