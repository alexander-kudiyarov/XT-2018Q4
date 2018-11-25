using System;

class AnotherTraingle
{
    public void Draw(int n)
    {
        if (n > 0)
        {
            for (int k = 1; k <= n; k++)
            {
                for (int i = 0; i < k; i++)
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
        try
        {
            ob.Draw(Int32.Parse(Console.ReadLine()));
        }
        catch(FormatException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}
