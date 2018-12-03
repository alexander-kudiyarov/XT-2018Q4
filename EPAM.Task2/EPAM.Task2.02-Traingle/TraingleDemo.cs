using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._02_Traingle
{
    internal class TraingleDemo
    {
        internal static void Main()
        {
            try
            {
                Console.WriteLine("Enter length of A side");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter length of B side");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter length of C side");
                int c = int.Parse(Console.ReadLine());
                Traingle ob = new Traingle(a, b, c);
                Console.WriteLine($"Traingle parameters:" +
                    $"{Environment.NewLine}A side:\t\t{ob.A}" +
                    $"{Environment.NewLine}B side:\t\t{ob.B}" +
                    $"{Environment.NewLine}C side:\t\t{ob.C}" +
                    $"{Environment.NewLine}Perimeter:\t{ob.Perimeter}" +
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
