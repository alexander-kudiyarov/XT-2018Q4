using System;
using System.Text;

namespace EPAM.Task0.Sequence
{
    class Sequence
    {
        public string Build(int n)
        {
            if (n > 0)
            {
                StringBuilder str = new StringBuilder();
                for (int i = 1; i <= n; i++)
                {
                    if (i != n)
                    {
                        str.AppendFormat("{0}, ", i);
                    }
                    else
                        str.AppendFormat("{0}", i);
                }
                return str.ToString();
            }
            else
            {
                string err = "N must be greater than 0";
                return err;
            }
        }
    }
    class SequenceDemo
    {
        static void Main()
        {
            Sequence ob = new Sequence();
            Console.WriteLine("Please, enter value for N (N must be greater than 0)");
            Console.WriteLine(ob.Build(Int32.Parse(Console.ReadLine())));
        }
    }
}