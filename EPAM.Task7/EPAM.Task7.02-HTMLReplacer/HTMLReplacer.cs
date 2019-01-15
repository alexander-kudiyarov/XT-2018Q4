using System.Text.RegularExpressions;

namespace EPAM.Task7._02_HTMLReplacer
{
    internal class HTMLReplacer
    {
        private static string emptyInput = "The entered string is empty";
        private static string ex = "<\\/?[a-z=\"\\s]+>";

        public static string ReplaceTagsToUnderscores(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return emptyInput;
            }
            else
            {
                string result = Regex.Replace(input, ex, "_");
                return result;
            }
        }
    }
}