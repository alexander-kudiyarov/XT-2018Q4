using System;

namespace EPAM.Task1._9_NonNegativeSum
{
    class NonNegativeSum
    {

        public void Sort()
        {
            Random r = new Random();
            int[] arr = new int[r.Next(5, 30)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-99, 99);
            }
            foreach (int x in arr)
            {
                Console.Write($"{x} ");
            }
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    sum += arr[i];
                }
            }
            Console.WriteLine($"{Environment.NewLine}Sum: {sum}");
        }

    }
    class NonNegativeSumDemo
    {
        static void Main()
        {
            NonNegativeSum ob = new NonNegativeSum();
            ob.Sort();
        }
    }
}
