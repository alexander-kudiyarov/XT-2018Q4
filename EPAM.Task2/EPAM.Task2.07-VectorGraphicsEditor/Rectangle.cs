using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    internal class Rectangle
    {
        public Rectangle(double x, double y, double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new ArgumentException("Sides must be greater than 0");
            }
            else
            {
                this.A = new Line(x, y, a);
                this.B = new Line(x, y, b);
            }
        }

        internal Line A { get; }

        internal Line B { get; }

        internal double Area
        {
            get => this.A.Length * this.B.Length;
        }

        public void Show()
        {
            Console.WriteLine($"Rectangle parameters" +
                    $"{Environment.NewLine}Start:\tx: {A.X}, y: {A.Y}" +
                    $"{Environment.NewLine}A:\t{A.Length}" +
                    $"{Environment.NewLine}B:\t{B.Length}" +
                    $"{Environment.NewLine}Area:\t{Area}");
        }
    }
}
