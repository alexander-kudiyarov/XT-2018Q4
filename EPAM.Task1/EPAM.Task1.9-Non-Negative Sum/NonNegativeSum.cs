using System;

namespace EPAM.Task1._9_Non_Negative_Sum
{
    public class NonNegativeSum
    {
        private int[] arr;
        private Random r = new Random();

        public void FillArray()
        {
            this.arr = new int[this.r.Next(5, 30)];
        }

        public void Sort()
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                this.arr[i] = this.r.Next(-99, 99);
            }

            foreach (var n in this.arr)
            {
                Console.Write($"{n} ");
            }

            int sum = 0;
            for (int i = 0; i < this.arr.Length; i++)
            {
                if (this.arr[i] > 0)
                {
                    sum += this.arr[i];
                }
            }

            Console.WriteLine($"{Environment.NewLine}Sum: {sum}");
        }
    }
}