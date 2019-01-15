using System;
using System.Text.RegularExpressions;

namespace EPAM.Task6._01_DateExistance
{
    public static class DateExistance
    {
        private static DateTime date;

        private static Regex regex = new Regex(@"\b(0[1-9]|[12][\d]|3[0-1])-(0[1-9]|1[0-2])-([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]|[0-9][1-9][0-9]{2}|[1-9][0-9]{3})\b");

        public static DateTime Date => date;

        public static bool CheckForDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            Match match = regex.Match(input);

            return DateTime.TryParse(match.Value, out date);
        }
    }
}