using System;
using System.Text.RegularExpressions;

namespace EPAM.Task6._01_DateExistance
{
    public class DateExistance
    {
        private static DateTime date;
        private static string dateFound = $"This text contains correct date: {date:D}";
        private static string dateNotFound = $"This text doesn't contain correct date";
        private static string emptyInput = "The entered string is empty";
        private static string ex = @"\b(0[1-9]|[12][\d]|3[0-1])-(0[1-9]|1[0-2])-([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]|[0-9][1-9][0-9]{2}|[1-9][0-9]{3})\b";
        private static Regex regex = new Regex(ex);

        public string CheckForDate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return emptyInput;
            }

            Match match = regex.Match(input);
            if (DateTime.TryParse(match.Value, out date))
            {
                return dateFound;
            }
            else
            {
                return dateNotFound;
            }
        }
    }
}