using System;

namespace EPAM.Task7._03_EmailFinder
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Enter your text with (or without) emails:{Environment.NewLine}");
            string inputText = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Emails in your text:{Environment.NewLine}");
            Console.WriteLine(EmailFinder.FindAllEmails(inputText));
        }
    }
}