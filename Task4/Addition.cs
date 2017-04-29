using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Class which contains additional functions for class matrix
    /// </summary>
    /// <typeparam name="T">type of element which closes class</typeparam>
    public class Addition<T> : IMatrixVisitor<T>
    {
        #region private fields
        /// <summary>
        /// matrix which is added to existing matrix
        /// </summary>
        private Matrix<T> other;

        /// <summary>
        /// criterion of summing elements of matrixes
        /// </summary>
        private ISum<T> criterion;
        #endregion

        #region prop
        /// <summary>
        /// result of summing two matrixes
        /// </summary>
        public SquareMatrix<T> Result { get; private set; }
        #endregion

        #region ctor
        /// <summary>
        /// create visitor which adds new operation to matrix
        /// </summary>
        /// <param name="other">matrix</param>
        /// <param name="criterion">criterion of sum of two matrixes</param>
        public Addition(Matrix<T> other, ISum<T> criterion)
        {
            this.other = other;
            this.criterion = criterion;
        }
        #endregion

        #region API
        /// <summary>
        /// finds sum with symmetric matrix
        /// </summary>
        /// <param name="matrix">symmetric matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        public SquareMatrix<T> Visit(SymmetricMatrix<T> matrix) => Sum(matrix);

        /// <summary>
        /// finds sum with square matrix
        /// </summary>
        /// <param name="matrix">square matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        public SquareMatrix<T> Visit(SquareMatrix<T> matrix) => Sum(matrix);

        /// <summary>
        /// finds sum with diagonal matrix
        /// </summary>
        /// <param name="matrix">diagonal matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        public SquareMatrix<T> Visit(DiagonalMatrix<T> matrix) => Sum(matrix);
        #endregion

        #region private methods
        /// <summary>
        ///  finds sum with any matrix
        /// </summary>
        /// <param name="matrix">any matrix which is added to existing matrix</param>
        /// <returns>new square matrix as result of sum two matrixes</returns>
        private SquareMatrix<T> Sum(Matrix<T> matrix)
        {
            int size = (int)Math.Sqrt(matrix.Length);
            Result = new SquareMatrix<T>(size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    Result[i, j] = criterion.Sum(other[i, j], matrix[i, j]);

            return Result as SquareMatrix<T>;
        }
        #endregion
    }
}
