using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task0.Simple
{
    public class Simple
    {
        public bool Check(int n)
        {
            bool isPrime = true;
            for (int i = 2; i <= (n / 2); i++)
            {
                if ((n % i) == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime & n > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
