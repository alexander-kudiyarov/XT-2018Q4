using System;

namespace EPAM.Task1._11_AvgStringLength
{
    public static class AvgStringLength
    {
        public static void Calc(string input)
        {
            bool word = false;
            int chars = 0;
            int count = 1;
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsDigit(input, i) || char.IsLetter(input, i))
                    {
                        word = true;
                        chars++;
                    }
                    else
                    {
                        if (word)
                        {
                            count++;
                            word = false;
                        }
                    }
                }

                if (!char.IsDigit(input, input.Length - 1) && !char.IsLetter(input, input.Length - 1))
                {
                    count--;
                }

                Console.WriteLine($"Average word length: {(double)chars / count:#.##}");
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}