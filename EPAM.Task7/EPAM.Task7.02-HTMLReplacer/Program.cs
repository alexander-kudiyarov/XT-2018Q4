using System;

namespace EPAM.Task7._02_HTMLReplacer
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Enter your text with (or without) HTML tags:{Environment.NewLine}");
            string text = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}This is your text with tags replaced to underscores:{Environment.NewLine}");
            Console.WriteLine(HTMLReplacer.ReplaceTagsToUnderscores(text));
        }
    }
}