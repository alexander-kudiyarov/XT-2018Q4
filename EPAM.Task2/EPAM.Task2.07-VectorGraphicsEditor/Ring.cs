using System;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public class Ring
    {
        public Ring(double x, double y, double inR, double outR)
        {
            if (outR <= inR)
            {
                throw new ArgumentException("Outer radius must be greater than inner radius");
            }
            else
            {
                this.Inner = new Round(x, y, inR);
                this.Outer = new Round(x, y, outR);
            }
        }

        public Ring()
            : this(1, 1, 1, 1.1)
        {
        }

        public double Area
        {
            get => this.Outer.Area - this.Inner.Area;
        }

        public Round Inner { get; }

        public double Length
        {
            get => (2 * Math.PI * this.Inner.R) + (2 * Math.PI * this.Outer.R);
        }

        public Round Outer { get; }

        public override string ToString()
        {
            return $"Ring parameters: Center: x = {this.Inner.X}, y = {this.Inner.Y} | Inner Radius: {this.Inner.R} | Outer Radius: {this.Outer.R} | Length: {this.Length:#.##} | Area: {this.Area:#.##}";
        }
    }
}