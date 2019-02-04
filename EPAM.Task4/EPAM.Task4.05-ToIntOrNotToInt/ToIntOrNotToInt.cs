using System.Text;

namespace EPAM.Task4._05_ToIntOrNotToInt
{
    public static class ToIntOrNotToInt
    {
        public static bool IsNaturalNumber(this string input)
        {
            string temp;
            if (input.Contains("e") && input != "e")
            {
                temp = input.ToDecimal();
            }
            else
            {
                StringBuilder sb = new StringBuilder(input);
                for (int i = 0; i <= sb.Length; i++)
                {
                    if (sb[sb.Length - 1] == '0')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                }

                if (sb[sb.Length - 1] == '.')
                {
                    sb.Remove(sb.Length - 1, 1);
                }

                temp = sb.ToString();
            }

            bool isPositive;
            bool allDigit = true;
            bool moreThanOneZero = false;
            if (temp[0] == '-')
            {
                isPositive = false;
            }
            else
            {
                isPositive = true;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (!char.IsDigit(temp[i]))
                {
                    allDigit = false;
                }

                if (char.IsDigit(temp[i]) && temp[i] != '0')
                {
                    moreThanOneZero = true;
                }
            }

            if (isPositive && allDigit && moreThanOneZero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int ExpCalc(this string input)
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

        private static string ToDecimal(this string input)
        {
            bool dot = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    dot = true;
                }
            }

            char[] e = { 'E', 'e' };
            StringBuilder sb = new StringBuilder(input);
            sb.Remove(input.IndexOfAny(e), input.Length - input.IndexOfAny(e));
            if (input[0] == '+' || input[0] == '-')
            {
                sb.Remove(0, 1);
            }

            if (dot)
            {
                int oldDotIndex = sb.ToString().IndexOf('.');
                int newDotIndex = oldDotIndex + ExpCalc(input);
                if (newDotIndex > 0 && newDotIndex < sb.Length - 1)
                {
                    sb.Remove(oldDotIndex, 1);
                    sb.Insert(newDotIndex, '.');
                }
                else
                {
                    if (newDotIndex >= sb.Length - 1)
                    {
                        sb.Remove(oldDotIndex, 1);
                        int a = newDotIndex;
                        int b = sb.Length;
                        for (int i = 0; i < a - b; i++)
                        {
                            sb.Append('0');
                        }
                    }
                    else
                    {
                        if (newDotIndex <= 0)
                        {
                            sb.Remove(oldDotIndex, 1);
                            sb.Insert(0, "0.");
                            for (int i = 0; i < newDotIndex * -1; i++)
                            {
                                sb.Insert(2, '0');
                            }
                        }
                    }
                }
            }
            else
            {
                if (ExpCalc(input) >= 0)
                {
                    for (int i = 0; i < ExpCalc(input); i++)
                    {
                        sb.Append('0');
                    }
                }
                else
                {
                    if (ExpCalc(input) * -1 >= sb.Length)
                    {
                        int originSbLength = sb.Length;
                        if (ExpCalc(input) * -1 >= originSbLength)
                        {
                            sb.Insert(0, '0');
                            for (int i = 0; i < (ExpCalc(input) * -1) - originSbLength; i++)
                            {
                                sb.Insert(1, '0');
                            }

                            sb.Insert(sb.Length + ExpCalc(input), ',');
                        }
                    }
                    else
                    {
                        sb.Insert(sb.Length + ExpCalc(input), '.');
                    }
                }
            }

            if (input[0] == '-')
            {
                sb.Insert(0, '-');
            }

            for (int i = 0; i <= sb.Length; i++)
            {
                if (sb[sb.Length - 1] == '0')
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }

            if (sb[sb.Length - 1] == '.')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}