using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    internal class Round : Circle
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

        public override void Show()
        {
            Console.WriteLine($"Round parameters" +
                $"{Environment.NewLine}Center:\tx: {this.X}, y: {this.Y}" +
                $"{Environment.NewLine}Radius:\t{this.R}" +
                $"{Environment.NewLine}Length:\t{this.Length:#.##}" +
                $"{Environment.NewLine}Area:\t{this.Area:#.##}");
        }
    }
}
