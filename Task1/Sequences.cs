using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class works with different kind of sequences
    /// </summary>
    public static class Sequences
    {
        /// <summary>
        /// calculates sequence by Fibonacci method
        /// </summary>
        /// <param name="number">number which is define limit for sequence</param>
        /// <returns>enumerator of sequence</returns>
        public static IEnumerable<int> Fibonacci(int number)
        {
            if (number < 0)
                throw new ArgumentException(nameof(number));

            yield return 0;
            int first = 0,
                second = 0,
                sum = 1;
            
            while (sum <= number)
            {
                yield return sum;
                first = second;
                second = sum;
                sum = first + second;
            }
        }
    }
}
