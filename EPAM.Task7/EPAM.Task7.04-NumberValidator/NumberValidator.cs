using System.Text.RegularExpressions;

namespace EPAM.Task7._04_NumberValidator
{
    public static class NumberValidator
    {
        private static string decimalForm = "decimal form";
        private static string decimalFormEx = @"^(-?\d+)(\.\d+)?$";
        private static string emptyInput = "The entered string is empty";
        private static string notNumber = "This is not number";
        private static string scientificForm = "scientific form";
        private static string scientificFormEx = @"^(-?\d+)(\.\d+)?(e-?\d+)+$";

        public static string NumberForm(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return emptyInput;
            }

            if (Regex.IsMatch(input, scientificFormEx))
            {
                return $"{input} is a {scientificForm}";
            }
            else
            {
                if (Regex.IsMatch(input, decimalFormEx))
                {
                    return $"{input} is a {decimalForm}";
                }
                else
                {
                    return notNumber;
                }
            }
        }
    }
}