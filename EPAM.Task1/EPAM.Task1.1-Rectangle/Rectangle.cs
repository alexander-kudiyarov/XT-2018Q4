using System;

namespace EPAM.Task1._1_Rectangle
{
    public class Rectangle
    {
        private int a;
        private int b;

        public Rectangle() : this(1, 1)
        {
        }

        public Rectangle(int x, int y)
        {
            this.A = x;
            this.B = y;
        }

        private int A
        {
            set
            {
                if (value > 0)
                {
                    this.a = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private int B
        {
            set
            {
                if (value > 0)
                {
                    this.b = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string Area()
        {
            return $"Area of rectangle: {a * b}";
        }
    }
}