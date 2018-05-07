namespace BlockchainSharp.Tests.Processors
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Stores;
    using BlockchainSharp.Processors;
    using BlockchainSharp.Tests.TestUtils;
    using BlockchainSharp.Core;

    [TestClass]
    public class MinerProcessorTests
    {
        [TestMethod]
        public void MineBlock()
        {
            TransactionPool transactionPool = new TransactionPool();
            MinerProcessor processor = new MinerProcessor(transactionPool);
            Block genesis = FactoryHelper.CreateGenesisBlock();

            Block block = processor.MineBlock(genesis);

            Assert.IsNotNull(block);
            Assert.AreEqual(1, block.Number);
            Assert.AreEqual(0, block.Transactions.Count);
            Assert.AreEqual(genesis.Hash, block.ParentHash);
        }
    }
}
