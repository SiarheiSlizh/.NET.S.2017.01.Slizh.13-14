using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;

namespace Task3Tests
{
    [TestFixture]
    public class ShapesTests
    {
        [TestCase(6)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(22)]
        public void Circle_Area(double r)
        {
            var circle = new Circle(r);
            double actual = circle.GetArea();
            double expected = Math.PI * Math.Pow(r, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(22)]
        public void Circle_Perimeter(double r)
        {
            var circle = new Circle(r);
            double actual = circle.GetPerimeter();
            double expected = 2 * Math.PI * r;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(22)]
        public void Square_Area(double x)
        {
            var square = new Square(x);
            double actual = square.GetArea();
            double expected = x * x;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(22)]
        public void Square_Perimeter(double x)
        {
            var square = new Square(x);
            double actual = square.GetPerimeter();
            double expected = 4 * x;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 4)]
        [TestCase(2, 3)]
        [TestCase(10, 1)]
        [TestCase(22, 11)]
        public void Rectangle_Area(double x, double y)
        {
            var rectangle = new Rectangle(x, y);
            double actual = rectangle.GetArea();
            double expected = x * y;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6,4)]
        [TestCase(2,3)]
        [TestCase(10,1)]
        [TestCase(22,11)]
        public void Rectangle_Perimeter(double x, double y)
        {
            var rectangle = new Rectangle(x, y);
            double actual = rectangle.GetPerimeter();
            double expected = (x + y) * 2;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 4, 3)]
        [TestCase(2, 3, 4)]
        [TestCase(10, 1, 10)]
        [TestCase(22, 11, 14)]
        public void Triangle_Area(double x, double y, double z)
        {
            var triangle = new Triangle(x, y, z);
            double actual = triangle.GetArea();
            double p = (x + y + z) / 2;
            double expected = Math.Sqrt(p * (p - x) * (p - y) * (p - z));
            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 4, 3)]
        [TestCase(2, 3, 4)]
        [TestCase(10, 1, 10)]
        [TestCase(22, 11, 14)]
        public void Triangle_Perimeter(double x, double y, double z)
        {
            var triangle = new Triangle(x, y, z);
            double actual = triangle.GetPerimeter();
            double expected = x + y + z;
            Assert.AreEqual(expected, actual);
        }
    }
}
