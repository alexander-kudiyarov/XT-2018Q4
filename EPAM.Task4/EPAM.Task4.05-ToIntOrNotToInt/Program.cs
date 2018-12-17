using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task4._05_ToIntOrNotToInt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please, enter your number:");
                string a = Console.ReadLine();
                Console.WriteLine($"{a.IsNaturalNumber()}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Something goes wrong, omg!");
            }
        }
    }
}
