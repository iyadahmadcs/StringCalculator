using System.Collections.Generic;

namespace StringCalculator.Services.Extensions
{
    public static class Extensions
    {
        public static string ToArrayMessage(this List<string> list)
        {
            var result = string.Empty;
            var prefix = string.Empty;
            foreach (var str in list)
            {
                result = $"{result}{prefix}{str}";
                prefix = ",";
            }
            if (string.IsNullOrWhiteSpace(result))
                return string.Empty;

            result = $"[{result}]";
            return result;
        }

        public static string ToArrayMessage(this List<int> list)
        {
            var result = string.Empty;
            var prefix = string.Empty;
            foreach (var str in list)
            {
                result = $"{result}{prefix}{str}";
                prefix = ",";
            }
            if (string.IsNullOrWhiteSpace(result))
                return string.Empty;

            result = $"[{result}]";
            return result;
        }
    }
}
