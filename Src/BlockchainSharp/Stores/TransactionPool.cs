namespace BlockchainSharp.Stores
{
    using BlockchainSharp.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TransactionPool
    {
        private IList<Transaction> transactions = new List<Transaction>();

        public IList<Transaction> Transactions { get { return this.transactions; } }
    }
}
