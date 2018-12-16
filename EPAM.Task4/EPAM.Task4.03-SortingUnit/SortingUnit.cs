using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EPAM.Task4._01_CustomSort___02_CustomSortDemo;

namespace EPAM.Task4._03_SortingUnit
{
    public class SortingUnit<T> : CustomSort<T>
    {
        public SortingUnit(T[] ob) : base(ob)
        {
        }

        public event Action EndOfSotr;

        public void DedicatedThreadQSort(Func<T, T, int> compare)
        {
            ThreadStart ts = new ThreadStart(() => QSort(compare));
            Thread th = new Thread(ts);
            th.Start();
            th.Join();
        }

        public void OnEndOfSort()
        {
            this.EndOfSotr?.Invoke();
        }
    }
}
