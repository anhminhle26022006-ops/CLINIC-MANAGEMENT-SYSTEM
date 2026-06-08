namespace CMS.Core.Utils
{
    public static class DateTimeHelper
    {
        public static DateTime Now()
        {
            return DateTime.Now;
        }

        public static string ToDisplay(DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        public static string ToDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}