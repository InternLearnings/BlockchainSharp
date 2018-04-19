namespace BlockchainSharp.Tests.Stores
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Stores;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Core;
    using System.Numerics;

    [TestClass]
    public class TransactionPoolTests
    {
        [TestMethod]
        public void CreateWithEmptyList()
        {
            TransactionPool pool = new TransactionPool();

            Assert.AreEqual(0, pool.Transactions.Count);
        }

        [TestMethod]
        public void AddTransaction()
        {
            var sender = new Address();
            var receiver = new Address();

            Transaction transaction = new Transaction(sender, receiver, new BigInteger(100));

            TransactionPool pool = new TransactionPool();

            pool.AddTransaction(transaction);

            Assert.AreEqual(1, pool.Transactions.Count);
            Assert.IsTrue(pool.Transactions.Contains(transaction));
        }

        [TestMethod]
        public void AddTransactionTwice()
        {
            var sender = new Address();
            var receiver = new Address();

            Transaction transaction = new Transaction(sender, receiver, new BigInteger(100));

            TransactionPool pool = new TransactionPool();

            pool.AddTransaction(transaction);
            pool.AddTransaction(transaction);

            Assert.AreEqual(1, pool.Transactions.Count);
            Assert.IsTrue(pool.Transactions.Contains(transaction));
        }
    }
}
