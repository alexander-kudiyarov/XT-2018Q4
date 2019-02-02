using System;

namespace EPAM.Task1._10_TwoDArray
{
    public class TwoDArray
    {
        private int[,] arr;
        private Random r = new Random();

        public void FillArray()
        {
            this.arr = new int[6, 6];
        }

        public void Sum()
        {
            int sum = 0;
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    this.arr[i, j] = this.r.Next(-99, 99);
                    Console.Write($"{arr[i, j]}\t");
                    if ((i + j) % 2 == 0)
                    {
                        sum += this.arr[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}