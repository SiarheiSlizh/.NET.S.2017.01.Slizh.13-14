using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class ShapeExtensions
    {
        public static double GetArea(this Shape shape)
        {
            if (ReferenceEquals(shape, null))
                throw new ArgumentNullException(nameof(shape));

            var visitor = new AreaVisitor();
            shape.Accept(visitor);
            return visitor.Area;
        }

        public static double GetPerimeter(this Shape shape)
        {
            if (ReferenceEquals(shape, null))
                throw new ArgumentNullException(nameof(shape));

            var visitor = new PerimeterVisitor();
            shape.Accept(visitor);
            return visitor.Perimeter;
        }
    }
}
