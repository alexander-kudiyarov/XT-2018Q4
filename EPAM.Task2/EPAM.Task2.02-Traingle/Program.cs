using System;

namespace EPAM.Task2._02_Traingle
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter length of A side");
                if (int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("Enter length of B side");
                    if (int.TryParse(Console.ReadLine(), out int b))
                    {
                        Console.WriteLine("Enter length of C side");
                        if (int.TryParse(Console.ReadLine(), out int c))
                        {
                            var traingle = new Traingle(a, b, c);
                            Console.WriteLine(traingle.ToString());
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