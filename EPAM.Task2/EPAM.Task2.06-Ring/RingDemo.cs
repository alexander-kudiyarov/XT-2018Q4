using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._06_Ring
{
    internal class RingDemo
    {
        internal static void Main()
        {
            try
            {
                Console.WriteLine("Enter X coordinate");
                double x = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Y coordinate");
                double y = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Inner Radius");
                double innerR = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Outer Radius");
                double outerR = double.Parse(Console.ReadLine());

                Ring ring = new Ring(x, y, innerR, outerR);
                ring.Show();
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
