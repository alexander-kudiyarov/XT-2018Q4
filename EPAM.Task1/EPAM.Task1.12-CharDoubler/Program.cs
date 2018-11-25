using System;
using System.Linq;
using System.Text;

namespace Epam.Task1_1._12_CharDoubler
{
    class CharDoubler
    {
        public void Build()
        {
            Console.Write("Please, enter the first string:\t\t");
            string str1 = Console.ReadLine();
            Console.Write("Please, enter the second string:\t");
            string str2 = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str1.Length; i++)
            {
                result.Append(str1[i]);
                if (str2.Contains(str1[i]))
                {
                    result.Append(str1[i]);
                }
            }
            Console.WriteLine($"Result string:\t\t\t\t{result}");
        } 
    }
    class CharDoublerDemo
    {
        static void Main()
        {
            CharDoubler ob = new CharDoubler();
            ob.Build();
        }
    }
}