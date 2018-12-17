using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task4._06_ISeekYou
{
    public class Program
    {
        private static int[] array = new int[1000];
        private static List<double> time = new List<double>();
        private static Stopwatch stopwatch = new Stopwatch();
        private static Random r = new Random();

        public static int[] Search()
        {
            List<int> posNums = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    posNums.Add(array[i]);
                }
            }

            return posNums.ToArray();
        }

        public static int[] Search(Func<int, bool> compare)
        {
            List<int> posNums = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (compare(array[i]))
                {
                    posNums.Add(array[i]);
                }
            }

            return posNums.ToArray();
        }

        public static bool SearchFunc(int number)
        {
            return number > 0;
        }

        public static int[] LinqSearch()
        {
            int[] posNums = array.Where(x => x > 0).ToArray();
            return posNums;
        }

        public static void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-99, 99);
            }
        }

        public static void Main()
        {
            FillArray();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Start();
                Search();
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Simple search:\t\t\t\t{time.Average():#} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Start();
                Search(SearchFunc);
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through delegate:\t\t{time.Average():#} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Start();
                Search(
                    delegate(int arrItem)
                     {
                         return arrItem > 0;
                     });
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through anonymus method:\t\t{time.Average():#} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Start();
                Search(arrItem => arrItem > 0);
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through lambda expression:\t{time.Average():#} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Start();
                LinqSearch();
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through LINQ:\t\t\t{time.Average():#} ms");
            time.Clear();
        }
    }
}