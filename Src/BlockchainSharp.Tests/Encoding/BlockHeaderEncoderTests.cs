namespace BlockchainSharp.Tests.Encoding
{
    using System;
    using System.Numerics;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Encoding;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BlockHeaderEncoderTests
    {
        [TestMethod]
        public void EncodeDecodeBlockHeader()
        {
            BlockHeaderEncoder encoder = new BlockHeaderEncoder();
            BlockHash parentHash = new BlockHash(new byte[] { 1, 2, 3 });
            Hash transactionsHash = new Hash();
            BlockHeader header = new BlockHeader(1, parentHash, transactionsHash);

            var result = encoder.Decode(encoder.Encode(header));

            Assert.IsNotNull(result);
            Assert.AreEqual(1ul, result.Number);
            Assert.AreEqual(parentHash, result.ParentHash);
            Assert.AreEqual(transactionsHash, result.TransactionsHash);
        }
    }
}
