using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EPAM.Task7._03_EmailFinder
{
    public static class EmailFinder
    {
        private static string emailNotFound = "There is no emails";
        private static List<string> emails = new List<string>();
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
            while (IsMatchFounded())
            {
                IsMatchFounded();
            }

            return ToString();
        }

        private static bool IsMatchFounded()
        {
            Match match = regex.Match(text);

            if (match.Success)
            {
                string matchString = match.ToString();
                emails.Add(matchString);
                text = text.Replace(matchString, string.Empty);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static new string ToString()
        {
            if (emails.Count == 0)
            {
                return emailNotFound;
            }
            else
            {
                StringBuilder tmp = new StringBuilder();
                foreach (var item in emails)
                {
                    tmp.Append($"{item}{Environment.NewLine}");
                }

                return tmp.ToString();
            }
        }
    }
}