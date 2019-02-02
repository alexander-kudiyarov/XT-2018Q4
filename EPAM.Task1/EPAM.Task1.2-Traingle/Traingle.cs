using System;

namespace EPAM.Task1._2_Traingle
{
    public static class Traingle
    {
        public static void Draw(int n)
        {
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('*');
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("N must be greater than 0");
            }
        }
    }
}