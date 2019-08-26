using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Test Method for DLL debugging
        /// </summary>
        /// <returns></returns>
        public static string HelloLibrary()
        {
            return "Hello World.";
        }
    }
}
