using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// generic class contains main information about square matrix
    /// </summary>
    /// <typeparam name="T">Type which closes class</typeparam>
    public class SquareMatrix<T>:Matrix<T>
    {
        #region ctor
        /// <summary>
        /// create square matrix with specified size
        /// </summary>
        /// <param name="size">size of matrix</param>
        public SquareMatrix(int size):base(size)
        {
        }

        /// <summary>
        /// create square matrix which is based on existing matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        public SquareMatrix(int size, T[,] array) : base(size,array)
        {
        }
        #endregion

        #region Api
        /// <summary>
        /// checks a possibility to create square matrix based on existing matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        /// <returns>true in case possibility to create square matrix based on existing matrix else false</returns>
        public override bool CheckExisting(int size, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException(nameof(array));

            if (Math.Sqrt(array.Length) != size)
                return false;

            return true;
        }

        /// <summary>
        /// Method starts after event running.
        /// </summary>
        /// <param name="sender">object which runs event</param>
        /// <param name="e">additional information about square matrix</param>
        protected override void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"Square matrix[{e.Rows},{e.Columns}] is changed !");
        #endregion
    }
}
