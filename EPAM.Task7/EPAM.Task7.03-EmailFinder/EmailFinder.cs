using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EPAM.Task7._03_EmailFinder
{
    public static class EmailFinder
    {
        private static string emailNotFound = "There is no emails";
        private static string emptyInput = "The entered string is empty";
        private static string ex = @"\b([a-zA_Z0-9]+[.\-_]?)*([a-zA_Z0-9])+@([a-z0-9]+[\-]?)*([a-z0-9])+(\.(([a-z0-9]+[\-]?)*([a-z0-9])+))*(\.[a-z]{2,6})\b";
        private static Regex regex = new Regex(ex);
        private static string text;

        public static string FindAllEmails(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return emptyInput;
            }

            text = input;
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                StringBuilder emails = new StringBuilder();
                foreach (var item in matches)
                {
                    emails.Append($"{item}{Environment.NewLine}");
                }

                return emails.ToString();
            }
            else
            {
                return emailNotFound;
            }
        }
    }
}