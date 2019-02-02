namespace EPAM.Task1._5_SumOfNumbers
{
    public static class SumOfNumbers
    {
        public static string Calc(int n)
        {
            int sum = 0;
            for (int i = 3; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return $"Sum of multiples of three and five from 1 to {n}: {sum}";
        }
    }
}