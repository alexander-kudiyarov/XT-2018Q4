﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._02_Traingle
{
    internal class Traingle
    {
        private double c;

        internal Traingle(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        internal double A { get; }

        internal double B { get; }

        internal double C
        {
            get => this.c;
            private set
            {
                if (value >= this.A + this.B)
                {
                    throw new ArgumentException("Each side of a triangle must be less than sum of other sides");
                }
                else
                {
                    this.c = value;
                }
            }
        }

        internal double Perimeter
        {
            get => this.A + this.B + this.C;
        }

        internal double Semiperimeter
        {
            get => this.Perimeter / 2;
        }

        internal double Area
        {
            get => Math.Sqrt(this.Semiperimeter * (this.Semiperimeter - this.A) * (this.Semiperimeter - this.B) * (this.Semiperimeter - this.C));
        }
    }
}