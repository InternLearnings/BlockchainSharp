namespace BlockchainSharp.Tests.Processors
{
    using System;
    using BlockchainSharp.Core;
    using BlockchainSharp.Processors;
    using BlockchainSharp.Stores;
    using BlockchainSharp.Tests.TestUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual(1ul, block.Number);
            Assert.AreEqual(0, block.Transactions.Count);
            Assert.AreEqual(genesis.Hash, block.ParentHash);
        }

        [TestMethod]
        public void MineBlockWithTransaction()
        {
            TransactionPool transactionPool = new TransactionPool();
            Transaction transaction = FactoryHelper.CreateTransaction(1000);
            transactionPool.AddTransaction(transaction);

            MinerProcessor processor = new MinerProcessor(transactionPool);
            Block genesis = FactoryHelper.CreateGenesisBlock();

            Block block = processor.MineBlock(genesis);

            Assert.IsNotNull(block);
            Assert.AreEqual(1ul, block.Number);
            Assert.AreEqual(1, block.Transactions.Count);
            Assert.AreSame(transaction, block.Transactions[0]);
            Assert.AreEqual(genesis.Hash, block.ParentHash);
        }

        [TestMethod]
        public void MineBlockWithTwoTransactions()
        {
            TransactionPool transactionPool = new TransactionPool();
            Transaction transaction1 = FactoryHelper.CreateTransaction(1000);
            Transaction transaction2 = FactoryHelper.CreateTransaction(2000);
            transactionPool.AddTransaction(transaction1);
            transactionPool.AddTransaction(transaction2);

            MinerProcessor processor = new MinerProcessor(transactionPool);
            Block genesis = FactoryHelper.CreateGenesisBlock();

            Block block = processor.MineBlock(genesis);

            Assert.IsNotNull(block);
            Assert.AreEqual(1ul, block.Number);
            Assert.AreEqual(2, block.Transactions.Count);
            Assert.IsTrue(block.Transactions.Contains(transaction1));
            Assert.IsTrue(block.Transactions.Contains(transaction2));
        }
    }
}
