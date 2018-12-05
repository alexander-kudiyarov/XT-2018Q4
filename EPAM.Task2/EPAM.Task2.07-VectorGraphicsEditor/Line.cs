using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    internal class Line : Shape
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

        public override void Show()
        {
            Console.WriteLine($"Line parameters" +
                    $"{Environment.NewLine}Start:\tx: {X}, y: {Y}" +
                    $"{Environment.NewLine}Length:\t{Length}");
        }
    }
}
