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
        private TransactionProcessor transactionProcessor;

        public MessageProcessor(BlockProcessor blockProcessor, TransactionProcessor transactionProcessor)
        {
            this.blockProcessor = blockProcessor;
            this.transactionProcessor = transactionProcessor;
        }

        public void ProcessMessage(Message message)
        {
            if (message.MessageType == MessageType.BlockMessage)
                this.blockProcessor.ProcessBlock(((BlockMessage)message).Block);
            else if (message.MessageType == MessageType.TransactionMessage)
                this.transactionProcessor.ProcessTransaction(((TransactionMessage)message).Transaction);
        }
    }
}
