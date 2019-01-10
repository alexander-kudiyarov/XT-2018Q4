using System;
using System.Text.RegularExpressions;

namespace EPAM.Task6._01_DateExistance
{
    public class DateExistance
    {
        private DateTime date;

        private Regex regex = new Regex(@"\b(0[1-9]|[12][\d]|3[0-1])-(0[1-9]|1[0-2])-(\d{4})\b");

        public DateTime Date => this.date;

        public bool CheckForDate(string input)
        {
            Match match = this.regex.Match(input);

            return DateTime.TryParse(match.Value, out this.date);
        }
    }
}