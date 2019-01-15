using System;

namespace EPAM.Task6._01_DateExistance
{
    public class Program
    {
        private static void Main()
        {
            DateExistance ob = new DateExistance();
            Console.WriteLine("Enter your text with date:");
            string text = Console.ReadLine();
            Console.WriteLine(ob.CheckForDate(text));
        }
    }
}