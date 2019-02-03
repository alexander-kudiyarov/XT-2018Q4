using System;

namespace EPAM.Task2._01_Round
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter X coordinate");
                if (double.TryParse(Console.ReadLine(), out double x))
                {
                    Console.WriteLine("Enter Y coordinate");
                    if (double.TryParse(Console.ReadLine(), out double y))
                    {
                        Console.WriteLine("Enter Radius");
                        if (double.TryParse(Console.ReadLine(), out double r))
                        {
                            var round = new Round(x, y, r);
                            Console.WriteLine(round.ToString());
                        }
                    }
                }
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}