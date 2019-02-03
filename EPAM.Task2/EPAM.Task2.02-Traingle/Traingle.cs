using System;

namespace EPAM.Task2._02_Traingle
{
    public class Traingle
    {
        private double a;
        private double b;
        private double c;

        public Traingle(int a, int b, int c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        public Traingle()
            : this(1, 1, 1)
        {
        }

        public double A
        {
            get => this.a;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Sides of a triangle must be more than zero");
                }
                else
                {
                    this.a = value;
                }
            }
        }

        public double Area
        {
            get => Math.Sqrt(this.Semiperimeter * (this.Semiperimeter - this.A) * (this.Semiperimeter - this.B) * (this.Semiperimeter - this.C));
        }

        public double B
        {
            get => this.b;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Sides of a triangle must be more than zero");
                }
                else
                {
                    this.b = value;
                }
            }
        }

        public double C
        {
            get => this.c;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Sides of a triangle must be more than zero");
                }

                if (value >= this.A + this.B)
                {
                    throw new ArgumentException("Each side of a triangle should be less than sum of other sides");
                }
                else
                {
                    this.c = value;
                }
            }
        }

        public double Perimeter
        {
            get => this.A + this.B + this.C;
        }

        public double Semiperimeter
        {
            get => this.Perimeter / 2;
        }

        public override string ToString()
        {
            return $"Traingle parameters: A side: {this.A} | B side: {this.B} | C side: {this.C} | Perimeter: {this.Perimeter} | Area: {this.Area:#.##}";
        }
    }
}