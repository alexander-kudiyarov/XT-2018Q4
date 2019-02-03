using System;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public class Line : Shape
    {
        private double length;

        public Line()
            : this(1, 1, 1)
        {
        }

        public Line(double x, double y, double length) : base(x, y)
        {
            this.Length = length;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length should be positive");
                }
                else
                {
                    this.length = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Line parameters: Start: x = {X}, y = {Y} | Length: {Length}";
        }
    }
}