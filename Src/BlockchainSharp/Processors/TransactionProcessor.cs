namespace BlockchainSharp.Processors
{
    using BlockchainSharp.Core;
    using BlockchainSharp.Stores;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TransactionProcessor
    {
        private TransactionPool transactionPool;

        public TransactionProcessor(TransactionPool transactionPool)
        {
            this.transactionPool = transactionPool;
        }

        public TransactionProcess AddTransaction(Transaction transaction)
        {
            this.transactionPool.AddTransaction(transaction);

            return TransactionProcess.Added;
        }
    }
}
