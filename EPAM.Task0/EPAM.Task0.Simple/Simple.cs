using System;

namespace EPAM.Task0.Simple
{
    public static class Simple
    {
        public static bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % 2 == 0 || n % 10 == 0 || n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static string Show(int n)
        {
            if (IsPrime(n))
            {
                return $"{n} is prime number";
            }
            else
            {
                return $"{n} is composite number";
            }
        }
    }
}