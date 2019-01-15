using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task0.Sequence
{
    public class SequenceDemo
    {
        public static void Main()
        {
            Sequence ob = new Sequence();
            Console.WriteLine("Please, enter value for N (N must be greater than 0)");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                ob.Show(n);
            }
        }
    }
}
