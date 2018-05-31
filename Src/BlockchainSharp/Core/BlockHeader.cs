namespace BlockchainSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Encoding;
    using Org.BouncyCastle.Crypto.Digests;

    public class BlockHeader
    {
        private long number;
        private Hash parentHash;
        private Hash transactionsHash;

        private BlockHash hash;

        public BlockHeader(long number, Hash parentHash, Hash transactionsHash)
        {
            this.number = number;
            this.parentHash = parentHash;
            this.transactionsHash = transactionsHash;
        }

        public long Number { get { return this.number; } }

        public Hash ParentHash { get { return this.parentHash; } }

        public Hash TransactionsHash { get { return this.transactionsHash; } }

        public BlockHash Hash
        {
            get
            {
                if (this.hash != null)
                    return this.hash;

                this.hash = new BlockHash(this);

                return this.hash;
            }
        }
    }
}
