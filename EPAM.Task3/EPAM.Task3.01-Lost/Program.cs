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
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    Lost circle = new Lost(n);
                    Console.WriteLine($"Origin circle: {circle.ToString()}");

                    circle.ClearCircle();
                    Console.WriteLine($"Cleared circle: {circle.ToString()}");
                }
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
