using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program<T>
    {
        public T[] array = new T[10];

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if (index == 0)
                {
                    throw new ArgumentOutOfRangeException($"index = {index}");
                }
                else
                {
                    array[index] = value;
                }
            }
        }
    }
    class Demo
    {
        static void Main()
        {
            Program<int> ob = new Program<int>();
            ob.array[0] = 1;
            Console.WriteLine(ob.array[0]);
        }
    }
}
