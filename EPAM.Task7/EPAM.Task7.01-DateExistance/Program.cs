using System;

namespace EPAM.Task6._01_DateExistance
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Enter your text with (or without) date:{Environment.NewLine}");
            string text = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Result:{Environment.NewLine}");
            Console.WriteLine(DateExistance.CheckForDate(text));
        }
    }
}