using System;

namespace EPAM.Task4._04_NumberArraySum
{
    public class Program
    {
        public static void Main()
        {
            int n = 10;

            byte[] byteArray = new byte[n];
            Console.Write($"{byteArray.GetType()}:\t  ");
            for (byte i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = (byte)(i + 1);
                Console.Write($"{byteArray[i]} ");
            }

            Console.WriteLine($"\tSum: {byteArray.Sum()}");

            sbyte[] sbyteArray = new sbyte[n];
            Console.Write($"{sbyteArray.GetType()}:\t  ");
            for (sbyte i = 0; i < sbyteArray.Length; i++)
            {
                sbyteArray[i] = (sbyte)(i + 1);
                Console.Write($"{sbyteArray[i]} ");
            }

            Console.WriteLine($"\tSum: {sbyteArray.Sum()}");

            short[] shortArray = new short[n];
            Console.Write($"{shortArray.GetType()}:\t  ");
            for (short i = 0; i < shortArray.Length; i++)
            {
                shortArray[i] = (short)(i + 1);
                Console.Write($"{shortArray[i]} ");
            }

            Console.WriteLine($"\tSum: {shortArray.Sum()}");

            ushort[] ushortArray = new ushort[n];
            Console.Write($"{ushortArray.GetType()}:  ");
            for (ushort i = 0; i < ushortArray.Length; i++)
            {
                ushortArray[i] = (ushort)(i + 1);
                Console.Write($"{ushortArray[i]} ");
            }

            Console.WriteLine($"\tSum: {ushortArray.Sum()}");

            int[] intArray = new int[n];
            Console.Write($"{intArray.GetType()}:\t  ");
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i + 1;
                Console.Write($"{intArray[i]} ");
            }

            Console.WriteLine($"\tSum: {intArray.Sum()}");

            uint[] uintArray = new uint[n];
            Console.Write($"{uintArray.GetType()}:  ");
            for (uint i = 0; i < uintArray.Length; i++)
            {
                uintArray[i] = i + 1;
                Console.Write($"{uintArray[i]} ");
            }

            Console.WriteLine($"\tSum: {uintArray.Sum()}");

            long[] longArray = new long[n];
            Console.Write($"{longArray.GetType()}:\t  ");
            for (long i = 0; i < longArray.Length; i++)
            {
                longArray[i] = i + 1;
                Console.Write($"{longArray[i]} ");
            }

            Console.WriteLine($"\tSum: {longArray.Sum()}");

            ulong[] ulongArray = new ulong[n];
            Console.Write($"{ulongArray.GetType()}:  ");
            for (ulong i = 0; i < (ulong)ulongArray.Length; i++)
            {
                ulongArray[i] = i + 1;
                Console.Write($"{ulongArray[i]} ");
            }

            Console.WriteLine($"\tSum: {ulongArray.Sum()}");

            float[] floatArray = new float[n];
            Console.Write($"{floatArray.GetType()}:  ");
            for (int i = 0; i < floatArray.Length; i++)
            {
                floatArray[i] = i + 1;
                Console.Write($"{floatArray[i]} ");
            }

            Console.WriteLine($"\tSum: {floatArray.Sum()}");

            double[] doubleArray = new double[n];
            Console.Write($"{doubleArray.GetType()}:  ");
            for (int i = 0; i < doubleArray.Length; i++)
            {
                doubleArray[i] = i + 1;
                Console.Write($"{doubleArray[i]} ");
            }

            Console.WriteLine($"\tSum: {doubleArray.Sum()}");

            decimal[] decimalArray = new decimal[n];
            Console.Write($"{decimalArray.GetType()}: ");
            for (int i = 0; i < decimalArray.Length; i++)
            {
                decimalArray[i] = i + 1;
                Console.Write($"{decimalArray[i]} ");
            }

            Console.WriteLine($"\tSum: {decimalArray.Sum()}");
        }
    }
}