using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._01_Lost
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine($"Enter N, greater than one");
                int n = int.Parse(Console.ReadLine());
                Lost ob = new Lost(n);
                Console.WriteLine($"Origin circle:");
                ob.ShowCircle();
                ob.ClearCircle();
                Console.WriteLine($"Cleared circle:");
                ob.ShowCircle();
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (OverflowException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
