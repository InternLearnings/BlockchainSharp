namespace BlockchainSharp.Tests.TestUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Processors;
    using BlockchainSharp.Stores;

    public static class FactoryHelper
    {
        public static BlockProcessor CreateBlockProcessor()
        {
            return new BlockProcessor(new BlockChain(), new InMemoryBlockStore());
        }

        public static Block CreateGenesisBlock() 
        {
            return new Block(0, null);
        }

        public static Transaction CreateTransaction(long value)
        {
            var sender = new Address();
            var receiver = new Address();

            return new Transaction(sender, receiver, new BigInteger(value));
        }
    }
}
