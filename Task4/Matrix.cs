using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public abstract class Matrix<T>
    {
        private T[,] matrix;

        public T this[int i, int j]
        {
            get {
                if (i > Math.Sqrt(matrix.Length) - 1 || j > Math.Sqrt(matrix.Length) - 1 || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException(nameof(matrix));
                return matrix[i, j];
            }
            set {
                if (i > Math.Sqrt(matrix.Length) - 1 || j > Math.Sqrt(matrix.Length) - 1 || i < 0 || j < 0)
                    throw new ArgumentOutOfRangeException(nameof(matrix));
                matrix[i, j] = value;
            }
        }

        public event EventHandler<MatrixEventArgs> changeMatrix = delegate { };

        public Matrix(int size)
        {
            matrix = new T[size, size];
        }

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

        public abstract bool CheckExisting(int size, T[,] array);

        public void Register(Matrix<T> matrix) => matrix.changeMatrix += Info;

        public void Unregister(Matrix<T> matrix) => matrix.changeMatrix -= Info;

        public void ChangeElement(int row, int column, T element)
        {
            MatrixEventArgs changeElement = new MatrixEventArgs(row, column);
            this[row, column] = element;
            OnChangeMatrix(changeElement);
        }

        protected virtual void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"matrix[{e.Rows},{e.Columns}] is changed !");

        private void OnChangeMatrix(MatrixEventArgs e) => changeMatrix?.Invoke(this, e);
    }

    public class MatrixEventArgs:EventArgs
    {
        public int Rows { get; }
        public int Columns { get; }

        public MatrixEventArgs(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }
    }
}
