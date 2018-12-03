using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._01_Round
{
    internal class Round
    {
        private double r;

        internal Round(double x, double y, double r)
        {
            this.X = x;
            this.Y = y;
            this.R = r;
        }

        internal double X { get; }

        internal double Y { get; }

        internal double R
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

        internal double Length
        {
            get => 2 * Math.PI * this.R;
        }

        internal double Area
        {
            get => Math.PI * (this.R * this.R);
        }
    }
}
