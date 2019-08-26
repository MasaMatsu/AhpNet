using Microsoft.VisualStudio.TestTools.UnitTesting;

using AhpNet;

namespace AhpNetTest
{
    [TestClass]
    public class AHPTest
    {
        [TestMethod]
        public void HelloLibraryTest()
        {
            var text = AHP.HelloLibrary();
            Assert.AreEqual(text, "Hello World.");
        }
    }
}
