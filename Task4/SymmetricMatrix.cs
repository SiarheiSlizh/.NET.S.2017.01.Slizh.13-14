using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// generic class contains main information about symmetric matrix
    /// </summary>
    /// <typeparam name="T">Type which closes class</typeparam>
    public class SymmetricMatrix<T>:Matrix<T>
    {
        #region ctor
        /// <summary>
        /// create symmetric matrix with specified size
        /// </summary>
        /// <param name="size">size of matrix</param>
        public SymmetricMatrix(int size):base(size)
        {
        }

        /// <summary>
        /// create symmetric matrix which is based on existing matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        public SymmetricMatrix(int size, T[,] array) : base(size,array)
        {
        }
        #endregion

        #region Api
        /// <summary>
        /// checks a possibility to create symmetric matrix based on existing matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        /// <returns>true in case possibility to create symmetric matrix based on existing matrix else false</returns>
        public override bool CheckExisting(int size, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException(nameof(array));

            if (Math.Sqrt(array.Length) != size)
                return false;

            for (int i = 0; i < size - 1; i++)
                for (int j = i + 1; j < size; j++)
                    if (!Equals(array[i, j], array[j, i]))
                        return false;

            return true;
        }

        /// <summary>
        /// Method starts after event running.
        /// </summary>
        /// <param name="sender">object which runs event</param>
        /// <param name="e">additional information about symmetric matrix</param>
        protected override void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"Symmetric matrix[{e.Rows},{e.Columns}] is changed !");
        #endregion
    }
}
