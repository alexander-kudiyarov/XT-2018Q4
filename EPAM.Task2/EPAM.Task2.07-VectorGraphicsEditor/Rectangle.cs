using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public class Rectangle
    {
        public Rectangle(double x, double y, double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException("Sides should be positive");
            }
            else
            {
                this.A = new Line(x, y, a);
                this.B = new Line(x, y, b);
            }
        }

        public Rectangle()
            : this(1, 1, 1, 1)
        {
        }

        public Line A { get; }

        public double Area
        {
            get => this.A.Length * this.B.Length;
        }

        public Line B { get; }

        public override string ToString()
        {
            return $"Rectangle parameters: Start: x = {A.X}, y = {A.Y} | A: {A.Length} | B: {B.Length} | Area: {Area}";
        }
    }
}
