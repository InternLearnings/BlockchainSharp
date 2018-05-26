namespace BlockchainSharp.Tests.TestUtils
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HexUtilsTests
    {
        [TestMethod]
        public void ConvertEmptyStringToZeroLengthByteArray()
        {
            var result = HexUtils.StringToByteArray(string.Empty);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Length);
        }

        [TestMethod]
        public void ConvertStringTOneLengthByteArray()
        {
            var result = HexUtils.StringToByteArray("0f");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(15, result[0]);
        }

        [TestMethod]
        public void ConvertStringToOneLengthByteArray()
        {
            var result = HexUtils.StringToByteArray("0f");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(0x0f, result[0]);
        }

        [TestMethod]
        public void ConvertStringToTwoLengthByteArray()
        {
            var result = HexUtils.StringToByteArray("cafe");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(0xca, result[0]);
            Assert.AreEqual(0xfe, result[1]);
        }

        [TestMethod]
        public void ConvertUpperCaseStringToTwoLengthByteArray()
        {
            var result = HexUtils.StringToByteArray("CAFE");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(0xca, result[0]);
            Assert.AreEqual(0xfe, result[1]);
        }

        [TestMethod]
        public void ConvertMixedCaseStringToTwoLengthByteArray()
        {
            var result = HexUtils.StringToByteArray("CaFe");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(0xca, result[0]);
            Assert.AreEqual(0xfe, result[1]);
        }
    }
}
