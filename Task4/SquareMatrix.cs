using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareMatrix<T>:Matrix<T>
    {
        public SquareMatrix(int size):base(size)
        {
        }

        public SquareMatrix(int size, T[,] array) : base(size,array)
        {
        }

        public override bool CheckExisting(int size, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException(nameof(array));

            if (Math.Sqrt(array.Length) != size)
                return false;

            return true;
        }

        protected override void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"Square matrix[{e.Rows},{e.Columns}] is changed !");
    }
}
