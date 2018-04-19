namespace BlockchainSharp.Stores
{
    using BlockchainSharp.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TransactionPool
    {
        private ISet<Transaction> transactions = new HashSet<Transaction>();

        public ISet<Transaction> Transactions { get { return this.transactions; } }

        public void AddTransaction(Transaction transaction)
        {
            this.transactions.Add(transaction);
        }
    }
}
