namespace DevsTutorialCenterMVC.Utilities
{
    public static class Helper
    {
        public static string FormatDate(this DateTime date)
        {
            return date.ToString("yy MMM dd ddd");
        }
    }
}