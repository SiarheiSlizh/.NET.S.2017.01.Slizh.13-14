using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class AreaVisitor : IShapeVisitor
    {
        public double Area { get; private set; }

        public void Visit(Triangle triangle)
        {
            double p = (triangle.X + triangle.Y + triangle.Z) / 2;
            Area = Math.Sqrt(p * (p - triangle.X) * (p - triangle.Y) * (p - triangle.Z));
        }

        public void Visit(Square square) => Area = square.X * square.X;

        public void Visit(Rectangle rectangle) => Area = rectangle.X * rectangle.Y;

        public void Visit(Circle circle) => Area = Math.PI * Math.Pow(circle.Radius, 2);
    }
}
