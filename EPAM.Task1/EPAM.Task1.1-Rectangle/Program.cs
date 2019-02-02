using System;

namespace EPAM.Task1._1_Rectangle
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter value of A side, greater than 0:");
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("Enter value of B side, greater than 0:");
                    if (int.TryParse(Console.ReadLine(), out int b))
                    {
                        var ob = new Rectangle(a, b);
                        Console.WriteLine(ob.Area());
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