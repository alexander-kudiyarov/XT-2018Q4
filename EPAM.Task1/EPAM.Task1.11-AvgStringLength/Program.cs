using System;

namespace EPAM.Task1._11_AvgStringLength
{
    class AvgStringLength
    {
        public void Calc()
        {
            bool word = false;
            int chars = 0;
            int count = 1;
            string input = Console.ReadLine();
            if (input != null)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input, i) || Char.IsLetter(input, i))
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
                if (!Char.IsDigit(input, input.Length - 1) && !Char.IsLetter(input, input.Length - 1))
                {
                    count--;
                }
                Console.WriteLine("Average word length: {0}", (double) chars / count);
            }
        }
    }
    class AvgStringLengthDemo
    {
        static void Main()
        {
            AvgStringLength ob = new AvgStringLength();
            ob.Calc();
        }
    }
}