using System;

namespace EPAM.Task1._5_SumOfNumbers
{
    public class SumOfNumbers
    {
        public void Calc(int n)
        {
            int sum = 0;
            for (int i = 3; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"Sum of multiples of three and five from 1 to {n}: {sum}");
        }
    }

    public class SumOfNumbersDemo
    {
        public static void Main()
        {
            SumOfNumbers ob = new SumOfNumbers();
            ob.Calc(1000);
        }
    }
}
