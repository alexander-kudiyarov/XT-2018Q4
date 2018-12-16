using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task4._04_NumberArraySum
{
    public static class NumberArraySum
    {
        public static byte Sum(this byte[] input)
        {
            byte sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static sbyte Sum(this sbyte[] input)
        {
            sbyte sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static short Sum(this short[] input)
        {
            short sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static ushort Sum(this ushort[] input)
        {
            ushort sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static int Sum(this int[] input)
        {
            int sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static uint Sum(this uint[] input)
        {
            uint sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static long Sum(this long[] input)
        {
            long sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static ulong Sum(this ulong[] input)
        {
            ulong sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static float Sum(this float[] input)
        {
            float sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static double Sum(this double[] input)
        {
            double sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }

        public static decimal Sum(this decimal[] input)
        {
            decimal sum = 0;
            foreach (var num in input)
            {
                sum += num;
            }

            return sum;
        }
    }
}
