using System;

namespace EPAM.Task1.Rectangle
{
    class Rectangle
    {
        public void Calc(int a, int b)
        {
            if (a < 1 || b < 1)
            {
                Console.WriteLine("Values must be greater than 0");
            }
            else
            {
                Console.WriteLine($"Area of rectangle: {a * b}");
            }
        }
    }
    class RectangleDemo
    {
        static void Main()
        {
            Rectangle ob = new Rectangle();
            try
            {
                Console.WriteLine("Please, enter value of A side (must be greater than 0)");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Please, enter value of B side (must be greater than 0)");
                int b = Int32.Parse(Console.ReadLine());
                ob.Calc(a, b);
            }
            catch(FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
