namespace Models
{
    public class AuditLogDetail
    {
        public int DetailID { get; set; }
        public int? LogID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
