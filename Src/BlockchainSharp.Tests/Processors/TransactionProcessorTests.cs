namespace BlockchainSharp.Tests.Processors
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Stores;
    using BlockchainSharp.Core;
    using BlockchainSharp.Processors;
    using System.Numerics;

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

            processor.AddTransaction(transaction);

            Assert.IsTrue(pool.Transactions.Contains(transaction));
        }
    }
}
