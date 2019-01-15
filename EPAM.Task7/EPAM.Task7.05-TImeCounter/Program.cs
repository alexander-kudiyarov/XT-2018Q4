using System;

namespace EPAM.Task7._05_TImeCounter
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Enter your text with (or without) times:{Environment.NewLine}");
            string text = Console.ReadLine();
            Console.WriteLine(TimeCounter.ShowTimeCounter(text));
        }
    }
}