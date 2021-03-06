﻿using System;

namespace EPAM.Task2._07_VectorGraphicsEditor
{
    public class Circle : Shape
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

        public override string ToString()
        {
            return $"Circle parameters: Center: x = {X}, y = {Y} | Radius: {R} | Length: {Length:#.##}";
        }
    }
}