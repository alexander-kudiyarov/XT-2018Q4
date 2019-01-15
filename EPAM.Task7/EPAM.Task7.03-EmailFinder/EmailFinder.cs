using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EPAM.Task7._03_EmailFinder
{
    public class EmailFinder
    {
        private static string ex = @"\b([a-zA_Z0-9]+[.\-_]?)*([a-zA_Z0-9])+@([a-z0-9]+[\-]?)*([a-z0-9])+(\.(([a-z0-9]+[\-]?)*([a-z0-9])+))*(\.[a-z]{2,6})\b";

        private List<string> emails = new List<string>();

        private Regex regex = new Regex(ex);

        private string text;

        public void FindAllEmails(string input)
        {
            this.text = input;
            while (this.IsMatchFounded())
            {
                this.IsMatchFounded();
            }
        }

        public bool IsMatchFounded()
        {
            Match match = this.regex.Match(this.text);

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
            StringBuilder tmp = new StringBuilder();
            foreach (var item in this.emails)
            {
                tmp.Append($"{item}{Environment.NewLine}");
            }

            return tmp.ToString();
        }
    }
}