namespace BlockchainSharp.Stores
{
    using System;
    using System.Collections.Generic;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;

    public interface IBlockStore
    {
        Block GetByHash(Hash hash);

        IEnumerable<Block> GetByNumber(ulong number);

        IEnumerable<Block> GetByParentHash(Hash hash);

        void Save(Block block);

        void Remove(Hash hash);
    }
}
