using System;

namespace EPAM.Task2._06_Ring
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
                        Console.WriteLine("Enter Inner Radius");
                        if (double.TryParse(Console.ReadLine(), out double innerR))
                        {
                            Console.WriteLine("Enter Outer Radius");
                            if (double.TryParse(Console.ReadLine(), out double outerR))
                            {
                                Ring ring = new Ring(x, y, innerR, outerR);
                                Console.WriteLine(ring.ToString());
                            }
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