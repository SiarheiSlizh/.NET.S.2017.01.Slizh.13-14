using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Square:Shape
    {
        private double x;

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

        public Square(double x)
        {
            X = x;
        }
    }
}
