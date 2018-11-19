using System;

namespace EPAM.Task0.Simple
{
    class Simple
    {
        public bool Check(int n)
        {
            bool isPrime = true;
            for (int i = 2; i <= (n / 2); i++)
            {
                if ((n % i) == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime & n > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class SimpleDemo
    {
        static void Main()
        {
            Simple ob = new Simple();
            Console.WriteLine("Please, enter value for N");
            int i = Int32.Parse(Console.ReadLine());
            if (ob.Check(i))
            {
                Console.WriteLine("{0}: prime number", i);
            }
            else
            {
                Console.WriteLine("{0}: non prime number", i);
            }
        }
    }
}