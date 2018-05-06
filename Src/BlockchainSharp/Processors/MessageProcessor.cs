namespace BlockchainSharp.Processors
{
    using BlockchainSharp.Net.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MessageProcessor
    {
        private BlockProcessor blockProcessor;

        public MessageProcessor(BlockProcessor blockProcessor)
        {
            this.blockProcessor = blockProcessor;
        }

        public void ProcessMessage(Message message)
        {
            this.blockProcessor.Process(((BlockMessage)message).Block);
        }
    }
}
