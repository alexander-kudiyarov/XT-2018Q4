using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Task2._01_Round;

namespace EPAM.Task2._06_Ring
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
    }
}
