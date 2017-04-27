using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SymmetricMatrix<T>:Matrix<T>
    {
        public SymmetricMatrix(int size):base(size)
        {
        }

        public SymmetricMatrix(int size, T[,] array) : base(size,array)
        {
        }

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

        protected override void Info(object sender, MatrixEventArgs e) => Console.WriteLine($"Symmetric matrix[{e.Rows},{e.Columns}] is changed !");
    }
}
