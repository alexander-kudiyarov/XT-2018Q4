using System;

namespace EPAM.Task1._10_TwoDArray
{
    class TwoDArray
    {
        public void Sum()
        {
            Random r = new Random();
            int[,] arr = new int[10, 10];
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(-99, 99);
                    Console.Write("{0}\t", arr[i, j]);
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("sum equal: {0}", sum);
        }
    }
    class TwoDArrayDemo
    {
        static void Main()
        {
            TwoDArray ob = new TwoDArray();
            ob.Sum();
        }
    }
}