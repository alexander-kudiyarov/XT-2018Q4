using System;

public class AnotherTraingle
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

public class AnotherTraingleDemo
{
    public static void Main()
    {
        AnotherTraingle ob = new AnotherTraingle();
        Console.WriteLine("Enter value  of N (N must be greater than 0)");
        try
        {
            ob.Draw(int.Parse(Console.ReadLine()));
        }
        catch (FormatException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}
