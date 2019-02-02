using System;

namespace EPAM.Task1._12_CharDoubler
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Please, enter the first string:\t\t");
            string str1 = Console.ReadLine();
            Console.Write("Please, enter the second string:\t");
            string str2 = Console.ReadLine();
            Console.WriteLine($"Result: {CharDoubler.Build(str1, str2)}");
        }
    }
}