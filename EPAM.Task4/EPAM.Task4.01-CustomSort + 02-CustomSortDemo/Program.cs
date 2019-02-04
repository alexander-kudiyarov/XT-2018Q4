using System;

namespace EPAM.Task4._01_CustomSort___02_CustomSortDemo
{
    public class Program
    {
        public static void Main()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            CustomSort<string> ob = new CustomSort<string>(words);
            Console.WriteLine($"Unsorted words: {ob.ToString()}");

            Console.WriteLine();
            ob.QSort(CompareByLength);
            Console.WriteLine($"Sorted words: {ob.ToString()}");
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