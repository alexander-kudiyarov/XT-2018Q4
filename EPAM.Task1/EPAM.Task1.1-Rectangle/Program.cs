using System;

namespace EPAM.Task1.Rectangle
{
    public class Rectangle
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

    public class RectangleDemo
    {
        public static void Main()
        {
            Rectangle ob = new Rectangle();
            try
            {
                Console.WriteLine("Enter value of A side (must be greater than 0)");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter value of B side (must be greater than 0)");
                int b = int.Parse(Console.ReadLine());
                ob.Calc(a, b);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
