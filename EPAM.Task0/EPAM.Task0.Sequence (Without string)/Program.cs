using System;
using System.Text;

namespace EPAM.Task0.Sequence
{
    class Sequence
    {
        public void Build(int n)
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
    class SequenceDemo
    {
        static void Main()
        {
            Sequence ob = new Sequence();
            Console.WriteLine("Please, enter value for N (N must be greater than 0)");
            ob.Build(Int32.Parse(Console.ReadLine()));
        }
    }
}