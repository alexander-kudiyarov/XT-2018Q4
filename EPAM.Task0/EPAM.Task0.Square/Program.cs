using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task0.Square
{
    public class SquareDemo
    {
        public static void Main()
        {
            Square ob = new Square();
            Console.WriteLine("Please, enter value for N (N must be odd and greater than one)");
            int n = int.Parse(Console.ReadLine());
            ob.Draw(n);
        }
    }
}
