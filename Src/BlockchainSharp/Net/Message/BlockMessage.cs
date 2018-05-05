namespace BlockchainSharp.Net.Message
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core;

    public class BlockMessage : Message
    {
        private Block block;

        public BlockMessage(Block block)
            : base(MessageType.BlockMessage)
        {
            this.block = block;
        }

        public Block Block { get { return this.block; } }
    }
}
