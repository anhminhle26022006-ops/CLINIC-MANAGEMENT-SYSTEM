namespace CMS.Core.Utils
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return password;
        }

        public static bool Verify(
            string password,
            string storedHash)
        {
            return password == storedHash;
        }
    }
}