﻿using System;

namespace EPAM.Task1._8_NoPositive
{
    class ArrayProccesing
    {

        public void Sort()
        {
            Random r = new Random();
            int[,,] arr = new int[3, 3, 3];
            Console.WriteLine("Before:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine("Layer: {0}", i + 1);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = r.Next(-99, 99);
                        Console.Write("{0}\t", arr[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\nAfter:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.WriteLine("Layer: {0}", i + 1);
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    for (int k = 0; k < arr.GetLength(2); k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                        Console.Write("{0}\t", arr[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
    class ArrayProccesingDemo
    {
        static void Main()
        {
            ArrayProccesing ob = new ArrayProccesing();
            ob.Sort();
        }
    }
}