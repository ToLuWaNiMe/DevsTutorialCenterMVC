namespace DevsTutorialCenterMVC.Utilities
{
    public static class Helper
    {
        public static string FormatDate(this DateTime date)
        {
            return date.ToString("ddd dd MMM yy");
        }

        public static string ShortenText(this string text, int length)
        {
            return text.Length < length ? $"{text}..." : $"{text[..length]}...";
        }
    }
}