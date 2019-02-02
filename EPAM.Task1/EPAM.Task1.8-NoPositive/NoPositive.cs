using System;

namespace EPAM.Task1._8_NoPositive
{
    public class NoPositive
    {
        private int[,,] arr = new int[3, 3, 3];
        private Random r = new Random();

        public void FillArray()
        {
            Console.WriteLine("Before:");
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                Console.WriteLine($"Layer: {i + 1}");
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    for (int k = 0; k < this.arr.GetLength(2); k++)
                    {
                        this.arr[i, j, k] = this.r.Next(-99, 99);
                        Console.Write($"{arr[i, j, k]}\t");
                    }

                    Console.WriteLine();
                }
            }
        }

        public void RemoveNoPositive()
        {
            Console.WriteLine("\nAfter:");
            for (int i = 0; i < this.arr.GetLength(0); i++)
            {
                Console.WriteLine($"Layer: {i + 1}");
                for (int j = 0; j < this.arr.GetLength(1); j++)
                {
                    for (int k = 0; k < this.arr.GetLength(2); k++)
                    {
                        if (this.arr[i, j, k] > 0)
                        {
                            this.arr[i, j, k] = 0;
                        }

                        Console.Write($"{arr[i, j, k]}\t");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}