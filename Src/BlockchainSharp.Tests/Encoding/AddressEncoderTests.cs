namespace BlockchainSharp.Tests.Encoding
{
    using System;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Encoding;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddressEncoderTests
    {
        [TestMethod]
        public void EncodeAndDecodeAddress()
        {
            Address address = new Address();
            AddressEncoder encoder = new AddressEncoder();

            byte[] bytes = encoder.Encode(address);

            Assert.IsNotNull(bytes);
            Assert.AreNotEqual(0, bytes.Length);

            Address result = encoder.Decode(bytes);

            Assert.IsNotNull(result);
            Assert.AreEqual(address, result);
        }
    }
}
