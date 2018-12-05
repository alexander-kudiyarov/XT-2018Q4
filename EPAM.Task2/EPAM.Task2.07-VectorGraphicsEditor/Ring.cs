using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    internal class Ring
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

        internal Round Inner { get; }

        internal Round Outer { get; }

        internal double Length
        {
            get => (2 * Math.PI * this.Inner.R) + (2 * Math.PI * this.Outer.R);
        }

        internal double Area
        {
            get => this.Outer.Area - this.Inner.Area;
        }

        public void Show()
        {
            Console.WriteLine($"Ring parameters" +
                $"{Environment.NewLine}Center:\t\tx: {this.Inner.X}, y: {this.Inner.Y}" +
                $"{Environment.NewLine}Inner Radius:\t{this.Inner.R}" +
                $"{Environment.NewLine}Outer Radius:\t{this.Outer.R}" +
                $"{Environment.NewLine}Length:\t\t{this.Length:#.##}" +
                $"{Environment.NewLine}Area:\t\t{this.Area:#.##}");
        }
    }
}
