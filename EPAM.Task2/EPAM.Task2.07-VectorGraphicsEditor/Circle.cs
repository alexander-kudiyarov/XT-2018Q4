using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    internal class Circle : Shape
    {
        private double r;

        public Circle(double x, double y, double r) : base(x, y)
        {
            this.R = r;
        }

        public Circle()
            : this(1, 1, 1)
        {
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

        public override void Show()
        {
            Console.WriteLine($"Circle parameters" +
                    $"{Environment.NewLine}Center:\tx: {X}, y: {Y}" +
                    $"{Environment.NewLine}Radius:\t{R}" +
                    $"{Environment.NewLine}Length:\t{Length:#.##}");
        }
    }
}
