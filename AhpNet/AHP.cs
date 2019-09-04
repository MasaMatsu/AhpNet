using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace AhpNet
{
    public class AHP<T> where T : struct, IEquatable<T>, IFormattable
    {
        #region Properties

        /// <summary>
        /// The matrix for pairwise comparison of Problem-Evaluations
        /// </summary>
        public Matrix<T> MPCPE { get; private set; }

        /// <summary>
        /// The matrix for pairwise comparison of Evaluations-Alternatives
        /// </summary>
        public IEnumerable<Matrix<T>> MPCEAs { get; private set; }

        #endregion

        public AHP(Matrix<T> mpcpe, IEnumerable<Matrix<T>> mpceas)
        {
            var errors = new List<string>();
            if (ValidateMatrixes(errors, mpcpe, mpceas))
                throw new InvalidOperationException(String.Join("¥n", errors));

            MPCPE = mpcpe;
            MPCEAs = mpceas;
        }

        private bool ValidateMatrixes(List<string> errors, Matrix<T> mpcpe, IEnumerable<Matrix<T>> mpceas)
        {
            var oldCount = errors.Count;

            foreach (var matrix in mpceas.Concat(new[] {mpcpe}))
            {
                if (matrix.ColumnCount != matrix.RowCount)
                    errors.Add($"The matrix must be a diagonal matrix.");
            }

            if (MPCPE.ColumnCount != MPCEAs.Count())
                errors.Add("The number of evaluations does not match.");

            return oldCount == errors.Count;
        }

        public Vector<T> Result() // The weight of Problem-Evaluations
        {
            var wpe = MPCPE.MaxEigen().Vector;

            var rows = MPCEAs.First().ColumnCount;
            var columns = MPCEAs.Count();
            var wea = Matrix<T>.Build.Dense(rows, columns); // The weight of Evaluations-Alternatives
            foreach (var x in MPCEAs.Select((mpcea, index) => (mpcea, index)))
            {
                var vector = x.mpcea.MaxEigen().Vector;
                wea.SetColumn(x.index, vector);
            }

            return wea * wpe;
        }
    }
}
