using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EPAM.Task4._06_ISeekYou
{
    public class Program
    {
        private static Stopwatch stopwatch = new Stopwatch();
        private static List<double> time = new List<double>();

        public static void Main()
        {
            ISeekYou.FillArray();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Restart();
                ISeekYou.Search();
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Simple search:\t\t\t\t{time.Average():0.###} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Restart();
                ISeekYou.Search(ISeekYou.SearchFunc);
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through delegate:\t\t{time.Average():0.###} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Restart();
                ISeekYou.Search(
                    delegate (int arrItem)
                    {
                        return arrItem > 0;
                    });
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through anonymus method:\t\t{time.Average():0.###} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Restart();
                ISeekYou.Search(arrItem => arrItem > 0);
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through lambda expression:\t{time.Average():0.###} ms");
            time.Clear();

            for (int i = 0; i < 100; i++)
            {
                stopwatch.Restart();
                ISeekYou.LinqSearch();
                stopwatch.Stop();
                time.Add(stopwatch.Elapsed.TotalMilliseconds);
            }

            Console.WriteLine($"Search through LINQ:\t\t\t{time.Average():0.###} ms");
            time.Clear();
        }
    }
}