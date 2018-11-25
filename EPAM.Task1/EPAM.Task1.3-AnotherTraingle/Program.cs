using System;

class AnotherTraingle
{
    public void Draw(int n)
    {
        if (n > 0)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + i; j++)
                {
                    if (j < n - 1 - i)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("N must be greater than 0");
        }
    }
}
class AnotherTraingleDemo
{
    static void Main()
    {
        AnotherTraingle ob = new AnotherTraingle();
        Console.WriteLine("Please, enter value  of N (N must be greater than 0)");
        ob.Draw(Int32.Parse(Console.ReadLine()));
    }
}