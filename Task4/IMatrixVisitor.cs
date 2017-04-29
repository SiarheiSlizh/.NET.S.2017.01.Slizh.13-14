using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// interface for visitor which adds additional operation for matrixes
    /// </summary>
    /// <typeparam name="T">type of element in matrix</typeparam>
    public interface IMatrixVisitor<T>
    {
        /// <summary>
        /// finds sum with diagonal matrix
        /// </summary>
        /// <param name="matrix">diagonal matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        SquareMatrix<T> Visit(DiagonalMatrix<T> matrix);

        /// <summary>
        /// finds sum with square matrix
        /// </summary>
        /// <param name="matrix">square matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        SquareMatrix<T> Visit(SquareMatrix<T> matrix);

        /// <summary>
        /// finds sum with symmetric matrix
        /// </summary>
        /// <param name="matrix">symmetric matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        SquareMatrix<T> Visit(SymmetricMatrix<T> matrix);
    }
}
