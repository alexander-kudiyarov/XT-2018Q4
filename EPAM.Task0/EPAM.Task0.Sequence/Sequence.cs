using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task0.Sequence
{
    public class Sequence
    {
        public void Show(int n)
        {
            if (n > 0)
            {
                for (int i = 1; i < n; i++)
                {
                    Console.Write("{0}, ", i);
                }

                Console.WriteLine(n);
            }
            else
            {
                Console.WriteLine("N must be greater than 0");
            }
        }
    }
}
