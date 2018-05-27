namespace BlockchainSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Encoding;
    using BlockchainSharp.Tries;

    public class AccountsState
    {
        private static AccountStateEncoder encoder = new AccountStateEncoder();
        private static AccountState defaultValue = new AccountState(BigInteger.Zero, 0);

        private Trie states;

        public AccountsState()
            : this(new Trie())
        {
        }

        private AccountsState(Trie states)
        {
            this.states = states;
        }

        public AccountsState Put(Address address, AccountState state)
        {
            return new AccountsState(this.states.Put(address.Bytes, encoder.Encode(state)));
        }

        public AccountState Get(Address address)
        {
            var result = this.states.Get(address.Bytes);

            if (result == null)
                return defaultValue;

            return encoder.Decode(result);
        }
    }
}
