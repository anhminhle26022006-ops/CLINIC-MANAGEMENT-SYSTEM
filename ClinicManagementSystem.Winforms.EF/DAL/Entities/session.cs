namespace DAL.Entities
{
    public class Session
    {
        public int SessionID { get; set; }
        public int UserID { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public User User { get; set; }
    }
}