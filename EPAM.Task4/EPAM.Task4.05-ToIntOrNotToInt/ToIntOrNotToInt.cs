using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task4._05_ToIntOrNotToInt
{
    public static class ToIntOrNotToInt
    {
        public static bool IsNaturalNumber(this string input)
        {
            bool isPositive;
            bool allDigit = true;
            bool atLeastOneNonZero = false;
            if (input[0] == '-')
            {
                isPositive = false;
            }
            else
            {
                isPositive = true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    allDigit = false;
                }
                if (char.IsDigit(input[i]) && input[i] != '0')
                {
                    atLeastOneNonZero = true;
                }
            }
            if (isPositive && allDigit && atLeastOneNonZero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ToDecimal(this string input)
        {

        }

        public static int ExpCalc(this string input)
        {
            int exp = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if ((input[i] == 'E' || input[i] == 'e') & input[i + 1] == '+')
                {
                    int multiplier = 1;
                    for (int j = input.Length - 1; input[j] != '+'; j--)
                    {
                        exp += (int)char.GetNumericValue(input[j]) * multiplier;
                        multiplier *= 10;
                    }
                }
                else
                {
                    if ((input[i] == 'E' || input[i] == 'e') & input[i + 1] == '-')
                    {
                        int multiplier = -1;
                        for (int j = input.Length - 1; input[j] != '-'; j--)
                        {
                            exp += (int)char.GetNumericValue(input[j]) * multiplier;
                            multiplier *= 10;
                        }
                    }
                }
            }
            return exp;
        }
    }
}
