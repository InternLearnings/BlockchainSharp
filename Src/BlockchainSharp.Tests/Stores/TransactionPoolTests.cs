namespace BlockchainSharp.Tests.Stores
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Stores;

    [TestClass]
    public class TransactionPoolTests
    {
        [TestMethod]
        public void CreateWithEmptyList()
        {
            TransactionPool pool = new TransactionPool();

            Assert.AreEqual(0, pool.Transactions.Count);
        }
    }
}
