namespace BlockchainSharp.Tests.Net.Messages
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Tests.TestUtils;
    using BlockchainSharp.Core;
    using BlockchainSharp.Net.Message;

    [TestClass]
    public class BlockMessageTests
    {
        [TestMethod]
        public void CreateMessageWithBlock()
        {
            Block block = FactoryHelper.CreateGenesisBlock();

            BlockMessage message = new BlockMessage(block);

            Assert.AreSame(block, message.Block);
            Assert.AreEqual(MessageType.BlockMessage, message.MessageType);
        }
    }
}
