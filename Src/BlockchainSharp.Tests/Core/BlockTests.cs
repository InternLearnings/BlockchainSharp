﻿namespace BlockchainSharp.Tests.Core
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
    public class BlockTests
    {
        [TestMethod]
        public void CreateWithNumber()
        {
            Block block = new Block(42, null);

            Assert.AreEqual(42ul, block.Number);
        }

        [TestMethod]
        public void IsGenesis()
        {
            Block block0 = new Block(0, null);
            Block block42 = new Block(42, null);

            Assert.IsTrue(block0.IsGenesis);
            Assert.IsFalse(block42.IsGenesis);
        }

        [TestMethod]
        public void GenesisHasNoParent()
        {
            try
            {
                new Block(0, new BlockHash(new byte[] { 1, 2, 3 }));
                Assert.Fail();
            }
            catch (Exception ex) 
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Genesis block should have no parent", ex.Message);
            }
        }

        [TestMethod]
        public void HasParent()
        {
            Block block0 = new Block(0, null);
            Block block1 = new Block(1, block0.Hash);
            Block block42 = new Block(42, null);

            Assert.IsTrue(block0.HasParent(null));
            Assert.IsTrue(block1.HasParent(block0));
            Assert.IsFalse(block1.HasParent(null));
            Assert.IsFalse(block0.HasParent(block1));
            Assert.IsFalse(block1.HasParent(block1));
            Assert.IsFalse(block42.HasParent(block1));
        }

        [TestMethod]
        public void CreateBlockWithTransaction()
        {
            Address from = new Address();
            Address to = new Address();
            Transaction transaction = new Transaction(from, to, new BigInteger(2));

            Block block = new Block(0, null, new Transaction[] { transaction });

            Assert.IsNotNull(block.Transactions);
            Assert.AreEqual(1, block.Transactions.Count());

            Transaction result = block.Transactions.First();

            Assert.AreEqual(new BigInteger(2), result.Value);
        }
    }
}
