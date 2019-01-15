using System;

namespace EPAM.Task7._03_EmailFinder
{
    public class Program
    {
        private static void Main()
        {
            string text = Console.ReadLine();
            EmailFinder ob = new EmailFinder(text);
            ob.FindAllEmails();
            Console.WriteLine(ob.ToString());
        }
    }
}