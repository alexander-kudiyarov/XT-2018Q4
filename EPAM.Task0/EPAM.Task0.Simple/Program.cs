using System;

namespace EPAM.Task0.Simple
{
    public class SimpleDemo
    {
        public static void Main()
        {
            Console.WriteLine("Enter value for N");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine(Simple.Show(n));
            }
        }
    }
}