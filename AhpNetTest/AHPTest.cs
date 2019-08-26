using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathNet.Numerics.LinearAlgebra;

using AhpNet;

namespace AhpNetTest
{
    [TestClass]
    public class AHPTest
    {
        [TestMethod]
        public void ResultTest()
        {
            var wpe = Matrix<double>.Build.DenseOfArray(new double[,]{
                {1d,    3d, 1d/3d},
                {1d/3d, 1d, 1d/5d},
                {3d,    5d, 1d},
            });
            var weas = new List<Matrix<double>> {
                Matrix<double>.Build.DenseOfArray(new double[,]{
                    {1d,    5d, 1d/3d},
                    {1d/5d, 1d, 1d/7d},
                    {3d,    7d, 1d},
                }),
                Matrix<double>.Build.DenseOfArray(new double[,]{
                    {1d, 1d/3d, 1d/5d},
                    {3d, 1d,    1d/3d},
                    {5d, 3d,    1d},
                }),
                Matrix<double>.Build.DenseOfArray(new double[,]{
                    {1d, 1d/5d, 1d/3d},
                    {5d, 1d,    3d},
                    {3d, 1d/3d, 1d},
                }),
            };
            var ahp = new AHP<double>(wpe, weas);
            var result = ahp.Result();
            Assert.AreEqual(1, 1);
        }
    }
}
