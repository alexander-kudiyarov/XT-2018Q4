using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task3._04_DynamicArray
{
    public class Program
    {
        public static void Main(string[] args)
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

                Console.WriteLine("Use negative index");
                Console.WriteLine($"ob[-1]: {ob[-1]}" +
                    $"{Environment.NewLine}ob[-4]: {ob[-4]}");
                Console.WriteLine();

                Console.WriteLine("Manual change Capacity");

                ob.Capacity = 4;
                ob.DynamicArrayShow();

                Console.WriteLine("Using Clone()");
                DynamicArray<int> clone = (DynamicArray<int>)ob.Clone();
                clone.DynamicArrayShow();

                Console.WriteLine("Using ToArray()");
                foreach (var item in ob.ToArray())
                {
                    Console.Write($"{item} ");
                }
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
