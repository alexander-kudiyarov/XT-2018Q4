using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._04_MyString
{
    internal class MyStringDemo
    {
        internal static void Main()
        {
            MyString ob1 = new MyString("First");
            MyString ob2 = new MyString("Second");
            Console.Write("ob1:\t\t\t\t");
            MyString.Show(ob1);
            Console.Write("ob2:\t\t\t\t");
            MyString.Show(ob2);
            Console.Write("Compare(ob1, ob2):\t\t");
            Console.WriteLine(MyString.Compare(ob1, ob2));
            Console.Write("ob1 + ob2:\t\t\t");
            MyString.Show(ob1 + ob2);
            Console.Write("Search 's' in ob1:\t\t");
            Console.WriteLine(ob1.IndexOf('s'));
            Console.Write("Convert MyString to char[]:\t");
            char[] ch = ob1.ToCharArray();
            foreach (char c in ch)
            {
                Console.Write(c);
            }

            Console.WriteLine();
            Console.Write("Convert char[] to MyString:\t");
            MyString ob3 = new MyString(ch);
            MyString.Show(ob3);
        }
    }
}
