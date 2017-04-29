using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace Task4Tests
{
    [TestFixture]
    public class MatrixesTests
    {
        private int[,] array = { { 4, 6, 1, 2 }, { 5, 2, 9, 8 }, { 3, 5, 2, 6 }, { 1, 1, 33, 4 } };

        class Add : ISum<int>
        {
            public int Sum(int first, int second) => first + second;
        }

        [Test]
        public void SquareMatrixSum()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(4, array);
            SquareMatrix<int> s1 = new SquareMatrix<int>(4, array);
            Matrix<int> actual = s.Sum(s1, new Add());
            Matrix<int> expected = new SquareMatrix<int>(4, new int[,] { { 8, 12, 2, 4 }, { 10, 4, 18, 16 }, { 6, 10, 4, 12 }, { 2, 2, 66, 8 } });
            for (int i = 0; i < Math.Sqrt(actual.Length); i++)
                for (int j = 0; j < Math.Sqrt(actual.Length); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }

        [Test]
        public void DiagonalMatrixSum()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(4, array);
            DiagonalMatrix<int> s1 = new DiagonalMatrix<int>(4);
            Matrix<int> actual = s.Sum(s1, new Add());
            Matrix<int> expected = new SquareMatrix<int>(4, new int[,] { { 4, 6, 1, 2 }, { 5, 2, 9, 8 }, { 3, 5, 2, 6 }, { 1, 1, 33, 4 } });
            for (int i = 0; i < Math.Sqrt(actual.Length); i++)
                for (int j = 0; j < Math.Sqrt(actual.Length); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }

        [Test]
        public void SymmetricMatrixSum()
        {
            SquareMatrix<int> s = new SquareMatrix<int>(4, array);
            SymmetricMatrix<int> s1 = new SymmetricMatrix<int>(4, new int[,] { { 1, 2, 3, 4 }, { 2, 0, 0, 0 }, { 3, 0, 0, 0 }, { 4, 0, 0, 0 } });
            Matrix<int> actual = s.Sum(s1, new Add());
            Matrix<int> expected = new SquareMatrix<int>(4, new int[,] { { 5, 8, 4, 6 }, { 7, 2, 9, 8 }, { 6, 5, 2, 6 }, { 5, 1, 33, 4 } });
            for (int i = 0; i < Math.Sqrt(actual.Length); i++)
                for (int j = 0; j < Math.Sqrt(actual.Length); j++)
                    Assert.AreEqual(expected[i, j], actual[i, j]);
        }
    }
}
