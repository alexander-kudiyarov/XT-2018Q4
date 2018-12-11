using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._04_DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DynamicArray<int> ob = new DynamicArray<int>(10);

                Console.WriteLine("Filling with Add()");
                for (int i = 0; i < ob.Capacity; i++)
                {
                    ob.Add(i);
                }
                ob.DynamicArrayShow();

                Console.WriteLine("Using AddRange()");
                int[] tmp = { 6, 6, 6 };
                ob.AddRange(tmp);
                ob.DynamicArrayShow();

                Console.WriteLine("Using Remove()");
                ob.Remove(7);
                ob.DynamicArrayShow();

                Console.WriteLine("Using Insert()");
                ob.Insert(0, 7);
                ob.DynamicArrayShow();

            }
            catch(ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
