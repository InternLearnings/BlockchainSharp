namespace BlockchainSharp.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Stores;

    public class MinerProcessor
    {
        private TransactionPool transactionPool;

        public MinerProcessor(TransactionPool transactionPool)
        {
            this.transactionPool = transactionPool;
        }

        public Block MineBlock(Block parent)
        {
            return new Block(parent.Number + 1, parent.Hash, this.transactionPool.Transactions);
        }
    }
}
