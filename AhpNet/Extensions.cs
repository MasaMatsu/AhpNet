using System;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace AhpNet
{
    public static class Extensions
    {
        #region Matrix<T>

        /// <summary>
        /// Get maximum eigen value and its eigen vector.
        /// </summary>
        public static (Complex Value, Vector<T> Vector) MaxEigen<T>(this Matrix<T> matrix) where T : struct, IEquatable<T>, IFormattable
        {
            var eigen = matrix.Evd();
            var maxEigenValueIndexed =
                eigen.EigenValues
                .EnumerateIndexed()
                .Select(x => (Index: x.Item1, Value: x.Item2.Real))
                .OrderByDescending(x => x.Value)
                .First();
            var maxEigenVector = eigen.EigenVectors.Column(maxEigenValueIndexed.Index);

            return (maxEigenValueIndexed.Value, maxEigenVector.Divide(maxEigenVector.Sum()));
        }

        /// <summary>
        /// Get Consistency Index(C.I) of the Matrix.
        /// </summary>
        public static double CI<T>(this Matrix<T> matrix) where T : struct, IEquatable<T>, IFormattable
        {
            var eigenValue = matrix.MaxEigen().Value.Real;
            var count = (double)matrix.ColumnCount;
            return (eigenValue - count) / (count - 1);
        }

        #endregion
    }
}
