using System;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public class Round : Circle
    {
        public Round(double x, double y, double r) : base(x, y, r)
        {
        }

        public Round()
            : this(1, 1, 1)
        {
        }

        public double Area
        {
            get => Math.PI * (this.R * this.R);
        }

        public override string ToString()
        {
            return $"Round parameters: Center: x = {this.X}, y = {this.Y} | Radius: {this.R} | Length: {this.Length:#.##} | Area: {this.Area:#.##}";
        }
    }
}