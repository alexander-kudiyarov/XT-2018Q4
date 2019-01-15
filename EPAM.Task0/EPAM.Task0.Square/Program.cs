using System;

namespace EPAM.Task0.Square
{
    public class SquareDemo
    {
        public static void Main()
        {
            Console.WriteLine("Please, enter value for N (N must be odd and greater than one)");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Square.Draw(n);
            }
        }
    }
}