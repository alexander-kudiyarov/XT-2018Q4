﻿using System;

namespace EPAM.Task1._7_ArrayProccesing
{
    public class ArrayProccesing
    {
        public void Sort()
        {
            Random r = new Random();
            int[] arr = new int[r.Next(5, 30)];
            int tmp;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-99, 99);
            }

            Console.WriteLine("Unsorted array:");
            foreach (int x in arr)
            {
                Console.Write($"{x} ");
            }

            Console.WriteLine();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - (1 + i); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }

            Console.WriteLine("Sorted array:");
            foreach (int x in arr)
            {
                Console.Write("{0} ", x);
            }

            Console.WriteLine($"{Environment.NewLine}Min: {arr[0]}{Environment.NewLine}Max: {arr[arr.Length - 1]}");
        }
    }

    public class ArrayProccesingDemo
    {
        public static void Main()
        {
            ArrayProccesing ob = new ArrayProccesing();
            ob.Sort();
        }
    }
}
