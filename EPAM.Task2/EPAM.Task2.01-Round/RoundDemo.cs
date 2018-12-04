using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._01_Round
{
    internal class RoundDemo
    {
        internal static void Main()
        {
            try
            {
                Console.WriteLine("Enter X coordinate");
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Y coordinate");
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Radius");
                double r = double.Parse(Console.ReadLine());
                Round ob = new Round(x, y, r);
                Console.WriteLine($"Round parameters" +
                    $"{Environment.NewLine}Center:\tx: {ob.X}, y: {ob.Y}" +
                    $"{Environment.NewLine}Radius:\t{ob.R}" +
                    $"{Environment.NewLine}Length:\t{ob.Length:#.##}" +
                    $"{Environment.NewLine}Area:\t{ob.Area:#.##}");
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
