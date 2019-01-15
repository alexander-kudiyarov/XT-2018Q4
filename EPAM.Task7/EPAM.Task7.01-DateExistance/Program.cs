using System;

namespace EPAM.Task6._01_DateExistance
{
    public class Program
    {
        private static void Main()
        {
            string text;

            Console.WriteLine("Enter your text:");

            text = Console.ReadLine();

            if (DateExistance.CheckForDate(text))
            {
                Console.WriteLine($"This text contain correct date: {DateExistance.Date:D}");
            }
            else
            {
                Console.WriteLine($"This text not contain correct date");
            }
        }
    }
}