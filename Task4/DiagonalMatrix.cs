using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class DiagonalMatrix<T>:Matrix<T>
    {
        public DiagonalMatrix(int size):base(size)
        {
        }

        public DiagonalMatrix(int size, T[,] array) : base(size,array)
        {
        }

        public override bool CheckExisting(int size, T[,] array)
        {
            if (ReferenceEquals(array, null))
                throw new ArgumentNullException(nameof(array));

            if (Math.Sqrt(array.Length) != size)
                return false;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i != j)
                        if (!Equals(array[i, j], default(T)))
                            return false;

            return true;
        }

        protected override void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"Diagonal matrix[{e.Rows},{e.Columns}] is changed !");
    }
}
