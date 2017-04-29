using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// class which contains matrix extensions
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Extension method which allaws to sum up two matrixes
        /// </summary>
        /// <typeparam name="T">type that closes method</typeparam>
        /// <param name="matrix">matrix whose functions is extended by this method</param>
        /// <param name="other">matrix which is added to existing</param>
        /// <param name="sum">the way of addition</param>
        /// <returns>new matrix which is sum of two matrixes</returns>
        public static Matrix<T> Sum<T>(this Matrix<T> matrix, Matrix<T> other, ISum<T> sum)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            var visitor = new Addition<T>(other, sum);
            matrix.Accept(visitor);
            return visitor.Result;
        }
    }
}
