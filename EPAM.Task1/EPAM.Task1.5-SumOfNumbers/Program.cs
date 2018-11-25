using System;

namespace EPAM.Task1._5_SumOfNumbers
{
    class SumOfNumbers
    {
        public void Calc(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine("Sum equal {0}", sum);
        }
    }
    class SumOfNumbersDemo
    {
        static void Main()
        {
            SumOfNumbers ob = new SumOfNumbers();
            Console.WriteLine("Please, enter value  of N (N must be greater than 0)");
            ob.Calc(1000);
        }
    }
}