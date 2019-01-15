using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EPAM.Task7._03_EmailFinder
{
    public class EmailFinder
    {
        private static string emailNotFound = "There is no emails";
        private static string emptyInput = "The entered string is empty";
        private static string ex = @"\b([a-zA_Z0-9]+[.\-_]?)*([a-zA_Z0-9])+@([a-z0-9]+[\-]?)*([a-z0-9])+(\.(([a-z0-9]+[\-]?)*([a-z0-9])+))*(\.[a-z]{2,6})\b";
        private static Regex regex = new Regex(ex);
        private List<string> emails = new List<string>();
        private string text;

        public string FindAllEmails(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "The entered string is empty";
            }

            this.text = input;
            while (this.IsMatchFounded())
            {
                this.IsMatchFounded();
            }

            return this.ToString();
        }

        public bool IsMatchFounded()
        {
            Match match = regex.Match(this.text);

            if (match.Success)
            {
                string matchString = match.ToString();
                this.emails.Add(matchString);
                this.text = this.text.Replace(matchString, string.Empty);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            if (this.emails.Count == 0)
            {
                return emailNotFound;
            }
            else
            {
                StringBuilder tmp = new StringBuilder();
                foreach (var item in this.emails)
                {
                    tmp.Append($"{item}{Environment.NewLine}");
                }

                return tmp.ToString();
            }
        }
    }
}