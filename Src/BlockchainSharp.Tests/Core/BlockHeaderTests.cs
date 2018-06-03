namespace BlockchainSharp.Tests.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BlockHeaderTests
    {
        [TestMethod]
        public void CreateWithNumber()
        {
            BlockHeader header = new BlockHeader(42, null, null);

            Assert.AreEqual(42ul, header.Number);
        }

        [TestMethod]
        public void CreateWithNumberParentHashAndTransactionsHash()
        {
            BlockHash parentHash = new BlockHash(new byte[] { 1, 2, 3 });
            Hash transactionsHash = new Hash();
            BlockHeader header = new BlockHeader(42, parentHash, transactionsHash);

            Assert.AreEqual(42ul, header.Number);
            Assert.AreEqual(parentHash, header.ParentHash);
            Assert.AreEqual(transactionsHash, header.TransactionsHash);
        }
    }
}
