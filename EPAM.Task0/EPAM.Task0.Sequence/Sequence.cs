using System;

namespace EPAM.Task0.Sequence
{
    public static class Sequence
    {
        public static void Show(int n)
        {
            if (n > 0)
            {
                for (int i = 1; i < n; i++)
                {
                    Console.Write($"{i}, ");
                }

                Console.WriteLine(n);
            }
            else
            {
                Console.WriteLine("N must be greater than 0");
            }
        }
    }
}