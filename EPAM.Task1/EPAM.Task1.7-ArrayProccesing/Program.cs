using System;

namespace EPAM.Task1._7_ArrayProccesing
{
    class ArrayProccesing
    {

        public void Sort()
        {
            Random r = new Random();
            int[] arr = new int[r.Next(5, 30)];
            int tmp;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-99, 99);
            }
            Console.WriteLine("Unsorted array:");
            foreach (int x in arr)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - (1 + i); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
            Console.WriteLine("Sorted array:");
            foreach (int x in arr)
            {
                Console.Write("{0} ", x);
            }
            Console.WriteLine("\nMin: {0}\nMax: {1}", arr[0], arr[arr.Length - 1]);
        }

    }
    class ArrayProccesingDemo
    {
        static void Main()
        {
            ArrayProccesing ob = new ArrayProccesing();
            ob.Sort();
        }
    }
}