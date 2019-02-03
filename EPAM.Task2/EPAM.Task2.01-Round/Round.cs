using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._01_Round
{
    public class Round
    {
        private double r;

        public Round(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
        }

        public Round()
            : this(1, 1, 1)
        {
        }

        public double Area
        {
            get => Math.PI * (this.R * this.R);
        }

        public double Length
        {
            get => 2 * Math.PI * this.R;
        }

        public double R
        {
            get => this.r;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Radius should be positive");
                }
                else
                {
                    this.r = value;
                }
            }
        }

        public double X { get; }

        public double Y { get; }

        public override string ToString()
        {
            return $"Round parameters: Center: x = {this.X}, y = {this.Y} | Radius = {this.R} | Length = {this.Length:#.##} | Area = {this.Area:#.##}";
        }
    }
}
