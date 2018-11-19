using System;

namespace EPAM.Task0.Square
{
    class Square
    {
        public void Draw(int n)
        {
            if (n % 2 != 0 & n > 1)
            {
                string str = new string('*', n);
                string half_str = new string('*', (n / 2));
                for (int i = 0; i < n; i++)
                {
                    if (i == n / 2)
                        Console.WriteLine("{0} {0}", half_str);
                    else
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            else
            {
                Console.WriteLine("N must be odd and greater than one.");
            }
        }
    }
    class SquareDemo
    {
        static void Main()
        {
            Square ob = new Square();
            Console.WriteLine("Please, enter value for N (N must be odd and greater than one)");
            ob.Draw(Int32.Parse(Console.ReadLine()));
        }
    }
}