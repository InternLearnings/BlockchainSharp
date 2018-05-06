namespace BlockchainSharp.Tests.Processors
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlockchainSharp.Tests.TestUtils;
    using BlockchainSharp.Processors;
    using BlockchainSharp.Core;
    using BlockchainSharp.Net.Messages;

    [TestClass]
    public class MessageProcessorTests
    {
        [TestMethod]
        public void ProcessBlockMessage()
        {
            BlockProcessor blockProcessor = FactoryHelper.CreateBlockProcessor();
            Block block = FactoryHelper.CreateGenesisBlock();
            BlockMessage message = new BlockMessage(block);

            MessageProcessor processor = new MessageProcessor(blockProcessor);

            processor.ProcessMessage(message);

            Assert.IsNotNull(blockProcessor.BlockChain);
            Assert.AreEqual(0, blockProcessor.BlockChain.BestBlockNumber);
            Assert.AreEqual(block, blockProcessor.BlockChain.GetBlock(0));
        }
    }
}
