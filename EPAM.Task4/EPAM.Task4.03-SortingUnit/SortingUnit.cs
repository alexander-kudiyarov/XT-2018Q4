using EPAM.Task4._01_CustomSort___02_CustomSortDemo;
using System;
using System.Threading;

namespace EPAM.Task4._03_SortingUnit
{
    public class SortingUnit<T> : CustomSort<T>
    {
        public SortingUnit(T[] ob) : base(ob)
        {
        }

        public event Action EndOfSotr;

        public static void EventHandler()
        {
            Console.WriteLine($"An array sotring complete{Environment.NewLine}");
        }

        public void DedicatedThreadQSort(Func<T, T, int> compare)
        {
            ThreadStart ts = new ThreadStart(() => QSort(compare));
            Thread th = new Thread(ts);
            th.Start();
            th.Join();
            this.EndOfSotr += EventHandler;
            this.OnEndOfSort();
        }

        public void OnEndOfSort()
        {
            this.EndOfSotr?.Invoke();
        }
    }
}