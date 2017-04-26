using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Triangle:Shape
    {
        private double x;
        private double y;
        private double z;

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

        public double Z
        {
            get { return z; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                z = value;
            }
        }

        public Triangle(double x, double y, double z)
        {
            if (!CheckExistingTriangle(x, y, z))
                throw new ArgumentException();

            X = x;
            Y = y;
            Z = z;
        }

        private bool CheckExistingTriangle(double x, double y, double z) => x < y + z || y < x + z || z < x + y ? true : false;
    }
}
