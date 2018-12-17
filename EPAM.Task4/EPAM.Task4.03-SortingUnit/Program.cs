﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task4._03_SortingUnit
{
    public class Program
    {
        public static void EventHandler()
        {
            Console.WriteLine($"An array sotring complete{Environment.NewLine}");
        }

        public static void Main()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            SortingUnit<string> ob = new SortingUnit<string>(words);
            Console.WriteLine($"Unsorted words:");
            ob.Show();
            Console.WriteLine();

            ob.DedicatedThreadQSort(CompareByLength);
            ob.EndOfSotr += EventHandler;
            ob.OnEndOfSort();

            Console.WriteLine($"Sorted words:");
            ob.Show();
        }

        private static int CompareByLength(string str1, string str2)
        {
            if (str1.Length < str2.Length)
            {
                return -1;
            }

            if (str1.Length > str2.Length)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (char.ToLower(str1[i]) < char.ToLower(str2[i]))
                    {
                        return -1;
                    }

                    if (char.ToLower(str1[i]) > char.ToLower(str2[i]))
                    {
                        return 1;
                    }
                }

                return 0;
            }
        }
    }
}