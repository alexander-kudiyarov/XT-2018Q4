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
                Ring ob = new Ring(x, y, innerR, outerR);
                Console.WriteLine($"Ring parameters" +
                    $"{Environment.NewLine}Center:\t\tx: {ob.Inner.X}, y: {ob.Inner.Y}" +
                    $"{Environment.NewLine}Inner Radius:\t{ob.Inner.R}" +
                    $"{Environment.NewLine}Outer Radius:\t{ob.Outer.R}" +
                    $"{Environment.NewLine}Length:\t\t{ob.Length:#.##}" +
                    $"{Environment.NewLine}Area:\t\t{ob.Area:#.##}");
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
