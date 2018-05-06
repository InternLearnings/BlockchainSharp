namespace BlockchainSharp.Tests.Net.Messages
{
    using System;
    using BlockchainSharp.Core;
    using BlockchainSharp.Net.Messages;
    using BlockchainSharp.Tests.TestUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionMessageTests
    {
        [TestMethod]
        public void CreateMessageWithTransaction()
        {
            Transaction transaction = FactoryHelper.CreateTransaction(100);

            TransactionMessage message = new TransactionMessage(transaction);

            Assert.AreSame(transaction, message.Transaction);
            Assert.AreEqual(MessageType.TransactionMessage, message.MessageType);
        }
    }
}
