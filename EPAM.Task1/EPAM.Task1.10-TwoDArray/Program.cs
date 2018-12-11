﻿using System;

namespace EPAM.Task1._10_TwoDArray
{
    public class TwoDArray
    {
        public void Sum()
        {
            Random r = new Random();
            int[,] arr = new int[6, 6];
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(-99, 99);
                    Console.Write($"{arr[i, j]}\t");
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }

    public class TwoDArrayDemo
    {
        public static void Main()
        {
            TwoDArray ob = new TwoDArray();
            ob.Sum();
        }
    }
}
