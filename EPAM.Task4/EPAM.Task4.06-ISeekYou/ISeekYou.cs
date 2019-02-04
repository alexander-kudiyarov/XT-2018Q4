using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM.Task4._06_ISeekYou
{
    public class ISeekYou
    {
        private static int[] array = new int[1000];
        private static Random r = new Random();

        public static void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-99, 99);
            }
        }

        public static int[] LinqSearch()
        {
            int[] posNums = array.Where(x => x > 0).ToArray();
            return posNums;
        }

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
    }
}