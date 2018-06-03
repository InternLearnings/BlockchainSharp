namespace BlockchainSharp.Tests.Processors
{
    using System;
    using BlockchainSharp.Core;
    using BlockchainSharp.Net.Messages;
    using BlockchainSharp.Processors;
    using BlockchainSharp.Stores;
    using BlockchainSharp.Tests.TestUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MessageProcessorTests
    {
        [TestMethod]
        public void ProcessBlockMessage()
        {
            BlockProcessor blockProcessor = FactoryHelper.CreateBlockProcessor();
            Block block = FactoryHelper.CreateGenesisBlock();
            BlockMessage message = new BlockMessage(block);

            MessageProcessor processor = new MessageProcessor(blockProcessor, null);

            processor.ProcessMessage(message);

            Assert.IsNotNull(blockProcessor.BlockChain);
            Assert.AreEqual(block.Number, blockProcessor.BlockChain.BestBlockNumber);
            Assert.AreEqual(block, blockProcessor.BlockChain.GetBlock(0));
        }

        [TestMethod]
        public void ProcessTransactionMessage()
        {
            TransactionPool transactionPool = new TransactionPool();
            TransactionProcessor transactionProcessor = new TransactionProcessor(transactionPool);
            Transaction transaction = FactoryHelper.CreateTransaction(100);
            TransactionMessage message = new TransactionMessage(transaction);

            MessageProcessor processor = new MessageProcessor(null, transactionProcessor);

            processor.ProcessMessage(message);

            Assert.AreEqual(1, transactionPool.Transactions.Count);
            Assert.IsTrue(transactionPool.Transactions.Contains(transaction));
        }
    }
}
