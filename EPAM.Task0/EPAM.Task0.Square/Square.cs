﻿using System;

namespace EPAM.Task0.Square
{
    public static class Square
    {
        public static void Draw(int n)
        {
            if (n % 2 != 0 & n > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == n / 2 && j == n / 2)
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
                Console.WriteLine("N must be odd and greater than one.");
            }
        }
    }
}