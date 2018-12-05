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

                Traingle traingle = new Traingle(a, b, c);
                traingle.Show();
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
