using System;

namespace EPAM.Task1._4_XmasTree
{
    public static class XmasTree
    {
        public static void Draw(int n)
        {
            if (n > 0)
            {
                for (int k = 1; k <= n; k++)
                {
                    for (int i = 0; i < k; i++)
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
            }
            else
            {
                Console.WriteLine("N must be greater than 0");
            }
        }
    }
}