namespace BlockchainSharp.Net.Message
{
    using BlockchainSharp.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TransactionMessage : Message
    {
        private Transaction transaction;

        public TransactionMessage(Transaction transaction)
            : base(MessageType.TransactionMessage)
        {
            this.transaction = transaction;
        }

        public Transaction Transaction { get { return this.transaction; } }
    }
}
