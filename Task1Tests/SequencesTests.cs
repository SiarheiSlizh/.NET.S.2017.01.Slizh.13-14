using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1Tests
{
    [TestFixture]
    public class SequencesTests
    {
        private int[][] arr = new int[][] {
            new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 },
            new int[] { 0, 1, 1 },
            new int[] { 0, 1, 1, 2, 3, 5},
            new int[] { 0 }
        };

        private int[] num = new int[] { 70, 1, 6, 0 };

        private IEnumerable<bool> Fibonacci()
        {
            for (int i = 0; i < 4; i++)
            {
                IEnumerable<int> res = Sequences.Fibonacci(num[i]);
                IStructuralEquatable act = res.ToArray();
                yield return act.Equals(arr[i], StructuralComparisons.StructuralEqualityComparer) ? true : false;
            }
        }

        [Test]
        public void Fibonacci_PositiveTests()
        {
            bool[] actual = new bool[4];
            int i = 0;
            foreach (var item in Fibonacci())
                actual[i++] = item;
            bool[] expected = new bool[] { true, true, true, true };
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        public void Fibonacci_ArgumentException(int number)
        {
            Assert.Throws<ArgumentException>(
                () => {
                    foreach (var item in Sequences.Fibonacci(number))
                    { }
                    });
        }
    }
}