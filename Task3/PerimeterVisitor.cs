using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class PerimeterVisitor : IShapeVisitor
    {
        public double Perimeter { get; private set; }

        public void Visit(Triangle triangle) => Perimeter = triangle.X + triangle.Y + triangle.Z;

        public void Visit(Square square) => Perimeter = square.X * 4;

        public void Visit(Rectangle rectangle) => Perimeter = (rectangle.X + rectangle.Y) * 2;

        public void Visit(Circle circle) => Perimeter = 2 * Math.PI * circle.Radius;
    }
}
