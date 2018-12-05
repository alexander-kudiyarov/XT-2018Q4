using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public abstract class Shape
    {
        public Shape(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Shape()
            : this(1, 1)
        {
        }

        public double X { get; }

        public double Y { get; }

        public abstract void Show();
    }
}
