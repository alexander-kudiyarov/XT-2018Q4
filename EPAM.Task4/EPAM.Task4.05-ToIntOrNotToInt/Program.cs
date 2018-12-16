using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task4._05_ToIntOrNotToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "asdase+050";
            Console.WriteLine($"{a}: {a.IsNaturalNumber()}");
            Console.WriteLine(a.ExpCalc());

            string b = "3.14E-10";
            Console.WriteLine($"{b}: {b.IsNaturalNumber()}");
            Console.WriteLine(b.ExpCalc());

            string c = "10";
            Console.WriteLine($"{c}: {c.IsNaturalNumber()}");

            string d = "-100";
            Console.WriteLine($"{d}: {d.IsNaturalNumber()}");
        }
    }
}
