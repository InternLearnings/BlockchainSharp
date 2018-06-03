namespace BlockchainSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core.Types;

    public class Status
    {
        private ulong height;
        private BlockHash hash;

        public Status(ulong height, BlockHash hash)
        {
            this.height = height;
            this.hash = hash;
        }

        public ulong Height { get { return this.height; } }

        public BlockHash Hash { get { return this.hash; } }
    }
}
