using System;

namespace EPAM.Task7._04_NumberValidator
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Enter your number:{Environment.NewLine}");
            string number = Console.ReadLine();
            Console.WriteLine(NumberValidator.NumberForm(number));
        }
    }
}