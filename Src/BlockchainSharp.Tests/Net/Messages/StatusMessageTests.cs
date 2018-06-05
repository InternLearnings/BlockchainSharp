namespace BlockchainSharp.Tests.Net.Messages
{
    using System;
    using BlockchainSharp.Core;
    using BlockchainSharp.Net.Messages;
    using BlockchainSharp.Tests.TestUtils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Core.Types;

    [TestClass]
    public class StatusMessageTests
    {
        [TestMethod]
        public void CreateMessageWithStatus()
        {
            Status status = new Status(42, new BlockHash(new byte[] { 1, 2, 3 }));

            StatusMessage message = new StatusMessage(status);

            Assert.AreSame(status, message.Status);
            Assert.AreEqual(MessageType.StatusMessage, message.MessageType);
        }
    }
}
