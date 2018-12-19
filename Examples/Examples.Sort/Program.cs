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
        private static int length = 1000000;
        private static int[] array = new int[length];
        private static int cycles = 10;
        private static Random r = new Random();
        private static Stopwatch stopwatch = new Stopwatch();
        private static List<double> time = new List<double>();

        public static void Main(string[] args)
        {
            for (int i = 0; i < cycles; i++)
            {
                FillArray();
                stopwatch.Restart();
                for (int j = 0; j < 500; j++)
                {
                    SimpleSearch(Array.BinarySearch(array, r.Next(0, 1000000)));
                }

                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"SimpleSearch:\t{time.Average():0.###} ms");
            time.Clear();

            for (int i = 0; i < cycles; i++)
            {
                FillArray();
                stopwatch.Restart();
                Array.Sort(array);
                for (int j = 0; j < 500; j++)
                {
                    Array.BinarySearch(array, r.Next(0, 1000000));
                }

                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"SortNBinSearch:\t{time.Average():0.###} ms");
            time.Clear();
        }

        private static void SimpleSearch(int n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == n)
                {
                    break;
                }
            }
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