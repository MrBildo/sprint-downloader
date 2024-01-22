using System.Text;

namespace MrBildo.SprintDownloader
{
    public static class Extensions
    {
        public static string SanitizeString(this string input)
        {
            var sb = new StringBuilder(input.Length);

            foreach (var c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
                else if (c == ' ')
                {
                    sb.Append('_');
                }
            }

            return sb.ToString();
        }

        public static string? ValueBetween(this string value, string startString, string endString)
        {
            var start = value.IndexOf(startString) + startString.Length;
            var end = value.IndexOf(endString, start);

            return start < 0 || end < 0 ? null : value[start..end];
        }

        public static string? ValueBetween(this string value, string startString, string endString, int startIndex)
        {
            if (startIndex < 0)
            {
                return null;
            }

            var start = value.IndexOf(startString, startIndex) + startString.Length;
            var end = value.IndexOf(endString, start);

            return value[start..end];
        }
    }
}
