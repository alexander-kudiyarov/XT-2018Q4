using System;

namespace EPAM.Task1._2_Traingle
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter value of N (N must be greater than 0):");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Traingle.Draw(n);
            }
        }
    }
}