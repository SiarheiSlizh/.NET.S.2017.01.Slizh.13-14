using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Circle: Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }
    }
}
