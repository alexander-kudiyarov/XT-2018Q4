using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Sort
{
    public class Program
    {
        private static int length = 500000000;
        private static int[] array = new int[length];
        private static int cycles = 10;
        private static int peek = 700;
        private static Random r = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static List<double> time = new List<double>();

        public static void Main(string[] args)
        {
            for (int i = 0; i < cycles; i++)
            {
                FillArray();
                stopwatch.Restart();
                SimpleSearch();
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"SimpleSearch:\t{time.Average():0.#} ms");
            time.Clear();

            for (int i = 0; i < cycles; i++)
            {
                FillArray();
                stopwatch.Restart();
                SortNBinSearch();
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"SortNBinSearch:\t{time.Average():0.#} ms");
            time.Clear();
        }

        private static void SimpleSearch()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == peek)
                {
                    break;
                }
            }
        }

        private static void SortNBinSearch()
        {
            Array.Sort(array);
            Array.BinarySearch(array, peek);
        }

        private static void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(0, 1000000);
            }
        }
    }
}