using System;

namespace EPAM.Task0.Sequence
{
    public class SequenceDemo
    {
        public static void Main()
        {
            Console.WriteLine("Please, enter value for N (N must be greater than 0)");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Sequence.Show(n);
            }
        }
    }
}