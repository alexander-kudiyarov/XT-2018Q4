using System;

namespace EPAM.Task1._4_XmasTree
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter value of N (N must be greater than 0):");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                XmasTree.Draw(n);
            }
        }
    }
}