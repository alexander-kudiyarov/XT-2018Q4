using System;

namespace EPAM.Task7._03_EmailFinder
{
    public class Program
    {
        private static void Main()
        {
            EmailFinder ob = new EmailFinder();
            string inputText = Console.ReadLine();
            ob.FindAllEmails(inputText);
            Console.WriteLine(ob.ToString());
        }
    }
}