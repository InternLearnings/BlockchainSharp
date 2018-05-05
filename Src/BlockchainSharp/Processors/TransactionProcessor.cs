namespace BlockchainSharp.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Stores;

    public class TransactionProcessor
    {
        private TransactionPool transactionPool;

        public TransactionProcessor(TransactionPool transactionPool)
        {
            this.transactionPool = transactionPool;
        }

        public TransactionProcess AddTransaction(Transaction transaction)
        {
            if (this.transactionPool.Transactions.Contains(transaction))
                return TransactionProcess.Known;

            this.transactionPool.AddTransaction(transaction);

            return TransactionProcess.Added;
        }
    }
}
