﻿namespace BlockchainSharp.Tests.Encoding
{
    using System;
    using System.Linq;
    using System.Numerics;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Encoding;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BlockEncoderTests
    {
        [TestMethod]
        public void EncodeDecodeBlock()
        {
            BlockEncoder encoder = new BlockEncoder();
            BlockHash hash = new BlockHash(new byte[] { 1, 2, 3 });
            Block block = new Block(1, hash);

            var result = encoder.Decode(encoder.Encode(block));

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Number);
            Assert.AreEqual(hash, result.ParentHash);
        }

        [TestMethod]
        public void EncodeDecodeBlockWithTransaction()
        {
            BlockEncoder encoder = new BlockEncoder();
            Address from = new Address();
            Address to = new Address();
            Transaction transaction = new Transaction(from, to, new BigInteger(2));

            Block original = new Block(0, null, new Transaction[] { transaction });
            Block block = encoder.Decode(encoder.Encode(original));

            Assert.IsNotNull(block.Transactions);
            Assert.AreEqual(1, block.Transactions.Count);

            Transaction result = block.Transactions.First();

            Assert.AreEqual(new BigInteger(2), result.Value);
        }
    }
}
