using System;

namespace EPAM.Task1._3_AnotherTraingle
{
    public static class AnotherTraingle
    {
        public static void Draw(int n)
        {
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + i; j++)
                    {
                        if (j < n - 1 - i)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write('*');
                        }
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