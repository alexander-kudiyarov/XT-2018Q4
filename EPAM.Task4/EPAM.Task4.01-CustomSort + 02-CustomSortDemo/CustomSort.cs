﻿using System;
using System.Text;

namespace EPAM.Task4._01_CustomSort___02_CustomSortDemo
{
    public class CustomSort<T>
    {
        public CustomSort(T[] args)
        {
            this.Array = args;
        }

        private T[] Array { get; }

        public void QSort(Func<T, T, int> compare)
        {
            this.QSort(0, this.Array.Length - 1, compare);
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (var item in this.Array)
            {
                temp.Append($"{item} ");
            }

            return temp.ToString().Trim();
        }

        private void QSort(int b, int e, Func<T, T, int> compare)
        {
            int l = b;
            int r = e;
            T piv = this.Array[(l + r) / 2];
            while (l <= r)
            {
                while (compare(this.Array[l], piv) < 0)
                {
                    l++;
                }

                while (compare(this.Array[r], piv) > 0)
                {
                    r--;
                }

                if (l <= r)
                {
                    T temp;
                    temp = this.Array[l];
                    this.Array[l] = this.Array[r];
                    this.Array[r] = temp;
                    l++;
                    r--;
                }
            }

            if (b < r)
            {
                this.QSort(b, r, compare);
            }

            if (e > l)
            {
                this.QSort(l, e, compare);
            }
        }
    }
}