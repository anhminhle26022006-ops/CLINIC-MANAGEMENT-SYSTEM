namespace DAL.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int? RoleID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Role Role { get; set; }
    }
}