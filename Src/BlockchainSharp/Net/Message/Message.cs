namespace BlockchainSharp.Net.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Message
    {
        private MessageType type;

        public Message(MessageType type)
        {
            this.type = type;
        }

        public MessageType MessageType { get { return this.type; } }
    }
}

