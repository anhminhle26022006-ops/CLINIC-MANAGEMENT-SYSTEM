namespace CMS.Core.Utils
{
    public static class IdGenerator
    {
        public static Guid GenerateUUID()
        {
            return Guid.NewGuid();
        }

        public static string GeneratePatientCode(int id)
        {
            return $"PT{id:D5}";
        }

        public static string GenerateEmployeeCode(int id)
        {
            return $"EMP{id:D3}";
        }

        public static string GenerateRoomCode(string prefix, int id)
        {
            return $"{prefix}-{id:D2}";
        }
    }
}