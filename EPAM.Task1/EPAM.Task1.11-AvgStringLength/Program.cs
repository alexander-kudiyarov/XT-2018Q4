using System;

namespace EPAM.Task1._11_AvgStringLength
{
    public class AvgStringLength
    {
        public void Calc()
        {
            bool word = false;
            int chars = 0;
            int count = 1;
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine();
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

    public class AvgStringLengthDemo
    {
        public static void Main()
        {
            AvgStringLength ob = new AvgStringLength();
            ob.Calc();
        }
    }
}
