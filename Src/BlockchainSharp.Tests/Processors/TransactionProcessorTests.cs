namespace BlockchainSharp.Tests.Processors
{
    using System;
    using System.Numerics;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Processors;
    using BlockchainSharp.Stores;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionProcessorTests
    {
        [TestMethod]
        public void AddTransaction()
        {
            var sender = new Address();
            var receiver = new Address();

            Transaction transaction = new Transaction(sender, receiver, new BigInteger(100));
            TransactionPool pool = new TransactionPool();

            TransactionProcessor processor = new TransactionProcessor(pool);

            Assert.AreEqual(TransactionProcess.Added, processor.AddTransaction(transaction));

            Assert.IsTrue(pool.Transactions.Contains(transaction));
        }

        [TestMethod]
        public void AddTransactionTwice()
        {
            var sender = new Address();
            var receiver = new Address();

            Transaction transaction = new Transaction(sender, receiver, new BigInteger(100));
            TransactionPool pool = new TransactionPool();

            TransactionProcessor processor = new TransactionProcessor(pool);

            Assert.AreEqual(TransactionProcess.Added, processor.AddTransaction(transaction));
            Assert.AreEqual(TransactionProcess.Known, processor.AddTransaction(transaction));

            Assert.IsTrue(pool.Transactions.Contains(transaction));
        }
    }
}
