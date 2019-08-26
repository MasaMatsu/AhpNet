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
            // TODO: Validate arguments.

            MPCPE = mpcpe;
            MPCEAs = mpceas;
        }

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
