using System;

namespace EPAM.Task0.Simple
{
    public class SimpleDemo
    {
        public static void Main()
        {
            Simple ob = new Simple();
            Console.WriteLine("Please, enter value for N");
            int n = int.Parse(Console.ReadLine());
            if (ob.Check(n))
            {
                Console.WriteLine("{0}: prime number", n);
            }
            else
            {
                Console.WriteLine("{0}: non prime number", n);
            }
        }
    }
}
