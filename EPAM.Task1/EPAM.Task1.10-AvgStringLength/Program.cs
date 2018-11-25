using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task1._10_AvgStringLength
{
    class AvgStringLength
    {
        public void Calc()
        {
            string input = new string(Console.ReadLine());
            Console.WriteLine(input);
        }
    }
    class AvgStringLengthDemo
    {
        static void Main()
        {
            AvgStringLength ob = new AvgStringLength();
            ob.Calc();
        }
    }
}
