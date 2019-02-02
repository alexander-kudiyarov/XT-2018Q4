using System;

namespace EPAM.Task1._5_SumOfNumbers
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter value of N:");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine(SumOfNumbers.Calc(n));
            }
        }
    }
}