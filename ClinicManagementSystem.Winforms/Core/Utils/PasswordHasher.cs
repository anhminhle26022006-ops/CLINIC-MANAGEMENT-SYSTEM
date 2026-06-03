namespace CMS.Core.Utils
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return password?.Trim() ?? string.Empty;
        }

        public static bool Verify(
            string password,
            string storedHash)
        {
            return Hash(password) == Hash(storedHash);
        }
    }
}