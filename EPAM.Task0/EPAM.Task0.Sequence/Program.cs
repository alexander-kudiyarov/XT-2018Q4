using System;

namespace EPAM.Task0.Sequence
{
    class Sequence
    {
        public string Build(int n)
        {
            if (n > 0)
            {
                int[] nums = new int[n];
                string div = ", ";
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = i + 1;
                }
                string[] strTmp = new string[n * 2 - 1];
                for (int i = 0; i < strTmp.Length; i++)
                {
                    if ((i % 2) == 0)
                    {
                        strTmp[i] = nums[i / 2].ToString();
                    }
                    else
                    {
                        strTmp[i] = div;
                    }
                }
                string str = string.Join("", strTmp);
                return str;
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
            Console.WriteLine(ob.Build(100));
            Console.WriteLine(ob.Build(0));
            Console.WriteLine(ob.Build(-100));
        }
    }
}