using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Abstract generic class contains main information about matrix
    /// </summary>
    /// <typeparam name="T">Type which closes class</typeparam>
    public abstract class Matrix<T>
    {
        #region private fields
        /// <summary>
        /// Two-dimensional array which is one of matrix's type.
        /// </summary>
        private T[,] matrix;
        #endregion

        #region prop
        /// <summary>
        /// Amount of elements in matrix
        /// </summary>
        public int Length { get { return matrix.Length; } }

        /// <summary>
        /// Indexer which allows to work safely elements in matrix 
        /// </summary>
        /// <param name="i">row of matrix</param>
        /// <param name="j">column of matrix</param>
        /// <returns>element of matrix</returns>
        public T this[int i, int j]
        {
            get {
                if (i > Math.Sqrt(Length) - 1 || j > Math.Sqrt(Length) - 1 || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException(nameof(matrix));
                return matrix[i, j];
            }
            set {
                if (i > Math.Sqrt(Length) - 1 || j > Math.Sqrt(Length) - 1 || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException(nameof(matrix));
                matrix[i, j] = value;
            }
        }
        #endregion

        #region event
        /// <summary>
        /// event which starts in case changing element in matrix
        /// </summary>
        public event EventHandler<MatrixEventArgs> changeMatrix = delegate { };
        #endregion

        #region ctor
        /// <summary>
        /// create matrix with specified size
        /// </summary>
        /// <param name="size">size of matrix</param>
        public Matrix(int size)
        {
            matrix = new T[size, size];
        }

        /// <summary>
        /// create matrix which is based on existing matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        public Matrix(int size, T[,] array)
        {
            if (CheckExisting(size, array))
            {
                matrix = new T[size, size];
                Array.Copy(array, matrix, array.Length);
            }
            else
                throw new ArgumentException(nameof(array));
        }
        #endregion

        #region API
        /// <summary>
        /// checks a possibility to create matrix based on existing matrix
        /// </summary>
        /// <param name="size">size of matrix</param>
        /// <param name="array">existing matrix</param>
        /// <returns>true in case possibility to create matrix based on existing matrix else false</returns>
        public abstract bool CheckExisting(int size, T[,] array);

        /// <summary>
        /// Adds new operation to classes inheritance
        /// </summary>
        /// <param name="visitor">object of class with additional information</param>
        public void Accept(IMatrixVisitor<T> visitor) => visitor.Visit((dynamic)this);

        /// <summary>
        /// Registrate method on event
        /// </summary>
        public void Register() => this.changeMatrix += Info;

        /// <summary>
        /// Unregistrate method fro event
        /// </summary>
        public void Unregister() => this.changeMatrix -= Info;

        /// <summary>
        /// Change element in matrix
        /// </summary>
        /// <param name="row">row of matrix</param>
        /// <param name="column">column of matrix</param>
        /// <param name="element">element which is replaced with element[row,column]</param>
        public void ChangeElement(int row, int column, T element)
        {
            MatrixEventArgs changeElement = new MatrixEventArgs(row, column);
            this[row, column] = element;
            OnChangeMatrix(changeElement);
        }

        /// <summary>
        /// Method starts after event running.
        /// </summary>
        /// <param name="sender">object which runs event</param>
        /// <param name="e">additional information about object</param>
        protected abstract void Info(object sender, MatrixEventArgs e);
        #endregion

        #region private methods
        /// <summary>
        /// method starts event
        /// </summary>
        /// <param name="e">additional information about object</param>
        private void OnChangeMatrix(MatrixEventArgs e) => changeMatrix?.Invoke(this, e);
        #endregion
    }

    /// <summary>
    /// class contains additional data about changable object
    /// </summary>
    public class MatrixEventArgs:EventArgs
    {
        #region prop
        /// <summary>
        /// row of matrix
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// column of matrix
        /// </summary>
        public int Columns { get; }
        #endregion

        #region ctor
        /// <summary>
        /// create object with information about changable element
        /// </summary>
        /// <param name="rows">row of matrix</param>
        /// <param name="columns">column of matrix</param>
        public MatrixEventArgs(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
        #endregion
    }
}