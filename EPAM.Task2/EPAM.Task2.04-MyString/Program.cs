using System;

namespace EPAM.Task2._04_MyString
{
    public class Program
    {
        public static void Main()
        {
            MyString ob1 = new MyString("First");
            MyString ob2 = new MyString("Second");

            Console.WriteLine($"ob1:\t\t\t\t{ob1.ToString()}");

            Console.WriteLine($"ob2:\t\t\t\t{ob2.ToString()}");

            Console.WriteLine($"ob1 == ob2:\t\t\t{ob1 == ob2}");
            Console.WriteLine($"ob1 != ob2:\t\t\t{ob1 != ob2}");

            Console.Write("Compare(ob1, ob2):\t\t");
            Console.WriteLine(MyString.Compare(ob1, ob2));

            Console.WriteLine($"ob1 + ob2:\t\t\t{(ob1 + ob2).ToString()}");

            Console.Write("Search 's' in ob1:\t\t");
            Console.WriteLine(ob1.IndexOf('s'));

            Console.Write("Convert MyString to char[]:\t");
            char[] ch = ob1.ToCharArray();
            foreach (char c in ch)
            {
                Console.Write(c);
            }

            Console.WriteLine();

            MyString ob3 = new MyString(ch);
            Console.WriteLine($"Convert char[] to MyString:\t{ob3.ToString()}");
        }
    }
}