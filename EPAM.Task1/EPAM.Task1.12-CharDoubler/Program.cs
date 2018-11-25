using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task1._12_CharDoubler
{
    class CharDoubler
    {
        string str1 = "написать программу, которая";
        string str2 = "описание";
        public void Build()
        {
            StringBuilder chars = new StringBuilder();
            for (int i = 0; i < str2.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str2[i] != chars[j])
                    {
                        chars.Append(str2[i]);
                    }
                }
            }
            Console.WriteLine(chars);
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
