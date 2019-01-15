using System.Text.RegularExpressions;

namespace EPAM.Task7._05_TImeCounter
{
    internal class TimeCounter
    {
        private static string emptyInput = "The entered string is empty";
        private static string ex = @"\b(0?[0-9]|1[0-9]|2[0-3]):([012345][0-9])\b";
        private static Regex regex = new Regex(ex);
        private static string timeNotFound = "There is no time";

        public static int CountAllTimes(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return -1;
            }

            MatchCollection matches = regex.Matches(input);
            if (matches.Count > 0)
            {
                return matches.Count;
            }
            else
            {
                return 0;
            }
        }

        public static string ShowTimeCounter(string input)
        {
            if (CountAllTimes(input) == -1)
            {
                return emptyInput;
            }
            else
            {
                if (CountAllTimes(input) == 0)
                {
                    return timeNotFound;
                }
                else
                {
                    return $"Time is present in entered text {CountAllTimes(input)} time(s)";
                }
            }
        }
    }
}