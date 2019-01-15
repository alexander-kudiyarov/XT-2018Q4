using System;

namespace EPAM.Task7._03_EmailFinder
{
    public class Program
    {
        private static void Main()
        {
            EmailFinder ob = new EmailFinder();
            Console.WriteLine("Enter your text:");
            string inputText = Console.ReadLine();
            Console.WriteLine("Emails in your text:");
            Console.WriteLine(ob.FindAllEmails(inputText));
        }
    }
}