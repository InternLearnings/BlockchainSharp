namespace BlockchainSharp.Net.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core;

    public class StatusMessage : Message
    {
        private Status status;

        public StatusMessage(Status status)
            : base(MessageType.StatusMessage)
        {
            this.status = status;
        }

        public Status Status { get { return this.status; } }
    }
}
