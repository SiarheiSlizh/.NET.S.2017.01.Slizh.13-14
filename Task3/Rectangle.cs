using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Rectangle:Shape
    {
        private double x;
        private double y;

        public double X
        {
            get { return x; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                x = value;
            }
        }

        public double Y
        {
            get { return y; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                y = value;
            }
        }

        public Rectangle(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
