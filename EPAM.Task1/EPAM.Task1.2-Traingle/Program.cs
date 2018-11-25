using System;

class Traingle
{
    public void Draw(int n)
    {
        if (n > 0)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
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
class TraingleDemo
{
    static void Main()
    {
        Traingle ob = new Traingle();
        Console.WriteLine("Enter value  of N (N must be greater than 0)");
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
